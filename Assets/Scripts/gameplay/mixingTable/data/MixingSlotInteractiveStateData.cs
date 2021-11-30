using Assets.Data;

namespace gameplay.mixingTable.data
{
  public class MixingSlotInteractiveStateData : VersionedDataElement
  {
    public PileInteractiveStates State { get; private set; }

    public MixingSlotInteractiveStateData(PileInteractiveStates state)
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