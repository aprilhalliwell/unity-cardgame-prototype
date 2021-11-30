using Assets.Data;
using gameplay.enemies.data;
using UnityEngine;
using UnityEngine.UI;

namespace gameplay.rendering
{
  public class EnemyShadowTarget : VersionedDataBehaviour<EnemyDataInteractiveState>
  {
    [SerializeField] private Image image;
    protected override void awake()
    {
      if (image == null)
      {
        image = GetComponent<Image>();
      }
    }

    protected override void dirtyUpdate()
    {
      if (component.State == PileInteractiveStates.Hovering || component.State == PileInteractiveStates.HoveringWithCard)
      {
        image.enabled = true;
      }
      else
      {
        image.enabled = false;
      }
    }
  }
}