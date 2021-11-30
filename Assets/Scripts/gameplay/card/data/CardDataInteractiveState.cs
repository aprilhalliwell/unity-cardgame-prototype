using Assets.Data;
using gameplay.enums;
using UnityEngine;

namespace gameplay.card.data.rendering
{
  public class CardDataInteractiveState : VersionedDataElement
  {
    public Vector3 HoverSize = new Vector3(1.2f,1.2f,1);

    public CardInteractive CardState { get; private set; }

    public CardDataInteractiveState(CardInteractive currentState)
    {
      this.CardState = currentState;
    }

    public void UpdateState(CardInteractive state)
    {
      this.CardState = state;
      markDirty();
    }
  }
}