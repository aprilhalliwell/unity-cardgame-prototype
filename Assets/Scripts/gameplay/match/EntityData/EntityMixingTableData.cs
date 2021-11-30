using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using gameplay.effects;
using gameplay.mixingTable;
using gameplay.mixingTable.data;

namespace gameplay.match.EntityData
{
  public class EntityMixingTableData : VersionedDataElement, IPileRenderer
  {
    public List<ElementComposition> ItemsToRender { get; }
    public PileLocation PileLocation { get; set; }

    public EntityMixingTableData(List<ElementComposition> mixingSlots, PileLocation location)
    {
      ItemsToRender = mixingSlots;
      PileLocation = location;
    }

    public IEnumerator CheckAndMixIfReady()
    {
      List<ElementComposition> cards = new List<ElementComposition>(2);
      foreach (var slot in ItemsToRender)
      {
        if (slot.Get<MixingSlotSelectedCardData>().ItemsToRender.Count != 0)
        {
          var card = slot.Get<MixingSlotSelectedCardData>().ItemsToRender[0];
          cards.Add(card);
        }
      }
      if (cards.Count == 2)
      {
        var newCard = MixingResults.MixedCard(cards[0], cards[1]);
        yield return new SpawnAtLocationCommand(newCard,PileLocation.cardPrefab,PileLocation.transform);

        foreach (var slot in ItemsToRender)
        {
          slot.Get<MixingSlotSelectedCardData>().MoveCardToDiscard();
        }

        yield return newCard.Get<CardDataAbilities>().ApplyAbilities(MatchState.RandomEnemyComposition());
      }
    }

    public IEnumerator MoveCardToHand(ElementComposition card)
    {
      yield break;
    }
  }
}