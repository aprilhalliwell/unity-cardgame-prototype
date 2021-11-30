using System.Collections;
using Assets.Data;
using gameplay.match;
using UnityEngine;

namespace gameplay.abilities.card
{
  public abstract class CardAbility
  {
    protected MatchState state;

    public CardAbility()
    {
      state = Finder.Find<MatchState>();
    }

    public abstract bool Validate(ElementComposition target);
    public abstract IEnumerator Apply(ElementComposition composition);
  }
}