using System.Collections;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.commands;
using gameplay.enums;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
    public class Shield_Per_Turn : CardAbility
    {
        private Targets target;
        private int amount;
        private int index;
        public Shield_Per_Turn(Targets target,  int amount) : base()
        {
            this.index = index;
            this.target = target;
            this.amount = amount;
        }

        public override bool Validate(ElementComposition target)
        {
            return target.Get<EntityTargetData>().Target == this.target;
        }

        public override IEnumerator Apply(ElementComposition composition)
        {
            yield return new GainBlockCommand(composition, target, amount);
        }
    }
}