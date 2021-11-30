using System.Collections.Generic;
using Assets.Data;
using Assets.Scheme.Traits;
using gameplay.enums;

namespace gameplay.card.data.rendering
{
    public class CardDataCost : VersionedDataElement
    {
        public List<ResourceCost> Costs;   
        public CardDataCost(ResourceTrait resourceTrait)
        {
            Costs = resourceTrait.Items;
        }

        public void updateCost(ResourceTypes resourceTypes,int cost)
        {
            Costs.Find(x => x.ResourceTypes == resourceTypes).Cost = cost;
            markDirty();
        }
    }
}