using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Data;
using core.CoroutineExecutor;
using DefaultNamespace;
using gameplay.card.data.rendering;
using gameplay.effects;
using gameplay.match;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.mixingTable.data
{
  public class MixingSlotSelectedCardData : VersionedDataElement , IPileRenderer
  {
    public List<ElementComposition> ItemsToRender { get; } = new List<ElementComposition>();
    public PileLocation PileLocation { get; set; }

    public bool IsValidTarget(ElementComposition card)
    {
      return card.Get<CardDataName>().CardName.Contains("(M)") && ItemsToRender.Count == 0;
    }

    public void SetCardToMix(ElementComposition card)
    {
      var player =  Finder.Find<MatchState>().playerComposition;
      if (player.Get<EntityHandData>().IsCardInHand(card))
      {
        player.Get<EntityHandData>().RemoveCardFromHand(card);
      }
      ItemsToRender.Add(card);
      player.Get<EntityMixingTableData>().CheckAndMixIfReady().Execute();
      markDirty();
    }

    public void MoveCardToDiscard()
    {
      if (ItemsToRender.Count == 1)
      {
        var player = MatchState.PlayerComposition();
        var card = ItemsToRender[0];
        var discard = player.Get<EntityDiscardData>();
        discard.AddToDiscard(card).Execute();
        ItemsToRender.Clear();
        markDirty();
      }
    }
  }
}