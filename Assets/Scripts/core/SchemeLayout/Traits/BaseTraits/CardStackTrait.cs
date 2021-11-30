using System;
using Assets.Scheme;
using gameplay.enums;
using UnityEditor;
using UnityEngine;

namespace core.SchemeLayout.Traits.BaseTraits
{
  [Serializable]
  public class CardStackTrait :Trait
  {
    public CardScheme cardScheme = new CardScheme();
    public PredicateType predicate;
    public NoopCardPredicate noopPredicate;
    public TemperatureCardPredicate tempPredicate;
    public IngredientCardPredicate ingPredicate;

    public ICardPredicate GetPredicate()
    {
      if (tempPredicate != null) return tempPredicate;
      if (ingPredicate != null) return ingPredicate;
      return new NoopCardPredicate();
    }
  }

  public interface ICardPredicate
  {
    
  }
  [Serializable]
  public class NoopCardPredicate : ICardPredicate
  {
  }
  [Serializable]
  public class TemperatureCardPredicate : ICardPredicate
  {
    public int TemperatureMin;
    public int TemperatureMax;
  }
  [Serializable]
  public class IngredientCardPredicate : ICardPredicate
  {
    public Ingredients slot1;
    public Ingredients slot2;
    public Ingredients slot3;
  }
}