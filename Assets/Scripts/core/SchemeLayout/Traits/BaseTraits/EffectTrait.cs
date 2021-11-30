using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scheme.Traits
{
  /// <summary>
  /// Represents a string 
  /// </summary>
  [Serializable]
  public class EffectTrait : Trait
  {
    /// <summary>
    /// Text based on Json File
    /// </summary>
    public string Text;
    /// <summary>
    /// Initializes Text
    /// </summary>
    /// <param name="Text">Text to set</param>
    public EffectTrait(string Text)
    {
      this.Text = Text;
    }
  }
}
