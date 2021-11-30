
using System.IO;
using UnityEngine;

namespace Assets.Scheme
{
  /// <summary>
  /// Base scheme class. 
  /// Schemes are collections of traits that define specific pieces of data for a given thing.
  /// </summary>
  public abstract class Scheme
  {
    /// <summary>
    /// Base constructor
    /// </summary>
    public Scheme()
    {
    }
    /// <summary>
    /// Saves a scheme to disk.
    /// </summary>
    /// <param name="name">Name of the scheme to save</param>
    public void SaveScheme(string name)
    {
      var json = JsonUtility.ToJson(this, true);
      var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/" + name + ".json");
      sr.Write(json);
      sr.Close();
    }
  }
}
