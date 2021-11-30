using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scheme.Traits.BaseTraits
{
  /// <summary>
  /// Represents a texture and loads it from resources.
  /// </summary>
  [Serializable]
  public class PrefabTrait : Trait
  {
    /// <summary>
    /// Internal image used for caching results
    /// </summary>
    [NonSerialized]
    private GameObject prefab;
    /// <summary>
    /// Loaded ImagePath texture
    /// </summary>
    public GameObject Prefab
    {
      get
      {
        if(prefab == null)
        {
          prefab = Resources.Load<GameObject>(PrefabPath);
        }
        return prefab;
      }
      set
      {
        prefab = value;
      }
    }
    /// <summary>
    /// Resoruces path to the image
    /// </summary>
    public string PrefabPath;
    /// <summary>
    /// Initializes the imagePath
    /// </summary>
    /// <param name="imagePath">Resources path to the image</param>
    public PrefabTrait(string prefabPath)
    {
      this.PrefabPath = prefabPath;
    }
  }
}
