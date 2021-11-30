using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Data;
using core.CoroutineExecutor;
using core.scene;
using DefaultNamespace;
using gameplay.abilities;
using gameplay.abilities.card;
using gameplay.abilities.enemy;
using gameplay.card.data.rendering;
using gameplay.commands;
using gameplay.enemies.data;
using gameplay.enums;
using gameplay.match.commands;
using gameplay.match.data;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;
using gameplay.mixingTable.data;
using gameplay.rendering;
using gameplay.room;
using player.data;
using progression.cardBundles.data;
using UnityEngine;
using UnityEngine.SceneManagement;
using world;
using world.commands;
using world.match.data;
using world.room.data;
using Random = System.Random;

namespace gameplay.match
{
  public class MatchState : MonoBehaviour
  {
    public ElementComposition matchComposition;
    public ElementComposition playerComposition;
    public Dictionary<int,ElementComposition> enemyCompositions;
    public PileLocations locations;
    private MatchDataPhase phaseData;
    void Awake()
    {
      locations = GetComponent<PileLocations>();
      Debug.Log("Creating Match");
    }

    public void WinMatch()
    {
      new WinMatchCommand().Execute();
    }

    public void EndTurn()
    {
      if (phaseData.Phase == Phases.PlayerTurn)
      {
        phaseData.Phase = Phases.EnemyTurn;

        var anyEnemiesAlive = false;
        foreach (var enemy in enemyCompositions)
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
        else
        {
          new EnemyTurnCommand().Execute();
        }
      }
    }
    
    public void CreateMatch( ElementComposition match)
    {
      var world = Finder.Find<GameWorld>();
      var cardsList = world.Player.EquippedCards.Values.SelectMany(x=>x.Get<CardItemsData>().Data).ToList();
      var potentialEnemies = match.Get<MatchPotentialEnemies>().PotentialEnemies;
      enemyCompositions = new Dictionary<int, ElementComposition>(potentialEnemies.Count);
      var maxPoints = match.Get<MatchHealthPool>().Health;
      var minHealthSize = potentialEnemies.Min(x => x.Health.Amount);
      Random rnd = new Random();
      var slot = 0;
      while (minHealthSize < maxPoints)
      {
        var idx = rnd.Next(0, potentialEnemies.Count);
        var enemy = potentialEnemies[idx];
        if (maxPoints - enemy.Health.Amount > 0)
        {
          enemyCompositions.Add(slot, MatchFactories.CreateEnemies(enemy,slot));
          maxPoints -= enemy.Health.Amount;
          slot++;
        }
      }
      List<ElementComposition> cards = new List<ElementComposition>(cardsList.Count);
      foreach (var cardScheme in cardsList)
      {
        cards.Add(MatchFactories.CreateCard(cardScheme,false));
      }
      playerComposition = MatchFactories.CreatePlayer(cards, locations);
      playerComposition.Get<EntityDeckData>().DrawCard(5).Execute();
      matchComposition = new ElementComposition( new MatchCardDragData(), new MatchDataPhase(Phases.PlayerTurn));
      phaseData = matchComposition.Get<MatchDataPhase>();
    }

    public static ElementComposition RandomEnemyComposition()
    {
      return Finder.Find<MatchState>().enemyCompositions.Values.ToList().Shuffle()
        .Where(x => x.Get<EntityHealthData>().CurrentHealth > 0)
        .ToList()[0];
    }
    public static ElementComposition MatchComposition()
    {
      var go = Finder.Find<MatchState>();
      return go.matchComposition;
    }
    public static ElementComposition PlayerComposition()
    {
      var go = Finder.Find<MatchState>();
      return go.playerComposition;
    }
  }
}