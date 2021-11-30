using System.Collections.Generic;
using Assets.Data;

namespace progression.cardBundles.data
{
  public class LevelUpData: VersionedDataElement
  {
    public List<ElementComposition> Data { get; private set; }

    public LevelUpData(List<ElementComposition> roomData)
    {
      Data = roomData;
    }
    
    public override DataElement Clone()
    {
      List<ElementComposition> cloned = new List<ElementComposition>();
      foreach (var ec in Data)
      {
        cloned.Add(ec.Clone());
      }
      return new LevelUpData(cloned);
    }
  }
}