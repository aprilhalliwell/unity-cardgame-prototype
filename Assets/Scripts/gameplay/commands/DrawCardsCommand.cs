using System.Collections;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;

namespace gameplay.commands
{
  public class DrawCardsCommand : Command
  {
    private ElementComposition composition;
    private Targets target;
    private int amount;
    public DrawCardsCommand(ElementComposition composition, Targets target, int amount)
    {
      this.composition = composition;
      this.target = target;
      this.amount = amount;
    }
    public override IEnumerator execute()
    {
      yield return composition.Get<EntityDeckData>().DrawCard(amount);
    }
  }
}