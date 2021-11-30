using System.Collections.Generic;
using Assets.Data;
using core.Data.elements;
using UnityEngine;

namespace core.renderManager
{
    public class RenderProvider : MonoBehaviour, IRenderProvider
    {
        
        public GameObject Prefab;
        public void GetCards(Dictionary<ElementComposition, VisibilityConfig> cards)
        {
            foreach (var card in cards)
            {
                if (card.Value.Show)
                {
                    
                }
            }
        }
    }
}