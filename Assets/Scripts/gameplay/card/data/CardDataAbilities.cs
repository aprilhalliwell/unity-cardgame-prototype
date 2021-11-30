using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using gameplay.abilities.card;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.card.data.rendering
{
  public class CardDataAbilities : VersionedDataElement
  {
    public List<CardAbility> PlayAbilities { get; private set; }
    public List<CardAbility> DiscardAbilities { get; private set; }

    public CardDataAbilities(List<CardAbility> playAbilities, List<CardAbility> discardAbilities)
    {
      PlayAbilities = playAbilities;
      DiscardAbilities = discardAbilities;
    }

    public bool isValidTarget(ElementComposition compositionToAffect)
    {
      bool canPlay = true;

      foreach (var cardAbility in PlayAbilities)
      {
        if (canPlay && compositionToAffect.Has<EntityTargetData>())
        {
          canPlay = cardAbility.Validate(compositionToAffect);
        }
      }

      return canPlay;
    }

    public IEnumerator ApplyAbilities(ElementComposition compositionToAffect, bool suppressMove = false)
    {
      foreach (var costs in composition.Get<CardDataCost>().Costs)
      {
        switch (costs.ResourceTypes)
        {
          case ResourceTypes.Essence:
            MatchState.PlayerComposition().Get<EntityEssenceData>().CurrentEssence -= costs.Cost;
            break;
          case ResourceTypes.Stamina:
            MatchState.PlayerComposition().Get<EntityStaminaData>().CurrentStamina -= costs.Cost;
            break;
          case ResourceTypes.Charge:
            MatchState.PlayerComposition().Get<EntityChargeData>().CurrentCharge -= costs.Cost;
            break;
        }
      }

      if (!suppressMove)
      {
        yield return MatchState.PlayerComposition().Get<EntityPresentData>().AddToPile(composition);
      }

      foreach (var cardAbility in PlayAbilities)
      {
        yield return cardAbility.Apply(compositionToAffect);
      }

      if (!suppressMove)
      {
        foreach (var discardAbility in DiscardAbilities)
        {
          yield return discardAbility.Apply(composition);
        }
      }
    }
  }
}