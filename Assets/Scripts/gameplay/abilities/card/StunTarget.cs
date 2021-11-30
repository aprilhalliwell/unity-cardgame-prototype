using System.Collections;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.commands;
using gameplay.enums;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
  public class StunTarget : CardAbility
  {
    private Targets target;
    private int amount;
    private int index;
    public StunTarget(Targets target,  int amount) : base()
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
      yield return new StunTargetCommand(composition, target, amount);
    }
  }
}