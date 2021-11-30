using Assets.Data;
using gameplay.enemies.data;
using gameplay.match;
using gameplay.match.data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace gameplay
{
  public class EnemyHover : VersionedDataBehaviour<EnemyDataInteractiveState>, IPointerEnterHandler , IPointerExitHandler
  {
    Vector3 mousePos;

    public void OnPointerEnter(PointerEventData eventData)
    {
      var comp = MatchState.MatchComposition().Get<MatchCardDragData>().DraggedData;
      if (comp != null)
      {
        Debug.Log(comp);
        component.UpdateState(PileInteractiveStates.HoveringWithCard);
      }
      else
      {
        component.UpdateState(PileInteractiveStates.Hovering);
      }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      component.UpdateState(PileInteractiveStates.Normal);
    }
  }
}