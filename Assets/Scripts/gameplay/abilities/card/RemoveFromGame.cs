using System.Collections;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.commands;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
    public class RemoveFromGame : CardAbility
    {
        private Targets target;
        private int amount;
        private int index;
        public RemoveFromGame(Targets target,  int amount) : base()
        {
            this.index = index;
            this.target = target;
            this.amount = amount;
        }

        public override bool Validate(ElementComposition target)
        {
            return true;
        }

        public override IEnumerator Apply(ElementComposition composition)
        {
            yield return new RemoveFromGameCommand(MatchState.PlayerComposition(), target, amount);
        }
    }
}