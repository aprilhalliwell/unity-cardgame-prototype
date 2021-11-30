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
  public class SpriteTrait : Trait
  {
    /// <summary>
    /// Internal image used for caching results
    /// </summary>
    [NonSerialized]
    private Sprite image;
    /// <summary>
    /// Loaded ImagePath texture
    /// </summary>
    public Sprite Image
    {
      get
      {
        if(image == null && ImagePath != null)
        {
          Sprite[] sprites = Resources.LoadAll<Sprite>(ImagePath);
          if (!string.IsNullOrEmpty(SpriteName))
          {
            try
            {
              image = sprites.First(x => x.name == SpriteName);
            }
            catch
            {
              image = null;
            }
          }
          else
          {
            image = sprites[0];
          }
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
    public string SpriteName;
    /// <summary>
    /// Initializes the imagePath
    /// </summary>
    /// <param name="imagePath">Resources path to the image</param>
    public SpriteTrait(string imagePath,string spriteName)
    {
      this.SpriteName = spriteName;
      this.ImagePath = imagePath;
    }
  }
}
