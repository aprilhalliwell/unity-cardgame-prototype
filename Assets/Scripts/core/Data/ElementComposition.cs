using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Data
{
  /// <summary>
  /// A Collection of DataElements
  /// </summary>
  public class ElementComposition : IEnumerable<DataElement>
  {
    /// <summary>
    /// Map of type to data element
    /// </summary>
    Dictionary<Type,DataElement> elements = new Dictionary<Type, DataElement>();
    /// <summary>
    /// Given a Type T return a data element from this composition
    /// </summary>
    /// <param name="i">The Type we want</param>
    /// <returns>A DataElement T</returns>
    public DataElement this[Type i]
    {
      get { return elements[i]; }
      set { elements[i] = value; }
    }
    /// <summary>
    /// Constructor for the Composition.
    /// </summary>
    /// <param name="data">All initial data elements</param>
    public ElementComposition(params DataElement[] data)
    {
      foreach(var datum in data)
      {
        elements.Add(datum.GetType(), datum);
      }
      foreach (var datum in data)
      {
        datum.Attach(this);
      }
    }
    /// <summary>
    /// Checks if the composition has a given key
    /// </summary>
    /// <typeparam name="T">The type to check</typeparam>
    /// <returns>True if the composition contains the key, false otherwise</returns>
    public bool Has<T>() where T : DataElement
    {
      return elements.ContainsKey(typeof(T));
    }

    /// <summary>
    /// Gets a data element out of our composition
    /// </summary>
    /// <typeparam name="T">A Data Element</typeparam>
    /// <returns>A Data Element</returns>
    public T Get<T>() where T : DataElement
    {
      try
      {
        return (T) elements[typeof(T)];
      }
      catch (Exception e)
      {
        Debug.Log($"Could not get {typeof(T).FullName} from composition");
        throw e;
      }
    }

    /// <summary>
    /// Adds a data element to our composition.
    /// </summary>
    /// <typeparam name="T">The type to add</typeparam>
    /// <param name="element">An instance of Type T</param>
    public void Add<T>(T element) where T : DataElement
    {
      element.Attach(this);
      elements.Add(typeof(T), element);
    }
    
    public void Add(Type t, DataElement element)
    {
      element.Attach(this);
      elements.Add(t, element);
    }
    public ElementComposition Clone()
    {
      ElementComposition cloned = new ElementComposition();
      foreach (var dataElement in elements)
      {
        cloned.Add(dataElement.Key, dataElement.Value.Clone());
      }
      return cloned;
    }
    
    public IEnumerator<DataElement> GetEnumerator()
    {
      foreach (var dataElement in elements)
      {
        yield return dataElement.Value;
      }
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      foreach (var element in elements)
      {
        sb.Append(element.Key);
      }
      return sb.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}
