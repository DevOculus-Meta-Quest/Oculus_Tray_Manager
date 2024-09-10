using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool
{
	// Token: 0x0200005B RID: 91
	public class ACFReader
	{
		// Token: 0x06000922 RID: 2338 RVA: 0x000543DC File Offset: 0x000525DC
		public ACFReader()
		{
			this.Json = null;
			this.Json = new JObject();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x000543F8 File Offset: 0x000525F8
		public ACFReader(JObject jObject)
		{
			this.Json = null;
			this.Json = jObject;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00054410 File Offset: 0x00052610
		public bool TryProcessFolder(string folder)
		{
			try
			{
				bool flag = !Directory.Exists(folder);
				if (flag)
				{
					return false;
				}
				string[] files = Directory.GetFiles(folder, "*.acf");
				foreach (string text in files)
				{
					this.TryProcessFile(text);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryProcessFolder: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x000544A8 File Offset: 0x000526A8
		public bool TryProcessFile(string fileName)
		{
			bool flag = !File.Exists(fileName);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				try
				{
					bool flag3 = this.Json["acf"] == null;
					if (flag3)
					{
						this.Json["acf"] = new JArray();
					}
					JArray jarray = (JArray)this.Json["acf"];
					string text = File.ReadAllText(fileName);
					bool flag4 = !this.IsFileValid(text);
					if (flag4)
					{
						return false;
					}
					JObject jobject = new JObject();
					this.AcfToJson(text, jobject);
					jarray.Add(jobject);
				}
				catch (Exception ex)
				{
					Log.WriteToLog("TryProcessFile: " + ex.Message);
					return false;
				}
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x0005458C File Offset: 0x0005278C
		public bool TrySaveJson(string fileName)
		{
			string text = this.Json.ToString();
			File.WriteAllText(fileName, text);
			return true;
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x000545B4 File Offset: 0x000527B4
		public bool IsFileValid(string acfText)
		{
			int num = this.StringCountChars(acfText, '"');
			int num2 = this.StringCountChars(acfText, '{');
			int num3 = this.StringCountChars(acfText, '}');
			return num2 == num3 && num % 2 == 0;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x000545F4 File Offset: 0x000527F4
		private bool AcfToJson(string acfText, JToken jToken)
		{
			checked
			{
				try
				{
					int length = acfText.Length;
					int i = 0;
					while (i < length)
					{
						int num = acfText.IndexOf('"', i);
						bool flag = num == -1;
						if (flag)
						{
							break;
						}
						int num2 = acfText.IndexOf('"', num + 1);
						bool flag2 = num2 == -1;
						if (flag2)
						{
							break;
						}
						i = num2 + 1;
						string text = acfText.Substring(num + 1, num2 - num - 1);
						int num3 = acfText.IndexOf('"', i);
						int num4 = acfText.IndexOf('{', i);
						bool flag3 = num4 == -1 || (num3 != -1 && num3 < num4);
						if (flag3)
						{
							int num5 = acfText.IndexOf('"', num3 + 1);
							string text2 = acfText.Substring(num3 + 1, num5 - num3 - 1);
							i = num5 + 1;
							jToken[text] = text2;
						}
						else
						{
							int num6 = this.StringNextEndOf(acfText, '{', '}', num4 + 1);
							string text3 = acfText.Substring(num4 + 1, num6 - num4 - 1);
							JObject jobject = new JObject();
							jToken[text] = jobject;
							this.AcfToJson(text3, jobject);
							i = num6 + 1;
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("AcfToJson: " + ex.Message);
					return false;
				}
				return true;
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00054770 File Offset: 0x00052970
		public int StringCountChars(string text, char ch)
		{
			int num = 0;
			checked
			{
				for (int i = 0; i < text.Length; i++)
				{
					bool flag = text[i] == ch;
					if (flag)
					{
						num++;
					}
				}
				return num;
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x000547B4 File Offset: 0x000529B4
		public int StringNextEndOf(string str, char open, char close, int startIndex)
		{
			bool flag = open == close;
			if (flag)
			{
				throw new InvalidOperationException();
			}
			int num = 0;
			int num2 = 0;
			checked
			{
				for (int i = startIndex; i < str.Length; i++)
				{
					bool flag2 = str[i] == open;
					if (flag2)
					{
						num++;
					}
					bool flag3 = str[i] == close;
					if (flag3)
					{
						num2++;
						bool flag4 = num2 > num;
						if (flag4)
						{
							return i;
						}
					}
				}
				throw new InvalidOperationException();
			}
		}

		// Token: 0x040003E1 RID: 993
		public JObject Json;
	}
}
