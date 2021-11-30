using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Data
{
  /// <summary>
  /// Monobehaviour that exposes compositional data.
  /// </summary>
  abstract public class VersionedDataBehaviour<T> : TypedDataBehaviour<T> where T : VersionedDataElement
  {
    protected ulong cachedVersion = 0;

    protected virtual ulong Version => component?.Version ?? 0;

    protected virtual void dirtyUpdate(){}
    protected override void start()
    {
      base.start();
      dirtyUpdate();
    }

    /// <summary>
    /// Called after our data has been assigned, you can saftly get compositonal data.
    /// </summary>
    protected override void update()
    {
      if (component == null) return;
      if (Version != cachedVersion)
      {
        cachedVersion = Version;
        dirtyUpdate();
      }
    }
  }
}
