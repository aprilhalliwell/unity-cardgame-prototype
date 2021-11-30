using System;
using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.hover;
using gameplay.match;
using UnityEngine;
using UnityEngine.EventSystems;

namespace gameplay.card
{
  public class CardHover : VersionedDataBehaviour<CardDataInteractiveState>
  {
    private Vector3 previousScale;

    protected override void awake()
    {
      previousScale = transform.localScale;
    }

    public void OnPointerEnter(BaseEventData eventData)
    {
      if (component.CardState == CardInteractive.Normal)
      {
        component.UpdateState(CardInteractive.Hover);
        transform.localScale = component.HoverSize;
        var altCards = component.Get<CardAltData>().AltCards;
        if (altCards.Count != 0)
        {
          Finder.Find<MatchState>().playerComposition.Get<EntityHoverSelectedCardData>().SetCardToHover(altCards);
        }
      }
    }

    public void OnPointerExit(BaseEventData eventData)
    {
      if (component.CardState == CardInteractive.Hover)
      {
        component.UpdateState(CardInteractive.Normal);
        transform.localScale = previousScale;
        Finder.Find<MatchState>().playerComposition.Get<EntityHoverSelectedCardData>().ClearHoverCards();
      }
    }
  }
}