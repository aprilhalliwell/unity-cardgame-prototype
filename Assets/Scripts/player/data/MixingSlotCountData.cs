using Assets.Data;

namespace player.data
{
  public class MixingSlotCountData : VersionedDataElement
  {
    private int slots;

    public int Slots
    {
      get => slots;
      set
      {
        slots = value;
        markDirty();
      }
    }
    
    public MixingSlotCountData(int slots)
    {
      this.slots = slots;
    }

    public override DataElement Clone()
    {
      return new ExperienceData(slots);
    }
  }
}