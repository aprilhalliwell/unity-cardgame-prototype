using System.Collections.Generic;
using Assets.Data;
using Assets.Scheme.Traits;
using core.SchemeLayout.Traits.BaseTraits;

namespace gameplay.card.data.rendering
{
    public class CardPredicateData : VersionedDataElement
    {
        public ICardPredicate Predicate;   
        public CardPredicateData(ICardPredicate predicate )
        {
            Predicate = predicate;
        }
    }
}