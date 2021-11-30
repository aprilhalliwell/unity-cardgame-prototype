using Assets.Data;
using gameplay.enemies.data;
using gameplay.match;
using gameplay.match.data;
using gameplay.mixingTable.data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace gameplay
{
  public class MixingTableSlotHover : VersionedDataBehaviour<MixingSlotInteractiveStateData>, IPointerEnterHandler , IPointerExitHandler
  {
    Vector3 mousePos;
    public void OnPointerEnter(PointerEventData eventData)
    {
      var comp = MatchState.MatchComposition().Get<MatchCardDragData>().DraggedData;
      component.UpdateState(comp != null ? PileInteractiveStates.HoveringWithCard : PileInteractiveStates.Hovering);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      component.UpdateState(PileInteractiveStates.Normal);
    }
  }
}