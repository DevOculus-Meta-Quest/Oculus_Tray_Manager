// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.MathTools
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;

#nullable disable
namespace OculusTrayTool
{
  public class MathTools
  {
    public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
    {
      T obj = value;
      if (value.CompareTo(min) < 0)
        obj = min;
      if (value.CompareTo(max) > 0)
        obj = max;
      return obj;
    }
  }
}
