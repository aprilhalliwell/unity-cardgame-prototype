using Assets.Data;
using UnityEngine;

public static class Finder
{
  public static T Find<T>() where T : MonoBehaviour
  {
    var objs = GameObject.FindGameObjectsWithTag("FastFind");
    foreach (var gameObject in objs)
    {
      if (gameObject.TryGetComponent<T>(out var element))
      {
        return element;
      }
    }

    return GameObject.FindGameObjectWithTag("FastFind").GetComponent<T>();
  }

}