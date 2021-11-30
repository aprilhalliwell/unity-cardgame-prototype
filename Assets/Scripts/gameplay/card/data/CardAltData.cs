using System.Collections.Generic;
using Assets.Data;
using Assets.Scheme.Traits;

namespace gameplay.card.data.rendering
{
    public class CardAltData : VersionedDataElement
    {
        public List<ElementComposition> AltCards;   
        public CardAltData(List<ElementComposition> altCards )
        {
            AltCards = altCards;
        }
    }
}