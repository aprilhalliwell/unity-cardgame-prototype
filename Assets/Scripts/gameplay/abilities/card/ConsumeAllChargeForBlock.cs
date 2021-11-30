using System.Collections;
using Assets.Data;
using gameplay.commands;
using gameplay.enums;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
    public class ConsumeAllChargeForBlock : CardAbility
    {
        private Targets target;
        private int amount;
        private int index;
        public ConsumeAllChargeForBlock(Targets target,  int amount) : base()
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
            //use charge here
            var charge = state.playerComposition.Get<EntityChargeData>().CurrentCharge;
            yield return new GainBlockCommand(state.playerComposition, Targets.Player, amount * charge);
            //consume all charge here
            state.playerComposition.Get<EntityChargeData>().CurrentCharge = 0;
        }
    }
}