using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.effects;
using gameplay.match;
using gameplay.match.EntityData;
using gameplay.mixingTable.data;
using UnityEngine.EventSystems;

namespace Assets.Scripts.gameplay.mixingTable.rendering
{
  public class SelectedMixingCardClickHandler : VersionedDataBehaviour<MixingSlotInteractiveStateData>, IPointerClickHandler
  {
    public void OnPointerClick(PointerEventData eventData)
    {
      if (eventData.clickCount == 2)
      {
        component.Get<MixingSlotSelectedCardData>().MoveCardToDiscard();
      }
    }
  }
}