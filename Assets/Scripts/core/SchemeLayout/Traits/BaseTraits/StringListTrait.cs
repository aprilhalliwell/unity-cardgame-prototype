using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scheme.Traits.BaseTraits
{
  /// <summary>
  /// Represents a float
  /// </summary>
  [Serializable]
  public class StringListTrait : Trait
  {
    /// <summary>
    /// Amount based on Json File
    /// </summary>
    public List<string> Items;
    /// <summary>
    /// Initializes Amount
    /// </summary>
    /// <param name="Amount">Amount to set</param>
    public StringListTrait(List<string> Items)
    {
      this.Items = Items;
    }
  }
}
