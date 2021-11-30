using System.Linq;
using Assets.Data;
using Assets.Scheme.Traits.BaseTraits;
using gameplay.enums;
using UnityEngine;

namespace gameplay.card.data.rendering
{
    public class CardDataImage : VersionedDataElement
    {
        public Sprite Image;   
        public CardDataImage(SpriteTrait textureTrait)
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

        public void Update(Sprite sprite)
        {
            Image = sprite;
            markDirty();
        }
        
    }
}