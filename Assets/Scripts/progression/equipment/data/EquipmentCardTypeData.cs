using Assets.Data;

namespace progression.equipment.data
{
  public class EquipmentCardTypeData: VersionedDataElement
  {
    public CardBundleTypes CardBundleType;

    public EquipmentCardTypeData(CardBundleTypes cardBundleType)
    {
      CardBundleType = cardBundleType;
    }
  }
}