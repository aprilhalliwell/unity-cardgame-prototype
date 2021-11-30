using System;
using Assets.Data;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using System.Collections.Generic;

public class RoomDataRewards : VersionedDataElement
{
  public List<string> Rewards { get; private set; }

  public RoomDataRewards(StringListTrait rewards)
  {
    Rewards = rewards.Items;
  }
  public RoomDataRewards(List<string> rewards)
  {
    Rewards = rewards;
  }
  public void Update(List<string> rewards)
  {
    Rewards = rewards;
    markDirty();
  }
  public override DataElement Clone()
  {
    return new RoomDataRewards(new List<string>(Rewards));
  }
}