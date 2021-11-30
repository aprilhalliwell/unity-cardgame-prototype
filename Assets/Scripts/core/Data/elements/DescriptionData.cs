using area.data;
using Assets.Data;
using Assets.Scheme.Traits;

namespace core.Data.elements
{
  public class DescriptionData: VersionedDataElement
  {
    private string description;
    public string Description
    {
      get => description;
      set
      {
        description = value;
        markDirty();
      }
    }
    public DescriptionData(StringTrait description)
    {
      Description = description.Text;
    }

    public DescriptionData(string description)
    {
      Description = description;
    }
    public override DataElement Clone()
    {
      return new DescriptionData(description);
    }
  }
}