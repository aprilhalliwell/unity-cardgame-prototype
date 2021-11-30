using Assets.Data;

namespace area.data
{
  public class AreaActiveTab : VersionedDataElement
  {
    private bool active;

    public bool Active
    {
      get => active;
      set
      {
        active = value;
        markDirty();
      }
    }

    public AreaActiveTab(bool state)
    {
      active = state;
    }

    public override DataElement Clone()
    {
      return new AreaActiveTab(active);
    }
  }
}