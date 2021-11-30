using Assets.Data;

namespace progression.equipment.data
{
  public class EquipmentItemTypeData: VersionedDataElement
  {
    public EquipmentTypes EquipmentType;

    public EquipmentItemTypeData(EquipmentTypes equipmentType)
    {
      EquipmentType = equipmentType;
    }
  }
}