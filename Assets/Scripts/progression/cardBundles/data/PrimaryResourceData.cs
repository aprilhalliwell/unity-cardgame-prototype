using Assets.Data;
using gameplay.enums;
using player.data;

namespace progression.cardBundles.data
{
  public class PrimaryResourceData: DataElement
  {
    public ResourceTypes PrimaryResource;

    
    public PrimaryResourceData(ResourceTypes primary)
    {
      PrimaryResource = primary;
    }

    public override DataElement Clone()
    {
      return new PrimaryResourceData(PrimaryResource);
    }
  }
}