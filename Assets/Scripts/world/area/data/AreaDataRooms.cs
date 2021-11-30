using System;
using System.Collections.Generic;
using Assets.Data;

namespace area.data
{
  public class AreaRoomData : VersionedDataElement
  { 
    public Dictionary<int,List<ElementComposition>> RoomData { get; private set; }

    public AreaRoomData(Dictionary<int,List<ElementComposition>> roomData)
    {
      RoomData = roomData;
    }
    
    public override DataElement Clone()
    {
      Dictionary<int,List<ElementComposition>> cloned = new Dictionary<int, List<ElementComposition>>();
      foreach (var kvp in RoomData)
      {
        List<ElementComposition> innerCloned = new List<ElementComposition>();
        foreach (var elem in kvp.Value)
        {
          innerCloned.Add(elem.Clone());
        }
        cloned.Add(kvp.Key,innerCloned);
      }
      
      return new AreaRoomData(cloned);
    }
  }
}