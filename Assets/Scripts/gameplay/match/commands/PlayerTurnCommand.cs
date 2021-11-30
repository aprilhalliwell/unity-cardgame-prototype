using System.Collections;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.match.data;
using gameplay.match.EntityData;
using world.commands;

namespace gameplay.match.commands
{
  public class PlayerTurnCommand : Command
  {
    public override IEnumerator execute()
    {
      var matchState = Finder.Find<MatchState>();
      //At the start of the turn draw 5 cards
      yield return matchState.playerComposition.Get<EntityDeckData>().DrawCard(5);
      //gain 4 stamina
      matchState.playerComposition.Get<EntityStaminaData>().CurrentStamina += 4;
      matchState.matchComposition.Get<MatchDataPhase>().Phase = Phases.PlayerTurn;
    }
  }
}