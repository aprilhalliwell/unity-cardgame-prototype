using System;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.match;
using gameplay.match.data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace gameplay.card
{
  public class CardClickHandlier : VersionedDataBehaviour<CardDataInteractiveState>, IPointerClickHandler
  {
    public void OnPointerClick(PointerEventData eventData)
    {
      if (eventData.clickCount == 2)
      {
        if (component.Get<CardDataAbilities>().isValidTarget(MatchState.PlayerComposition()))
        {
          component.Get<CardDataAbilities>().ApplyAbilities(MatchState.PlayerComposition()).Execute();
        }
      }
    }
  }
}