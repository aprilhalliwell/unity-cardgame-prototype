using Assets.Data;
using Assets.Scheme.Traits;

namespace world.match.data
{
  public class MatchHealthPool : VersionedDataElement
  {
    private int health;

    public int Health
    {
      get => health;
      set
      {
        health = value;
        markDirty();
      }
    }

    public MatchHealthPool(IntTrait health)
    {
      Health = health.Amount;
    }
    public MatchHealthPool(int health)
    {
      Health = health;
    }
    public override DataElement Clone()
    {
      return new MatchHealthPool(health);
    }
  }
}