using System;
using Assets.Data;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using UnityEngine;

public class RoomDataImage : VersionedDataElement
{
  public Sprite Image;

  public RoomDataImage(SpriteTrait textureTrait)
  {
    Image = Resources.Load<Sprite>(textureTrait.ImagePath);
  }
  public RoomDataImage(Sprite image)
  {
    Image = image;
  }
  public override DataElement Clone()
  {
    return new RoomDataImage(Image);
  }

  public void Update(Sprite sprite)
  {
    Image = sprite;
    markDirty();
  }
}