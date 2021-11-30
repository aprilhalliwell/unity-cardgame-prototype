using System;
using Assets.Data;
using gameplay.match.PlayerData;
using UnityEngine;

namespace gameplay.match.EntityData
{
  public class EntityEssenceData : VersionedDataElement
  {
    public int MaxEssence;
    private int currentEssence;
    public int CurrentEssence
    {
      set
      {
        currentEssence = Math.Max(Mathf.Min(value, MaxEssence),0);
        markDirty();
      }
      get => currentEssence;
    }

    public EntityEssenceData(int maxEssence, int currentEssence)
    {
      MaxEssence = maxEssence;
      CurrentEssence = currentEssence;
    }
    public string GetText()
    {
      return $"{CurrentEssence}/{MaxEssence}";
    }
  }
}