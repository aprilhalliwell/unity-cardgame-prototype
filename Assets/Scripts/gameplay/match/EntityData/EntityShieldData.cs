using System;
using Assets.Data;
using UnityEditor;
using UnityEngine;

namespace gameplay.match.PlayerData
{
  public class EntityShieldData : VersionedDataElement
  {
    private int ShieldMax;
    private int shield;

    public int Shield
    {
      set
      {
        shield = Mathf.Max(Mathf.Min(value, ShieldMax),0);
        markDirty();
      }
      get => shield;
    }
    public EntityShieldData(int shieldMax, int shield)
    {
      ShieldMax = shieldMax;
      Shield = shield;
    }

    public string GetText()
    {
      return $"{shield}/{ShieldMax}";
    }
  }
}