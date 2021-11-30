using System.Collections.Generic;
using Assets.Data;
using gameplay.enums;

namespace player.data
{
  public class PlayerStat
  {
    public ResourceTypes ResourceTypes;
    private int currentStat;
    public int CurrentStat
    {
      get => currentStat;
      set
      {
        currentStat = value;
      }
    }
    private int maxStat;
    public int MaxStat
    {
      get => maxStat;
      set
      {
        maxStat = value;
      }
    }

    public PlayerStat(ResourceTypes resourceTypes, int currentStat, int maxStat)
    {
      this.ResourceTypes = resourceTypes;
      this.CurrentStat = currentStat;
      this.MaxStat = maxStat;
    }
  }
  
  public class PlayerStats : VersionedDataElement
  {

    public List<PlayerStat> Stats { get; private set; }
    public PlayerStats(List<PlayerStat> stats)
    {
      Stats = stats;
    }
    public void Update(List<PlayerStat> stats)
    {
      Stats = stats;
      markDirty();
    }
    public void Update(ResourceTypes resourceTypes, int current, int max)
    {
      var stat = Stats.Find(x => x.ResourceTypes == resourceTypes);
      stat.CurrentStat = current;
      stat.MaxStat = max;
      markDirty();
    }

    public override DataElement Clone()
    {
      List<PlayerStat> cloned = new List<PlayerStat>();
      foreach (var playerStat in Stats)
      {
        cloned.Add(new PlayerStat(playerStat.ResourceTypes,playerStat.CurrentStat,playerStat.MaxStat));
      }
      return new PlayerStats(cloned);
    }
  }
}