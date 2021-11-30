using Assets.Data;
using Assets.Scheme.Traits;

namespace gameplay.card.data.rendering
{
    public class CardDataText : VersionedDataElement
    {
        public string GameText;   
        public CardDataText(StringTrait stringTrait)
        {
            GameText = stringTrait.Text;
        }

        public void Update(string text)
        {
            GameText = text;
            markDirty();
        }
    }
}