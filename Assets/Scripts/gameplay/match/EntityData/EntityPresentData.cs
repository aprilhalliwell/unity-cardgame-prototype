using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using DefaultNamespace;
using gameplay.card.data.rendering;
using gameplay.effects;
using UnityEngine;

namespace gameplay.match.EntityData
{
  public class EntityPresentData : VersionedDataElement
  {
    private PileLocation presentLocation;

    public ElementComposition PresentCard { get; private set; }
    public EntityPresentData(PileLocation presentLocation)
    {
      this.presentLocation = presentLocation;
    }

    public void RemoveFromPile(ElementComposition card)
    {
      if (PresentCard != null)
      {
        if (PresentCard.Get<CardDataID>().CardID == card.Get<CardDataID>().CardID)
        {
          PresentCard = null;
          markDirty();
        } 
      }
    }
    public IEnumerator AddToPile(ElementComposition card)
    {
      if (composition.Get<EntityHandData>().IsCardInHand(card))
      {
        composition.Get<EntityHandData>().RemoveCardFromHand(card);
      }


      yield return new SpawnAtAndMoveToLocationCommand(card,presentLocation.cardPrefab,card.Get<GameObjectData>().Transform,presentLocation.ToLocation.transform);
      //add card to Pile
      PresentCard =  card;
      markDirty();
    }
  }
}