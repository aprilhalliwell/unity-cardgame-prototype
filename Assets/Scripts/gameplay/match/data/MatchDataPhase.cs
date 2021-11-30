using Assets.Data;
using gameplay.enums;

namespace gameplay.match.data
{
  public class MatchDataPhase: VersionedDataElement
  {
    private Phases phase;
    public Phases Phase
    {
      get => phase;
      set
      {
        phase = value;
        markDirty();
      }
    }

    public MatchDataPhase( Phases phase)
    {
      this.Phase = phase;
    }

  }
}