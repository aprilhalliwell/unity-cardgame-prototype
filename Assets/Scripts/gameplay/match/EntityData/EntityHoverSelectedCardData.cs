using System.Collections.Generic;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.match;
using gameplay.match.EntityData;

namespace gameplay.hover
{
  public class EntityHoverSelectedCardData : VersionedDataElement , IPileRenderer
  {
    public List<ElementComposition> ItemsToRender { get; } = new List<ElementComposition>();
    public PileLocation PileLocation { get; set; }

    public void SetCardToHover(List<ElementComposition> altCards)
    {
      ItemsToRender.AddRange(altCards);
      markDirty();
    }

    public void ClearHoverCards()
    {
      ItemsToRender.Clear();
      markDirty();
    }
  }
}