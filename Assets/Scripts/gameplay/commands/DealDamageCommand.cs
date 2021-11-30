using System.Collections;
using Assets.Data;
using core.animations;
using core.CoroutineExecutor;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;

namespace gameplay.commands
{
  public class DealDamageCommand : Command
  {
    private ElementComposition composition;
    private Targets target;
    private int amount;
    private string resource;
    public DealDamageCommand(ElementComposition composition, Targets target, int amount)
    {
      this.composition = composition;
      this.target = target;
      this.amount = amount;
      this.resource = resource;
    }
    public override IEnumerator execute()
    {
      composition.Get<EntityHealthData>().DealDamage(amount);
      yield break;
    }
  }
}