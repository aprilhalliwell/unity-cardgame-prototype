using System.Collections.Generic;
using Assets.Data;
using gameplay.enums;

namespace gameplay.match.EntityData
{
  public class EntityValidResources: VersionedDataElement
  {
    public List<ResourceTypes> ValidResources;

    public EntityValidResources(List<ResourceTypes> validResources)
    {
      this.ValidResources = validResources;
    }
  }
}