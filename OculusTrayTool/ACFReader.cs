using System;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool;

public class ACFReader
{
	public JObject Json;

	public ACFReader()
	{
		Json = null;
		Json = new JObject();
	}

	public ACFReader(JObject jObject)
	{
		Json = null;
		Json = jObject;
	}

	public bool TryProcessFolder(string folder)
	{
		bool result;
		try
		{
			if (!Directory.Exists(folder))
			{
				result = false;
				goto IL_007a;
			}
			string[] files = Directory.GetFiles(folder, "*.acf");
			string[] array = files;
			foreach (string fileName in array)
			{
				TryProcessFile(fileName);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryProcessFolder: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_007a;
		}
		result = true;
		goto IL_007a;
		IL_007a:
		return result;
	}

	public bool TryProcessFile(string fileName)
	{
		bool result;
		if (!File.Exists(fileName))
		{
			result = false;
		}
		else
		{
			try
			{
				if (Json["acf"] == null)
				{
					Json["acf"] = new JArray();
				}
				JArray jArray = (JArray)Json["acf"];
				string acfText = File.ReadAllText(fileName);
				if (!IsFileValid(acfText))
				{
					result = false;
					goto IL_00c4;
				}
				JObject jObject = new JObject();
				AcfToJson(acfText, jObject);
				jArray.Add(jObject);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("TryProcessFile: " + ex2.Message);
				result = false;
				ProjectData.ClearProjectError();
				goto IL_00c4;
			}
			result = true;
		}
		goto IL_00c4;
		IL_00c4:
		return result;
	}

	public bool TrySaveJson(string fileName)
	{
		string contents = Json.ToString();
		File.WriteAllText(fileName, contents);
		return true;
	}

	public bool IsFileValid(string acfText)
	{
		int num = StringCountChars(acfText, '"');
		int num2 = StringCountChars(acfText, '{');
		int num3 = StringCountChars(acfText, '}');
		return num2 == num3 && num % 2 == 0;
	}

	private bool AcfToJson(string acfText, JToken jToken)
	{
		bool result;
		checked
		{
			try
			{
				int length = acfText.Length;
				int num = 0;
				while (num < length)
				{
					int num2 = acfText.IndexOf('"', num);
					if (num2 == -1)
					{
						break;
					}
					int num3 = acfText.IndexOf('"', num2 + 1);
					if (num3 == -1)
					{
						break;
					}
					num = num3 + 1;
					string key = acfText.Substring(num2 + 1, num3 - num2 - 1);
					int num4 = acfText.IndexOf('"', num);
					int num5 = acfText.IndexOf('{', num);
					if (num5 == -1 || (num4 != -1 && num4 < num5))
					{
						int num6 = acfText.IndexOf('"', num4 + 1);
						string text = acfText.Substring(num4 + 1, num6 - num4 - 1);
						num = num6 + 1;
						jToken[key] = text;
					}
					else
					{
						int num7 = StringNextEndOf(acfText, '{', '}', num5 + 1);
						string acfText2 = acfText.Substring(num5 + 1, num7 - num5 - 1);
						JObject jToken3 = (JObject)(jToken[key] = new JObject());
						AcfToJson(acfText2, jToken3);
						num = num7 + 1;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("AcfToJson: " + ex2.Message);
				result = false;
				ProjectData.ClearProjectError();
				goto IL_014f;
			}
			result = true;
			goto IL_014f;
		}
		IL_014f:
		return result;
	}

	public int StringCountChars(string text, char ch)
	{
		int num = 0;
		checked
		{
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == ch)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int StringNextEndOf(string str, char open, char close, int startIndex)
	{
		if (open == close)
		{
			throw new InvalidOperationException();
		}
		int num = 0;
		int num2 = 0;
		checked
		{
			for (int i = startIndex; i < str.Length; i++)
			{
				if (str[i] == open)
				{
					num++;
				}
				if (str[i] == close)
				{
					num2++;
					if (num2 > num)
					{
						return i;
					}
				}
			}
			throw new InvalidOperationException();
		}
	}
}
