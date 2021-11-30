using System.Collections;
using Assets.Data;
using UnityEngine;

namespace gameplay.match
{
  public class PlayerEntity : DataBehaviour, IHasData
  {
    ElementComposition composition; 
    IEnumerator Start()
    {
      var go = Finder.Find<MatchState>();
      while (go.playerComposition == null)
      {
        yield return null;
      }
      composition = go.playerComposition;
      start();
    }
    protected virtual void start(){}
    public ElementComposition Composition => composition;
  }
}