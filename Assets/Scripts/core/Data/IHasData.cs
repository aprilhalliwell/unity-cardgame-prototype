using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data
{
  /// <summary>
  /// Interface to insure that we have compositional data
  /// </summary>
  public interface IHasData
  {
    /// <summary>
    /// Composition containing all data related to this 
    /// </summary>
    ElementComposition Composition
    {
      get;
    }
  }
}
