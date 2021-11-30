using System.Collections;
using System.Runtime.InteropServices;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;

namespace gameplay.commands
{
  public class GrantStaminaCommand : Command
  {
    private ElementComposition composition;
    private Targets target;
    private int amount;
    public GrantStaminaCommand(ElementComposition composition, Targets target, int amount)
    {
      this.composition = composition;
      this.target = target;
      this.amount = amount;
    }
    public override IEnumerator execute()
    {
      composition.Get<EntityStaminaData>().CurrentStamina += amount;
      yield break;
    }
  }
}