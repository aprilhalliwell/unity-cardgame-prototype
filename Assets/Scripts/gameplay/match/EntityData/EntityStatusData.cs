using Assets.Data;
using gameplay.enums;
using gameplay.match.PlayerData;

namespace gameplay.match.EntityData
{
  public class EntityStatusData : VersionedDataElement
  {
    private EntityStates state;
    public EntityStates State
    {
      set
      {
        state = value;
        markDirty();
      }
      get => state;
    }

    public EntityStatusData()
    {
      State = EntityStates.Normal;
    }
  }
}