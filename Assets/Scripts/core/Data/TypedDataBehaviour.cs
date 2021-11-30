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
  public abstract class TypedDataBehaviour<T> : DataBehaviour where T : DataElement
  {
    public T component;

    protected override void start()
    {
      component = data.Composition?.Get<T>();
      onModel();
    }

    protected virtual void onModel(){}
  }
}
