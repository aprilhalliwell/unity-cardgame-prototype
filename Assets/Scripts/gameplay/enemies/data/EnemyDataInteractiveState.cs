using Assets.Data;

namespace gameplay.enemies.data
{
  public class EnemyDataInteractiveState : VersionedDataElement
  {
    public PileInteractiveStates State { get; private set; }

    public EnemyDataInteractiveState(PileInteractiveStates state)
    {
      State = state;
    }

    public void UpdateState(PileInteractiveStates state)
    {
      State = state;
      markDirty();
    }
  }
}