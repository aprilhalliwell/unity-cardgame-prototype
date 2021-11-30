using System.Collections;
using Assets.Data;
using gameplay.enums;

namespace gameplay.abilities.card
{
    public class ConsumeResource : CardAbility
    {
        private int amount;
        private ResourceTypes type;

        public override bool Validate(ElementComposition target)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerator Apply(ElementComposition composition)
        {
            yield break;
        }
    }
}