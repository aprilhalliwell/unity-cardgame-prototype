using Assets.Data;

namespace gameplay.match.EntityData
{
  public class EntityIDData : DataElement
  {
    public int Slot { get; private set; }
    public EntityIDData(int slot)
    {
      Slot =slot;
    }
  }
}