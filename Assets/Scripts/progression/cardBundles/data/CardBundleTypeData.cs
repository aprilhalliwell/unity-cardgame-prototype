using Assets.Data;
using gameplay.enums;

namespace progression.cardBundles.data
{
  public class CardBundleTypeData: DataElement
  {
    public CardBundleTypes CardBundleType;

    
    public CardBundleTypeData(CardBundleTypes cardBundleType)
    {
      this.CardBundleType = cardBundleType;
    }

    public override DataElement Clone()
    {
      return new CardBundleTypeData(CardBundleType);
    }
  }
}