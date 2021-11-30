using System.Collections;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.match.data;
using gameplay.match.EntityData;
using world.commands;

namespace gameplay.match.commands
{
  public class CheckAndEndGameCommand : Command
  {
    public override IEnumerator execute()
    {
      var matchState = Finder.Find<MatchState>();
      var anyEnemiesAlive = false;
      foreach (var enemy in matchState.enemyCompositions)
      {
        if (enemy.Value.Get<EntityHealthData>().CurrentHealth > 0)
        {
          anyEnemiesAlive = true;
        }
      }
      if (!anyEnemiesAlive)
      {
        //won
        new WinMatchCommand().Execute();
      }
      yield break;
    }
  }
}