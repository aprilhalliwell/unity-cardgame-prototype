using System.Collections;
using Assets.Data;
using core.animations;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.commands;
using gameplay.enums;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
  public class DealDamage : CardAbility
  {
    private Targets target;
    private int amount;
    private int index;
    private string resource;
    public DealDamage(Targets target,  int amount) : base()
    {
      this.index = index;
      this.target = target;
      this.amount = amount;
      this.resource = resource;
    }

    public override bool Validate(ElementComposition target)
    {
      return target.Get<EntityTargetData>().Target == this.target;
    }

    public override IEnumerator Apply(ElementComposition composition)
    {
      yield return new DealDamageCommand(composition, target, amount);
    }
  }
}