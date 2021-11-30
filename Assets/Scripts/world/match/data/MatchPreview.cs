using Assets.Data;
using Assets.Scheme.Traits.BaseTraits;
using UnityEngine;

namespace world.match.data
{
  public class MatchPreview : VersionedDataElement
  {
    public Sprite Image;

    public MatchPreview(SpriteTrait textureTrait)
    {
      Image = Resources.Load<Sprite>(textureTrait.ImagePath);
    }
    public MatchPreview(Sprite sprite)
    {
      Image = sprite;
    }


    public void Update(Sprite sprite)
    {
      Image = sprite;
      markDirty();
    }
    
    public override DataElement Clone()
    {
      return new MatchPreview(Image);
    }
  }
}