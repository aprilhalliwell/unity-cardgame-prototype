using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.enemies.data;
using gameplay.match;
using gameplay.match.data;
using gameplay.mixingTable.data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace gameplay.mixingTable
{
  public class MixingTableDropHandler: VersionedDataBehaviour<MixingSlotInteractiveStateData>, IDropHandler
  {
    Vector3 mousePos;
    private Camera mainCamera;

    protected override void awake()
    {
      mainCamera = Camera.main;
    }

    public void OnDrop(PointerEventData eventData)
    {
      Debug.Log("Starting drop");
      RectTransform rectTransform = transform as RectTransform;
      mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
      var position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
      if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, position))
      {
        var comp = MatchState.MatchComposition().Get<MatchCardDragData>().DraggedData;
        if (data.Composition.Get<MixingSlotSelectedCardData>().IsValidTarget(comp))
        {
          comp.Get<GameObjectData>().UpdatePosition(gameObject);
          comp.Get<CardDataAbilities>().ApplyAbilities(MatchState.RandomEnemyComposition(),true).Execute();
          data.Composition.Get<MixingSlotSelectedCardData>().SetCardToMix(comp);
          
        }
      }
    }
  }
}