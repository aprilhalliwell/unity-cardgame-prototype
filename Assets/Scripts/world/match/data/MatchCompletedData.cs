using Assets.Data;

namespace world.match.data
{
  public class MatchCompletedData: VersionedDataElement
  {
    private bool completed;

    public bool Completed
    {
      get => completed;
      set
      {
        completed = value;
        markDirty();
      }
    }

    public MatchCompletedData(bool state)
    {
      Completed = state;
    }
    
    public override DataElement Clone()
    {
      return new MatchCompletedData(completed);
    }
  }
}