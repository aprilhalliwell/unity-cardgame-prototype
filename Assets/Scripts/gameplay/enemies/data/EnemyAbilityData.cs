using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using gameplay.abilities.card;
using gameplay.abilities.enemy;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.card.data.rendering
{
  public class EnemyAbilityData : VersionedDataElement
  {
    EnemyAbility selectedAbility;
    private int lastItem = 0;
    public List<EnemyAbility> PlayAbilities { get; private set; }
    public List<EnemyAbility> DeathAbilities { get; private set; }

    public EnemyAbilityData(List<EnemyAbility> playAbilities, List<EnemyAbility> deathAbilities)
    {
      PlayAbilities = playAbilities;
      DeathAbilities = deathAbilities;
      PickNextAbility();
    }

    public string GetIndicator()
    {
      return selectedAbility.Indicate();
    }
    public int? GetIndicatorAmount()
    {
      return selectedAbility.IndicateAmount();
    }
    public void PickNextAbility()
    {
      selectedAbility = PlayAbilities[lastItem];
      lastItem++;
      if (lastItem > PlayAbilities.Count)
      {
        lastItem = 0;
      }
      markDirty();
    }

    public IEnumerator ApplyAbilities()
    {
      yield return selectedAbility.Apply(composition);
    }
  }
}