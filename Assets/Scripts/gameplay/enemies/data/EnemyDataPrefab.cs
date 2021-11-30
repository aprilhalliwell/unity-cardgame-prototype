using Assets.Data;
using Assets.Scheme.Traits.BaseTraits;
using gameplay.enums;
using UnityEngine;

namespace gameplay.card.data.rendering
{
    public class EnemyDataPrefab : DataElement
    {
        public GameObject Prefab;   
        public EnemyDataPrefab(PrefabTrait prefabTrait)
        {
            Prefab = Resources.Load<GameObject>(prefabTrait.PrefabPath);
        }
    }
}