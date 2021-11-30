using Assets.Data;
using Assets.Scheme.Traits;

namespace gameplay.card.data.rendering
{
    public class CardDataName : VersionedDataElement
    {
        public string CardName;   
        public CardDataName(StringTrait stringTrait)
        {
            CardName = stringTrait.Text;
        }

        public void updateCardName(string name)
        {
            CardName = name;
            markDirty();
        }
    }
}