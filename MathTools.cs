// Decompiled with JetBrains decompiler

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
