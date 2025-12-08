// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.ACFReader
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

#nullable disable
namespace OculusTrayTool
{
  public class ACFReader
  {
    public JObject Json;

    public ACFReader()
    {
      this.Json = (JObject) null;
      this.Json = new JObject();
    }

    public ACFReader(JObject jObject)
    {
      this.Json = (JObject) null;
      this.Json = jObject;
    }

    public bool TryProcessFolder(string folder)
    {
      bool flag;
      try
      {
        if (!Directory.Exists(folder))
        {
          flag = false;
          goto label_8;
        }
        else
        {
          string[] files = Directory.GetFiles(folder, "*.acf");
          int index = 0;
          while (index < files.Length)
          {
            this.TryProcessFile(files[index]);
            checked { ++index; }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryProcessFolder: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      flag = true;
label_8:
      return flag;
    }

    public bool TryProcessFile(string fileName)
    {
      bool flag;
      if (!File.Exists(fileName))
      {
        flag = false;
      }
      else
      {
        try
        {
          if (this.Json["acf"] == null)
            this.Json["acf"] = (JToken) new JArray();
          JArray jarray = (JArray) this.Json["acf"];
          string acfText = File.ReadAllText(fileName);
          if (!this.IsFileValid(acfText))
          {
            flag = false;
            goto label_9;
          }
          else
          {
            JObject jobject = new JObject();
            this.AcfToJson(acfText, (JToken) jobject);
            jarray.Add((JToken) jobject);
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Log.WriteToLog("TryProcessFile: " + ex.Message);
          flag = false;
          ProjectData.ClearProjectError();
          goto label_9;
        }
        flag = true;
      }
label_9:
      return flag;
    }

    public bool TrySaveJson(string fileName)
    {
      string contents = this.Json.ToString();
      File.WriteAllText(fileName, contents);
      return true;
    }

    public bool IsFileValid(string acfText)
    {
      int num = this.StringCountChars(acfText, '"');
      return this.StringCountChars(acfText, '{') == this.StringCountChars(acfText, '}') && num % 2 == 0;
    }

    private bool AcfToJson(string acfText, JToken jToken)
    {
      bool json;
      try
      {
        int length = acfText.Length;
        int startIndex1 = 0;
        while (startIndex1 < length)
        {
          int num1 = acfText.IndexOf('"', startIndex1);
          if (num1 != -1)
          {
            int num2 = acfText.IndexOf('"', checked (num1 + 1));
            if (num2 != -1)
            {
              int startIndex2 = checked (num2 + 1);
              string key = acfText.Substring(checked (num1 + 1), checked (num2 - num1 - 1));
              int num3 = acfText.IndexOf('"', startIndex2);
              int num4 = acfText.IndexOf('{', startIndex2);
              if (num4 == -1 || num3 != -1 && num3 < num4)
              {
                int num5 = acfText.IndexOf('"', checked (num3 + 1));
                string str = acfText.Substring(checked (num3 + 1), checked (num5 - num3 - 1));
                startIndex1 = checked (num5 + 1);
                jToken[(object) key] = (JToken) str;
              }
              else
              {
                int num6 = this.StringNextEndOf(acfText, '{', '}', checked (num4 + 1));
                string acfText1 = acfText.Substring(checked (num4 + 1), checked (num6 - num4 - 1));
                JObject jobject = new JObject();
                jToken[(object) key] = (JToken) jobject;
                this.AcfToJson(acfText1, (JToken) jobject);
                startIndex1 = checked (num6 + 1);
              }
            }
            else
              break;
          }
          else
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AcfToJson: " + ex.Message);
        json = false;
        ProjectData.ClearProjectError();
        goto label_11;
      }
      json = true;
label_11:
      return json;
    }

    public int StringCountChars(string text, char ch)
    {
      int num = 0;
      int index = 0;
      while (index < text.Length)
      {
        if ((int) text[index] == (int) ch)
          checked { ++num; }
        checked { ++index; }
      }
      return num;
    }

    public int StringNextEndOf(string str, char open, char close, int startIndex)
    {
      if ((int) open == (int) close)
        throw new InvalidOperationException();
      int num1 = 0;
      int num2 = 0;
      int index = startIndex;
      while (index < str.Length)
      {
        if ((int) str[index] == (int) open)
          checked { ++num1; }
        if ((int) str[index] == (int) close)
        {
          checked { ++num2; }
          if (num2 > num1)
            return index;
        }
        checked { ++index; }
      }
      throw new InvalidOperationException();
    }
  }
}
