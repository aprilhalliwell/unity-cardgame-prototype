using System;
using System.Collections.Generic;
using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.match.rendering
{
  public class EntityPresentPile : VersionedDataBehaviour<EntityPresentData>
  {
    [SerializeField] Card cardPrefab;
    private Guid previousID;
    GameObject presentCard;

    private void CleanUpCard()
    {
      previousID = Guid.Empty;
      Destroy(presentCard);
      presentCard = null;
    }

    protected override void dirtyUpdate()
    {
      if (component.PresentCard == null)
      {
        CleanUpCard();
      }

      if (component.PresentCard != null)
      {
        var newID = component.PresentCard.Get<CardDataID>().CardID;
        if (newID != previousID)
        {
          CleanUpCard();
        }

        var cardItem = Instantiate(cardPrefab, transform);
        cardItem.transform.localPosition = Vector3.zero;
        if (!component.PresentCard.Has<GameObjectData>())
        {
          component.PresentCard.Add(new GameObjectData(cardItem.gameObject));
        }
        else
        {
          component.PresentCard.Get<GameObjectData>().UpdatePosition(cardItem.gameObject);
        }

        cardItem.Create(component.PresentCard);
        presentCard = cardItem.gameObject;
        previousID = newID;
      }
    }
  }
}