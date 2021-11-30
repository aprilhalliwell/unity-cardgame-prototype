using System.Collections;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.match.data;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.match.commands
{
  public class EnemyTurnCommand : Command
  {
    public override IEnumerator execute()
    {
      var matchState = Finder.Find<MatchState>();
      matchState.matchComposition.Get<MatchDataPhase>().Phase = Phases.EnemyTurn;
      var discard = matchState.playerComposition.Get<EntityHandData>().DiscardHand().Execute();
      var Enemies = matchState.enemyCompositions;
      
      foreach (var enemy in Enemies)
      {
        if (enemy.Value.Get<EntityHealthData>().CurrentHealth > 0)
        {
          yield return enemy.Value.Get<EnemyAbilityData>().ApplyAbilities(); //todo any affects and wait for them here
        }
      }
      yield return new WaitForSeconds(1);
      yield return discard;
      if (matchState.playerComposition.Get<EntityHealthData>().CurrentHealth <= 0)
      {
        //ded 
        new EndMatchCommand().Execute();
      }
      else
      {
        new PlayerTurnCommand().Execute();
      }
    }
  }
}