using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card.data.rendering;
using UnityEngine;
using Random = UnityEngine.Random;

namespace gameplay.match.EntityData
{
  public class EntityHandData : VersionedDataElement
  {
    public List<ElementComposition> cardsInHand = new List<ElementComposition>();
    public int MaxHandSize = 5;
    public int CurrentHandSize => cardsInHand.Count;

    public EntityHandData()
    {
    }

    public void AddCardToHand(ElementComposition card)
    {
      cardsInHand.Add(card);
      markDirty();
    }

    public bool IsCardInHand(ElementComposition card)
    {
      return IsCardInHand(card.Get<CardDataID>().CardID);
    }
    public IEnumerator DiscardHand()
    {
      var discard = composition.Get<EntityDiscardData>();
      for (int i = cardsInHand.Count -1; i >= 0; i--)
      {
        var t = cardsInHand[i];
        yield return new WaitForSeconds(Random.Range(0,1));

        discard.AddToDiscard(t).Execute();
      }
    }
    public bool IsCardInHand(Guid currentID)
    {
      foreach (var inHand in cardsInHand)
      {
        if (inHand.Get<CardDataID>().CardID == currentID)
        {
          return true;
        }
      }
      return false;
    }
    
    public void RemoveCardFromHand(ElementComposition card)
    {
      var currentID = card.Get<CardDataID>().CardID;
      int index = -1;

      for (int i = 0; i < cardsInHand.Count; i++)
      {
        if (cardsInHand[i].Get<CardDataID>().CardID == currentID)
        {
          Debug.Log("Removing Index " + i.ToString());
          index = i;
        }
      }
      if (index != -1)
      {
        cardsInHand.RemoveAt(index);
      }
      markDirty();
    }
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("Hand has \n");
      foreach (var elementComposition in cardsInHand)
      {
        sb.Append(elementComposition.Get<CardDataName>().CardName + "\n");
      }

      return sb.ToString();
    }
  }
}