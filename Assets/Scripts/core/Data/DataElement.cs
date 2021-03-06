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
  public abstract class DataElement
  {
    /// <summary>
    /// The Element Composition we are part of.
    /// Will contain other data elements that we can access
    /// </summary>
    protected ElementComposition composition;

    /// <summary>
    /// Attaches this Element to a Composition.
    /// </summary>
    /// <param name="composition">Our main composition</param>
    public void Attach(ElementComposition composition)
    {
      this.composition = composition;
      onAttach();
    }

    public virtual DataElement Clone()
    {
      return this.Copy();
    }


    /// <summary>
    /// Checks if our composition has a specific data element.
    /// </summary>
    /// <typeparam name="T">The kind of DataElement we want bacl</typeparam>
    /// <returns>Whether that data element exists within our composition</returns>
    public bool Has<T>() where T : DataElement
    {
      return composition.Has<T>();
    }

    /// <summary>
    /// Gets a data element from our composition, will throw if the element doesnt exist
    /// Logs a warning if <typeparamref name="T"/> is the current element. 
    /// </summary>
    /// <typeparam name="T">The type of element we want</typeparam>
    /// <returns> A Data Element <typeparamref name="T"/></returns>
    public T Get<T>() where T : DataElement
    {
      notSelf<T>();
      return (T)composition.Get<T>();
    }
    /// <summary>
    /// Logs a warning if we are looking for our self.
    /// </summary>
    /// <typeparam name="T">Data element</typeparam>
    void notSelf<T>() where T : DataElement
    {
      if(this.GetType() == typeof(T))
      {
        Debug.LogWarning("Looking in composition for self");
      }
    }
    /// <summary>
    /// Called after a data element is attached to the composition
    /// </summary>
    virtual protected void onAttach() { }
  }
}
