using System;
using System.Collections.Generic;

public class PointRules
{
  [Serializable]
  public enum CardRarities
  {
    Common,
    Uncommon,
    Rare
  }

  public Dictionary<int, CardRarities> CardRaritieses = new Dictionary<int, CardRarities>
  {
    {0, CardRarities.Common},
    {1, CardRarities.Uncommon},
    {2, CardRarities.Rare}
  };

  public Dictionary<CardRarities, int> maxPointsPerRarity = new Dictionary<CardRarities, int>
  {
    {CardRarities.Common, 6},
    {CardRarities.Uncommon, 9},
    {CardRarities.Rare, 12},
  };

  public Dictionary<CardRarities, int> freePointsPerRarity = new Dictionary<CardRarities, int>
  {
    {CardRarities.Common, 1},
    {CardRarities.Uncommon, 2},
    {CardRarities.Rare, 3},
  };

  public List<(int, float, string)> pointsSpenders = new List<(int, float, string)>
  {
    (1, 1f, "Block"),
    (1, 1f, "Damage"),
    (1, 1f, "Energy"),
    (2, 1f, "Essence"),
    (2, 1f, "AdditionalTarget"),
    // (3, 1f, "ShuffleDiscard"),
    (3, 1f, "DrawCard"),
    (4, 1f, "StunTarget"),
    (6, 1f, "AllTarget"),
    (8, 1f, "ReduceEnergy"),
    (12, 1f, "ReduceEssence"),
  };

  public List<(int, float, string)> pointsGainers = new List<(int, float, string)>
  {
    (1, 1f, "Energy"),
    (2, 1f, "Essence"),
    (3, 1f, "Health"),
    (3, 1f, "DiscardCard"),
    (3, 1f, "DeadCard"),
    // (5, 1f, "Single Use"),
  };
}