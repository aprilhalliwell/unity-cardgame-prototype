using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Data;
using core.CoroutineExecutor;
using DefaultNamespace;
using gameplay.commands;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
  public class DealDamageToTwoRandom : CardAbility
  {
    private int maxRandomTarget = 2;
    private Targets target;
    private int amount;
    private string resource;
    public DealDamageToTwoRandom(Targets target,  int amount) : base()
    {
      this.target = target;
      this.amount = amount;
    }

    public override bool Validate(ElementComposition target)
    {
      return target.Get<EntityTargetData>().Target == this.target;
    }

    public override IEnumerator Apply(ElementComposition composition)
    {
      var allEnemies = Finder.Find<MatchState>().enemyCompositions;
      var damageCommands = new List<IEnumerator>();
      var id = composition.Get<EntityIDData>().Slot;
      yield return new DealDamageCommand(composition, target, amount);
      int currentRandomTargets = 0;
      foreach (var enemy in allEnemies.Values.ToList().Shuffle())
      {
        if(maxRandomTarget <= currentRandomTargets) continue;
        if (enemy.Get<EntityIDData>().Slot != id)
        {
          currentRandomTargets++;
          damageCommands.Add(new DealDamageCommand(enemy, target, amount));
        }
      }
      foreach (var damageCommand in damageCommands)
      {
        yield return damageCommand;
      }
    }
  }
}