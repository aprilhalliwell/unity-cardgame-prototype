using Assets.Data;

namespace world.room.data
{
  public class RoomDataCurrentMatchIndex : VersionedDataElement
  {
    private int matchIndex;

    public int MatchIndex
    {
      get => matchIndex;
      set
      {
        matchIndex = value;
        markDirty();
      }
    }
    public RoomDataCurrentMatchIndex(int matchIndex)
    {
      MatchIndex = matchIndex;
    }
    public override DataElement Clone()
    {
      return new RoomDataCurrentMatchIndex(matchIndex);
    }
  }
}