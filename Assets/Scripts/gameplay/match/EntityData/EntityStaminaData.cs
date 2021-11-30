using System;
using Assets.Data;
using gameplay.match.PlayerData;
using UnityEngine;

namespace gameplay.match.EntityData
{
  public class EntityStaminaData : VersionedDataElement
  {
    public int MaxStamina;
    private int currentStamina;
    public int CurrentStamina
    {
      set
      {
        currentStamina = Mathf.Max(Mathf.Min(value, MaxStamina),0);
        markDirty();
      }
      get => currentStamina;
    }

    public EntityStaminaData(int maxStamina, int currentStamina)
    {
      MaxStamina = maxStamina;
      CurrentStamina = currentStamina;
    }
    public string GetText()
    {
      return $"{CurrentStamina}/{MaxStamina}";
    }
  }
}