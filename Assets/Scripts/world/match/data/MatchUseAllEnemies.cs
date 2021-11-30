using Assets.Data;
using Assets.Scheme.Traits.BaseTraits;

namespace world.match.data
{
  public class MatchUseAllEnemies: VersionedDataElement
  {
    private bool useAllEnemies;

    public bool UseAllEnemies
    {
      get => useAllEnemies;
      set
      {
        useAllEnemies = value;
        markDirty();
      }
    }

    public MatchUseAllEnemies(BooleanTrait boolean)
    {
      UseAllEnemies = boolean.State;
    }
    public MatchUseAllEnemies(bool boolean)
    {
      UseAllEnemies = boolean;
    }
    public override DataElement Clone()
    {
      return new MatchUseAllEnemies(useAllEnemies);
    }
  }
}