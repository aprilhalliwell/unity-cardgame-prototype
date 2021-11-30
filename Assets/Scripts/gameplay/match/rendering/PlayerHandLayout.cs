using System;
using System.Collections.Generic;
using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.match.rendering
{
  public class PlayerHandLayout: VersionedDataBehaviour<EntityHandData>
  {
    [SerializeField] RectTransform invisibleItem;
    Dictionary<Guid, GameObject> renderedCards = new Dictionary<Guid, GameObject>();
    List<Guid> cardsToRemove = new List<Guid>();
    protected override void dirtyUpdate()
    {
      Debug.Log("In playerHand");

      foreach (var renderedCard in renderedCards)
      {
        if (!component.IsCardInHand(renderedCard.Key))
        {
          Debug.Log("Destorying Card");
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
          var cardItem = Instantiate(invisibleItem, transform);
          composition.Get<CardDataHandPosition>().SetFakePosition(cardItem.gameObject);
          renderedCards.Add(id, cardItem.gameObject);
        }
      }
    }
  }
}