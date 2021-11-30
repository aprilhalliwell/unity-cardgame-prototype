using Assets.Data;

namespace gameplay.room.data
{
  public class RoomDataState : VersionedDataElement
  {
    private RoomRowStates rowStates;

    public RoomRowStates RowStates
    {
      get => rowStates;
      set
      {
        rowStates = value;
        markDirty();
      }
    }
    public RoomDataState(RoomRowStates state)
    {
      RowStates = state;
    }
    public override DataElement Clone()
    {
      return new RoomDataState(RowStates);
    }
  }
}