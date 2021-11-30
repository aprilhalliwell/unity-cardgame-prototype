using Assets.Data;
using gameplay.enemies.data;
using gameplay.mixingTable.data;
using UnityEngine;
using UnityEngine.UI;

namespace gameplay.rendering
{
  public class MixingSlotSelectionTarget : VersionedDataBehaviour<MixingSlotInteractiveStateData>
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
      if (component.State == PileInteractiveStates.HoveringWithCard)
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