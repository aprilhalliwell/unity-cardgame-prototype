using System;
using System.Collections.Generic;
using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.effects;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.match
{
  /// <summary>
  /// Controls how the cards in the hand are held
  /// </summary>
  public class PlayerHand : VersionedDataBehaviour<EntityHandData>
  {
    [SerializeField] Card cardPrefab;
    Dictionary<Guid, GameObject> renderedCards = new Dictionary<Guid, GameObject>();
    List<Guid> cardsToRemove = new List<Guid>();

    protected override void dirtyUpdate()
    {
      Debug.Log("In playerHand");
      cardsToRemove.Clear();
      foreach (var renderedCard in renderedCards)
      {
        if (!component.IsCardInHand(renderedCard.Key))
        {
          cardsToRemove.Add(renderedCard.Key);
          Destroy(renderedCard.Value);
        }
      }
      foreach (var guid in cardsToRemove)
      {
        renderedCards.Remove(guid);
      }
      cardsToRemove.Clear();
      foreach (var composition in component.cardsInHand)
      {
        var id = composition.Get<CardDataID>().CardID;
        if (!renderedCards.ContainsKey(id))
        {
          Debug.Log("setting Card");
          var cardItem = Instantiate(cardPrefab, transform);
          if (!composition.Has<GameObjectData>())
          {
            composition.Add(new GameObjectData(cardItem.gameObject));
          }
          else
          {
            composition.Get<GameObjectData>().UpdatePosition(cardItem.gameObject);
          }

          cardItem.Create(composition);
          renderedCards.Add(id, cardItem.gameObject);
        }
      }
    }
  }
}