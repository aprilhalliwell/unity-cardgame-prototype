using Assets.Data;
using world.room.data;

namespace core.Data.elements
{
  public class IdAndIndexData : VersionedDataElement
  {
    public string ID { get; private set; }
    public int Index { get; private set; }
    public IdAndIndexData(string id, int index)
    {
      ID = id;
      Index = index;
    }
    
    public override DataElement Clone()
    {
      return new IdAndIndexData(ID,Index);
    }
  }
}