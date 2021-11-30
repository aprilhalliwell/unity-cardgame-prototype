using System;
using Assets.Data;
using Assets.Scheme.Traits;

public class RoomDataRow : VersionedDataElement
{
  public int Row { get; private set; }

  public RoomDataRow(IntTrait row)
  {
    Row = row.Amount;
  }
  public RoomDataRow(int row)
  {
    Row = row;
  }
  public override DataElement Clone()
  {
    return new RoomDataRow(Row);
  }
}