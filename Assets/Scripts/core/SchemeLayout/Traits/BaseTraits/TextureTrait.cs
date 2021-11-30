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
  public class TextureTrait : Trait
  {
    /// <summary>
    /// Internal image used for caching results
    /// </summary>
    [NonSerialized]
    private Texture image;
    /// <summary>
    /// Loaded ImagePath texture
    /// </summary>
    public Texture Image
    {
      get
      {
        if(image == null)
        {
          image = Resources.Load<Texture>(ImagePath);
        }
        return image;
      }
      set
      {
        image = value;
      }
    }
    /// <summary>
    /// Resoruces path to the image
    /// </summary>
    public string ImagePath;
    /// <summary>
    /// Initializes the imagePath
    /// </summary>
    /// <param name="imagePath">Resources path to the image</param>
    public TextureTrait(string imagePath)
    {
      this.ImagePath = imagePath;
    }
  }
}
