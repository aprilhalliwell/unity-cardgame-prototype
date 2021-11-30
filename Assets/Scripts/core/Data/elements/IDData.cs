using Assets.Data;
using world.room.data;

namespace core.Data.elements
{
  public class IDData: VersionedDataElement
  {
    public string ID { get; private set; }

    public IDData(string id)
    {
      ID = id;
    }
    
    public override DataElement Clone()
    {
      return new IDData(ID);
    }
  }
}