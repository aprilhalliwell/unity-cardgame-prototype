using Assets.Data;

namespace player.data
{
  public class ExperienceData : VersionedDataElement
  {
    private int experience;

    public int Experience
    {
      get => experience;
      set
      {
        experience = value;
        markDirty();
      }
    }
    
    public ExperienceData(int experience)
    {
      this.experience = experience;
    }

    public override DataElement Clone()
    {
      return new ExperienceData(experience);
    }
  }
}