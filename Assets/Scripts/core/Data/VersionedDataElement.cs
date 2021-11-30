using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Data
{
  /// <summary>
  /// Data Class used to store various kinds of elements
  /// </summary>
  public abstract class VersionedDataElement: DataElement
  {
    public ulong Version { get; set; }

    public void markDirty()
    {
      Version++;
    }
  }
}
