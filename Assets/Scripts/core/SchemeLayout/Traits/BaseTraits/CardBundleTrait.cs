using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameplay.enums;

namespace Assets.Scheme.Traits
{
  /// <summary>
  /// Represents a string 
  /// </summary>
  [Serializable]
  public class CardBundleTrait : Trait
  {

    public CardBundleTypes CardBundleType;
    /// <summary>
    /// Initializes Text
    /// </summary>
    /// <param name="Text">Text to set</param>
    public CardBundleTrait(CardBundleTypes cardBundleType)
    {
      this.CardBundleType = cardBundleType;
    }
  }
}
