using System;
using Assets.Data;
using gameplay.match.PlayerData;
using UnityEngine;

namespace gameplay.match.EntityData
{
  public class EntityChargeData : VersionedDataElement
  {
    public int MaxCharge;
    private int currentCharge;
    public int CurrentCharge
    {
      set
      {
        currentCharge = Mathf.Max(Mathf.Min(value, MaxCharge),0);
        markDirty();
      }
      get => currentCharge;
    }

    public EntityChargeData(int maxCharge, int currentCharge)
    {
      MaxCharge = maxCharge;
      CurrentCharge = currentCharge;
    }
    public string GetText()
    {
      return $"{CurrentCharge}/{MaxCharge}";
    }
  }
}