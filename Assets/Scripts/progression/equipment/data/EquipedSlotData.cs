using Assets.Data;

namespace progression.equipment.data
{
  public class EquipedSlotData: VersionedDataElement
  {
    public ElementComposition EquipedItem;

    public EquipedSlotData(ElementComposition equipedItem)
    {
      EquipedItem = equipedItem;
    }

    public void UpdateEquipment(ElementComposition composition)
    {
      EquipedItem = composition;
      markDirty();
    }
  }
}