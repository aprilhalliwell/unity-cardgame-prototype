using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using DefaultNamespace;
using gameplay.card.data.rendering;
using gameplay.effects;

namespace gameplay.match.EntityData
{
  public class EntityDiscardData : VersionedDataElement
  {
    private PileLocation discardLocation;

    public Stack<ElementComposition> Discard { get; private set; }  = new Stack<ElementComposition>();
    public EntityDiscardData(PileLocation discardLocation)
    {
      this.discardLocation = discardLocation;
    }

    public Stack<ElementComposition> RecycleDiscard()
    {
      var cardsToReturn = new Stack<ElementComposition>(Discard);
      Discard.Clear();
      return cardsToReturn;
    }

    
    public IEnumerator AddToDiscard(ElementComposition card)
    {
      if (composition.Get<EntityHandData>().IsCardInHand(card))
      {
        composition.Get<EntityHandData>().RemoveCardFromHand(card);
      }
      composition.Get<EntityPresentData>().RemoveFromPile(card);

      //add card to discard
      
      yield return new SpawnAtAndMoveToLocationCommand(card,discardLocation.cardPrefab,card.Get<GameObjectData>().Transform,discardLocation.ToLocation.transform);
      Discard.Push(card);
      markDirty();
    }
    public IEnumerator MoveAndRemoveFromGame(ElementComposition card)
    {
      if (composition.Get<EntityHandData>().IsCardInHand(card))
      {
        composition.Get<EntityHandData>().RemoveCardFromHand(card);
      }
      composition.Get<EntityPresentData>().RemoveFromPile(card);

      yield return new SpawnAtAndMoveToLocationCommand(card,discardLocation.cardPrefab,card.Get<GameObjectData>().Transform,discardLocation.ToLocation.transform);
      markDirty();
    }

  }
}