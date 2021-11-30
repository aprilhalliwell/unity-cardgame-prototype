using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Assets.Data;
using core.CoroutineExecutor;
using DefaultNamespace;
using gameplay.effects;
using UnityEngine;

namespace gameplay.match.EntityData
{
  public class EntityDeckData : VersionedDataElement
  {
    private Stack<ElementComposition> deck;
    private PileLocation deckLocation;
    public EntityDeckData(List<ElementComposition> cards, PileLocation deckLocation)
    {
      this.deckLocation = deckLocation;
      deck = new Stack<ElementComposition>(cards);
      Shuffle();
    }

    public void Shuffle()
    {
      deck.Shuffle();
      markDirty();
    }

    public IEnumerator DrawCard(int amount)
    {
      List<Command> runningMoveCommands = new List<Command>();
      int count = 0;
      while (amount != count)
      {
        var hand = composition.Get<EntityHandData>();
        if (hand.CurrentHandSize + runningMoveCommands.Count < hand.MaxHandSize )
        {
          if (deck.Count == 0)
          {
            //if we are at 0 cards than we need to shuffle our discard back into our deck
            deck = composition.Get<EntityDiscardData>().RecycleDiscard();
            Shuffle();
          }
          var card = deck.Pop();
          //spawn card and move to hand 
          if (deckLocation != null)
          {
            runningMoveCommands.Add(
              new SpawnAndMoveToLocationCommand(card, deckLocation.cardPrefab, deckLocation.transform,
                deckLocation.ToLocation.transform).Then(() => hand.AddCardToHand(card)).asCommand());
          }
        }
        count++;
      }

      var waitForAllMoves = true;
      while (waitForAllMoves)
      {
        waitForAllMoves = false;
        foreach (var enumerator in runningMoveCommands)
        {
          if (!enumerator.Completed())
          {
            enumerator.MoveNext();
            waitForAllMoves = true;
          }
        }
        yield return null;
      }
    }
  }
}