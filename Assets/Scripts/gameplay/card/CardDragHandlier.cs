using System;
using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.match;
using gameplay.match.data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace gameplay.card
{
  public class CardDragHandlier : VersionedDataBehaviour<CardDataInteractiveState>, IDragHandler , IEndDragHandler
  {
    Vector3 mousePos;
    private Camera mainCamera;
    protected override void awake()
    {
      mainCamera = Camera.main;
    }

    public void OnDrag(PointerEventData eventData)
    {
      component.UpdateState(CardInteractive.Dragging);
      transform.localScale = new Vector3(1,1,1);
      MatchState.MatchComposition().Get<MatchCardDragData>().UpdateDragData(data.Composition);
      mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
      transform.position = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y)  - 80, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      data.Composition.Get<GameObjectData>().UpdatePosition(gameObject);
      component.UpdateState(CardInteractive.Normal);
      transform.localScale = new Vector3(1,1,1);
      MatchState.MatchComposition().Get<MatchCardDragData>().UpdateDragData(null);
    }
  }
}