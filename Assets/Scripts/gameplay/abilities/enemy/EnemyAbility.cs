using System.Collections;
using Assets.Data;
using gameplay.match;
using UnityEngine;

namespace gameplay.abilities.enemy
{
  public abstract class EnemyAbility 
  {
    protected MatchState state;
    public EnemyAbility()
    {
      state = Finder.Find<MatchState>();

    }

    public abstract string Indicate();
    public abstract int? IndicateAmount();
    public abstract IEnumerator Apply(ElementComposition composition);
  }
}