using System.Collections;
using Assets.Data;
using gameplay.effects;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
  public class CardUsed : CardAbility
  {
    public override bool Validate(ElementComposition target)
    {
      return true;
    }

    public override IEnumerator Apply(ElementComposition composition)
    {
      yield return state.playerComposition.Get<EntityDiscardData>().AddToDiscard(composition);
    }
  }
}