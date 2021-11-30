using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
  public static class ListExtensions
  {
    private static Random rng = new Random();

    public static void Shuffle<T>(this Stack<T> stack)
    {
      var values = stack.ToArray();
      stack.Clear();
      foreach (var value in values.OrderBy(x => rng.Next()))
        stack.Push(value);
    }
    public static List<T> Shuffle<T>(this List<T> stack)
    {
      var values = stack.ToArray();
      stack.Clear();
      foreach (var value in values.OrderBy(x => rng.Next()))
      {
        stack.Add(value);
      }

      return stack;
    }
  }
}