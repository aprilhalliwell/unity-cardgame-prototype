using System.Collections;
using UnityEngine;

namespace Assets.Data
{
  public class SubscriptionProvider<T> : MonoBehaviour, IHasData  where T : MonoBehaviour
  {
    ElementComposition composition; 
    IEnumerator Start()
    {
      var go = Finder.Find<T>() as IHasData;
      Debug.Log($"Found {go}");
      while (go.Composition == null)
      {
        yield return null;
      }
      Debug.Log(go.Composition);
      composition = go.Composition;
      start();
    }
    protected virtual void start(){}

    public ElementComposition Composition => composition;
  }
}  