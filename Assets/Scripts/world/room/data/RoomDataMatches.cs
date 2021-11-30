using System;
using System.Collections.Generic;
using Assets.Data;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;

public class RoomDataMatches : VersionedDataElement
{
  public List<ElementComposition> Matches { get; private set; }

  public RoomDataMatches(List<ElementComposition> matches)
  {
    Matches = matches;
  }

  public void Update(List<ElementComposition> matches)
  {
    Matches = matches;
    markDirty();
  }
  
  public override DataElement Clone()
  {
    return new RoomDataMatches(new List<ElementComposition>(Matches));
  }
}