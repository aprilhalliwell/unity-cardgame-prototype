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
  public class EquipmentTypesTrait : Trait
  {

    public EquipmentTypes EquipmentType;
    /// <summary>
    /// Initializes Text
    /// </summary>
    /// <param name="Text">Text to set</param>
    public EquipmentTypesTrait(EquipmentTypes equipmentType)
    {
      this.EquipmentType = equipmentType;
    }
  }
}
