using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameplay.enums;

namespace Assets.Scheme.Traits.BaseTraits
{
  
  [Serializable] 
  public class Ability
  {
    public string ScriptName;
    public int Amount;
    public Targets Target;
  }
  /// <summary>
  /// Represents a float
  /// </summary>
  [Serializable]
  public class AbilityListTrait : Trait
  {
    /// <summary>
    /// Amount based on Json File
    /// </summary>
    public List<Ability> Items;
    /// <summary>
    /// Initializes Amount
    /// </summary>
    /// <param name="Amount">Amount to set</param>
    public AbilityListTrait(List<Ability> Items)
    {
      this.Items = Items;
    }
  }
}
