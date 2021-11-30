using System;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.match.commands;
using gameplay.match.PlayerData;
using UnityEngine;

namespace gameplay.match.EntityData
{
  public class EntityHealthData : VersionedDataElement
  {
    public int MaxHealth;
    public int CurrentHealth;

    public EntityHealthData(int maxHealth, int currentHealth)
    {
      MaxHealth = maxHealth;
      CurrentHealth = currentHealth;
    }

    public void DrainMaxLife(int drain)
    {
      MaxHealth = MaxHealth - drain;
      markDirty();
    }

    public void HealDamage(int amount)
    {
      CurrentHealth = Math.Max(CurrentHealth + amount,MaxHealth);
      markDirty();
    }
    public void DealDamage(int damage)
    {
      if (composition.Has<EntityShieldData>())
      {
        int blockAmount = composition.Get<EntityShieldData>().Shield;
        if (blockAmount >= damage)
        {
          var remaingSheild = blockAmount - damage;
          composition.Get<EntityShieldData>().Shield = remaingSheild;
        }
        else
        {
          var remainingDamage = damage - blockAmount;
          composition.Get<EntityShieldData>().Shield = 0;
          CurrentHealth = CurrentHealth - remainingDamage;
        }
      }
      else
      {
        CurrentHealth = CurrentHealth - damage;
      }

      new CheckAndEndGameCommand().Execute();
      markDirty();
    }
    public string GetText()
    {
      return $"{CurrentHealth}/{MaxHealth}";
    }
  }
}