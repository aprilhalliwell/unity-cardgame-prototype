using Assets.Data;
using Assets.Scheme.Traits.BaseTraits;
using gameplay.enums;
using UnityEngine;

namespace gameplay.card.data.rendering
{
    public class EnemyDataImage : VersionedDataElement
    {
        public Sprite Image;   
        public EnemyDataImage(TextureTrait textureTrait)
        {
            Image = Resources.Load<Sprite>(textureTrait.ImagePath);
        }

        public void Update(Sprite sprite)
        {
            Image = sprite;
            markDirty();
        }
        
    }
}