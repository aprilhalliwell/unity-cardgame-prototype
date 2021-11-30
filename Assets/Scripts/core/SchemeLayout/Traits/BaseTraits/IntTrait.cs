using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scheme.Traits
{
  /// <summary>
  /// Represents an interger
  /// </summary>
  [Serializable]
  public class IntTrait : Trait
  {
    /// <summary>
    /// Amount based on Json File
    /// </summary>
    public int Amount;
    /// <summary>
    /// Initializes Amount
    /// </summary>
    /// <param name="Amount">Amount to set</param>
    public IntTrait(int Amount)
    {
      this.Amount = Amount;
    }
  }
}
