using System;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.enemies.data;
using gameplay.match;
using gameplay.match.data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace gameplay
{
  public class EnemyDropHandlier : VersionedDataBehaviour<EnemyDataInteractiveState>, IDropHandler
  {
    Vector3 mousePos;
    private Camera mainCamera;

    protected override void awake()
    {
      mainCamera = Camera.main;
    }

    public void OnDrop(PointerEventData eventData)
    {
      RectTransform rectTransform = transform as RectTransform;
      mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
      var position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
      if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, position))
      {
        var comp = MatchState.MatchComposition().Get<MatchCardDragData>().DraggedData;
        if (comp.Get<CardDataAbilities>().isValidTarget(data.Composition))
        {
          comp.Get<GameObjectData>().UpdatePosition(gameObject);
          comp.Get<CardDataAbilities>().ApplyAbilities(data.Composition).Execute();
        }
      }
    }
  }
}