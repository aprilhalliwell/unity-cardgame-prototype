using Assets.Scheme.Traits.BaseTraits;
using gameplay.abilities.card;
using gameplay.abilities.enemy;
using UnityEngine;

namespace gameplay.abilities
{
  public class AbilityFactory
  {
    public static string[] CardAbilities = new[]
    {
      "DealDamage", "LoseHealth", "DealDamageToAll", "HealToAll", "StunAll", "GrantBlock", "DrawCard", "StunTarget",
      "GrantStamina", "GrantEssence", "GrantCharge", "ConsumeAllChargeForCardsAndStamina", "ConsumeAllChargeForBlock",
      "ConsumeAllChargeForDamage", "DealDamageToTwoRandom", "RemoveFromGame", "RandomlyDiscard", "ClearOrbs",
      "Poison_N_Targets", "Blind_N_Targets","Grave_To_Hand","Discard_Cards","Shield_Per_Turn","Damage_After_N_Turns",
      "Randomize_Orbs","Discard_To_N","Swap_Attack_Health","Consume_All_Resources", "Destroy_N_Targets"
    };
 
    public static CardAbility GenerateCardAbility(Ability ability)
    {
      switch (ability.ScriptName)
      {
        case "DealDamage":
          return new card.DealDamage(ability.Target, ability.Amount);
        case "LoseHealth":
          return new LoseHealth(ability.Target, ability.Amount);
        case "DealDamageToAll":
          return new DealDamageToAll(ability.Target,ability.Amount);
        case "HealToAll":
          return new HealToAll(ability.Target,ability.Amount);
        case "StunAll":
          return new StunAll(ability.Target,ability.Amount);
        case "GrantBlock":
          return new GrantBlock(ability.Target,ability.Amount);
        case "DrawCard":
          return new DrawCard(ability.Target,ability.Amount);
        case "StunTarget":
          return new StunTarget(ability.Target,ability.Amount);
        case "GrantStamina":
          return new GrantStamina(ability.Target,ability.Amount);
        case "GrantEssence":
          return new GrantEssence(ability.Target,ability.Amount);
        case "GrantCharge":
          return new GrantCharge(ability.Target,ability.Amount);
        case "ConsumeAllChargeForCardsAndStamina":
          return new ConsumeAllChargeForCardsAndStamina(ability.Target,ability.Amount);
        case "ConsumeAllChargeForBlock":
          return new ConsumeAllChargeForBlock(ability.Target,ability.Amount);
        case "ConsumeAllChargeForDamage":
          return new ConsumeAllChargeForDamage(ability.Target,ability.Amount);
        case "DealDamageToTwoRandom":
          return new DealDamageToTwoRandom(ability.Target,ability.Amount);   
        case "RemoveFromGame":
          return new RemoveFromGame(ability.Target,ability.Amount);   
        case "RandomlyDiscard":
          return new RandomlyDiscard(ability.Target,ability.Amount);  
        case "ClearOrbs":
          return new RandomlyDiscard(ability.Target,ability.Amount);  
      }
      return null;
    }
    public static EnemyAbility GenerateEnemyAbility(Ability ability)
    {
      switch (ability.ScriptName)
      {
        case "DealDamage":
          return new enemy.DealDamage(ability.Target, ability.Amount);
      }
      return null;
    }
  }
}