using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameplay.enums;

namespace Assets.Scheme.Traits
{
  
  
  [Serializable] 
  public class ResourceCost
  {
    public ResourceTypes ResourceTypes;
    public int Cost;
  }
  
  /// <summary>
  /// Represents a string 
  /// </summary>
  [Serializable]
  public class ResourceTrait : Trait
  {

    public List<ResourceCost> Items;
    /// <summary>
    /// Initializes Text
    /// </summary>
    /// <param name="Text">Text to set</param>
    public ResourceTrait(List<ResourceCost> Items)
    {
      this.Items = Items;
    }
  }
}
