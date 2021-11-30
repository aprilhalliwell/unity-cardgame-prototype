using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.commands;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;

namespace gameplay.abilities.card
{
  public class StunAll : CardAbility
  {
    private Targets target;
    private int amount;
    private int index;
    public StunAll(Targets target,  int amount) : base()
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
      var allEnemies = Finder.Find<MatchState>().enemyCompositions;
      var damageCommands = new List<IEnumerator>();
      foreach (var enemy in allEnemies)
      {
        damageCommands.Add(new StunTargetCommand(enemy.Value, target, amount));
      }
      foreach (var damageCommand in damageCommands)
      {
        yield return damageCommand;
      }
    }
  }
}