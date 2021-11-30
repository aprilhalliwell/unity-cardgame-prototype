using System;
using System.Collections;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.commands;
using gameplay.enums;
using UnityEngine;

namespace gameplay.abilities.enemy
{
  public class DealDamage : EnemyAbility
  {
    private Targets target;
    private int amount;
    public DealDamage(Targets target, int amount) : base()
    {
      this.target = target;
      this.amount = amount;
    }

    public override string Indicate()
    {
      return "DamageIcon";
    }
    public override int? IndicateAmount()
    {
      return amount;
    }
    public override IEnumerator Apply(ElementComposition composition)
    {
      var animator = composition.Get<GameObjectData>().Transform.gameObject.GetComponentInChildren<Animator>();
      while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
      {
        animator.SetTrigger("Attack");
        yield return null;
      }
      yield return new DealDamageCommand(state.playerComposition, target, amount);
      while (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
      {
        yield return null;
      }
    }
  }
}