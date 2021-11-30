using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scheme.Traits.BaseTraits
{
  [Serializable] 
  public class AbilityOption
  {
    public string Option;
    public int Chance;
  }
  
  /// <summary>
  /// Represents a float
  /// </summary>
  [Serializable]
  public class ListAbilityOptionTrait : Trait
  {
    /// <summary>
    /// Amount based on Json File
    /// </summary>
    public List<AbilityOption> Options;
    /// <summary>
    /// Initializes Amount
    /// </summary>
    /// <param name="Amount">Amount to set</param>
    public ListAbilityOptionTrait(List<AbilityOption> Options)
    {
      this.Options = Options;
    }
  }
}
