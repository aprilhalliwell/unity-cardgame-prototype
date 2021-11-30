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
  public class GrantEssenceCommand : Command
  {
    private ElementComposition composition;
    private Targets target;
    private int amount;
    public GrantEssenceCommand(ElementComposition composition, Targets target, int amount)
    {
      this.composition = composition;
      this.target = target;
      this.amount = amount;
    }
    public override IEnumerator execute()
    {
      composition.Get<EntityEssenceData>().CurrentEssence += amount;
      yield break;
    }
  }
}