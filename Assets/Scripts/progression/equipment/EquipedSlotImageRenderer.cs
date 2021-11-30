using Assets.Data;
using core.Data.elements;
using progression.equipment.data;
using UnityEngine.UI;

namespace progression.equipment
{
  public class EquipedSlotImageRenderer: VersionedDataBehaviour<EquipedSlotData>
  {
    public Image MissingItemImage;
    public Image EquipedImage;


    protected override void dirtyUpdate()
    {
      if (component.EquipedItem != null)
      {
        EquipedImage.enabled = true;
        MissingItemImage.enabled = false;
        EquipedImage.sprite = component.EquipedItem.Get<ImageData>().Image;
      }
      else
      {
        EquipedImage.enabled = false;
        MissingItemImage.enabled = true;
      }
    }
  }
}