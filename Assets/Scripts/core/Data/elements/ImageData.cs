using System.Linq;
using Assets.Data;
using Assets.Scheme.Traits.BaseTraits;
using UnityEngine;

namespace core.Data.elements
{
  public class ImageData : VersionedDataElement
  {
    public Sprite Image;

    public ImageData(SpriteTrait textureTrait)
    {
      if (string.IsNullOrEmpty(textureTrait.SpriteName))
      {
        Image = Resources.Load<Sprite>(textureTrait.ImagePath);
      }
      else
      {
        Sprite[] sprites = Resources.LoadAll<Sprite>(textureTrait.ImagePath);
        Image = sprites.First(x => x.name == textureTrait.SpriteName);
      }
    }
    public ImageData(Sprite image)
    {
      Image = image;
    }
    public override DataElement Clone()
    {
      return new ImageData(Image);
    }

    public void Update(Sprite sprite)
    {
      Image = sprite;
      markDirty();
    }
  }
}