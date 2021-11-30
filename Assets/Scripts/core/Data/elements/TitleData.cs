using Assets.Data;
using Assets.Scheme.Traits;

namespace core.Data.elements
{
  public class TitleData: VersionedDataElement
  {
    private string title;
    public string Title
    {
      get => title;
      set
      {
        title = value;
        markDirty();
      }
    }
    public TitleData(StringTrait title)
    {
      Title = title.Text;
    }
    public TitleData(string title)
    {
      Title = title;
    }
    public override DataElement Clone()
    {
      return new TitleData(title);
    }
  }
}