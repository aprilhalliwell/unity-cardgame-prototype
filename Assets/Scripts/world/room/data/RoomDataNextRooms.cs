using System;
using System.Collections.Generic;
using Assets.Data;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;

public class RoomDataNextRooms : VersionedDataElement
{
  public List<string> NextRooms { get; private set; }

  public RoomDataNextRooms(StringListTrait nextRooms)
  {
    NextRooms = nextRooms.Items;
  }
  public RoomDataNextRooms(List<string> nextRooms)
  {
    NextRooms = nextRooms;
  }

  public void Update(List<string> nextRooms)
  {
    NextRooms = nextRooms;
    markDirty();
  }
  public override DataElement Clone()
  {
    return new RoomDataNextRooms(new List<string>(NextRooms));
  }
}