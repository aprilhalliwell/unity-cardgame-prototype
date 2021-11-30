using System.Collections.Generic;
using Assets.Data;

namespace core.Data.elements
{
  public class ComponentListData: VersionedDataElement
  {
    public List<ElementComposition> Data { get; private set; }

    public ComponentListData(List<ElementComposition> data)
    {
      Data = data;
    }
    
    public override DataElement Clone()
    {
      List<ElementComposition> cloned = new List<ElementComposition>();
      foreach (var ec in Data)
      {
        cloned.Add(ec.Clone());
      }
      return new ComponentListData(cloned);
    }
  }
}