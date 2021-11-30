using Assets.Data;
using gameplay.enums;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;
using UnityEngine;

namespace gameplay.match.rendering
{
  public class ShouldShowResourceRenderer : VersionedDataBehaviour<EntityValidResources>
  {
    public ResourceTypes ResourceType;
    protected override void dirtyUpdate()
    {
      if (component != null)
      {

        if (component.ValidResources.Contains(ResourceType))
        {
          gameObject.SetActive(true);
        }
        else
        {
          gameObject.SetActive(false);
        }
      }
    }
  }
}