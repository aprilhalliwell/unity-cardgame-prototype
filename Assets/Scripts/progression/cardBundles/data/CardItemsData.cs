using System.Collections.Generic;
using area.data;
using Assets.Data;

namespace progression.cardBundles.data
{
  public class CardItemsData : VersionedDataElement
  {
    public List<string> Data { get; private set; }

    public CardItemsData(List<string> roomData)
    {
      Data = roomData;
    }
    
    public override DataElement Clone()
    {
      List<string> cloned = new List<string>();
      foreach (var ec in Data)
      {
        cloned.Add(ec);
      }
      return new CardItemsData(cloned);
    }
  }
}