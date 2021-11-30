using System.Collections.Generic;
using Assets.Data;

namespace player.data
{
  public class OwnedItemsData : VersionedDataElement
  {
    public List<string> Items = new List<string>();

    public OwnedItemsData(List<string> items)
    {
      Items = items;
    }

    public override DataElement Clone()
    {
      return new OwnedItemsData(new List<string>(Items));
    }
  }
}