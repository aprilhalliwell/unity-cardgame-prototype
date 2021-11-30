using System.Collections;
using Assets.Data;
using UnityEngine;

namespace gameplay.match
{
  public class MatchEntity: DataBehaviour, IHasData
  {
    ElementComposition composition; 
    IEnumerator Start()
    {
      var go = Finder.Find<MatchState>();
      while (go.matchComposition == null)
      {
        yield return null;
      }
      composition = go.matchComposition;
      start();
    }
    protected virtual void start(){}
    public ElementComposition Composition => composition;
  }
}