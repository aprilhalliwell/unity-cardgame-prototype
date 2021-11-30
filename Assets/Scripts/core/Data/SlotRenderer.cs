using System;
using System.Collections;
using System.Collections.Generic;
using area.rendering;
using Assets.Data;
using core.Data.elements;
using gameplay.card.data.rendering;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.mixingTable
{
 public abstract class SlotRenderer<T> : VersionedDataBehaviour<T> where T : VersionedDataElement, ISlotRenderer 
  {
    [SerializeField] CompositionProvider Slot;
    List<GameObject> renderedCompositions = new List<GameObject>();
    protected override void dirtyUpdate()
    {
      ClearPreviousRenders();
      CreateRenderedSlots();
    }

    protected virtual void CreateRenderedSlots()
    {
      foreach (var composition in component.ItemsToRender)
      {
        var mixingSlot = Instantiate(Slot, transform);
        mixingSlot.Create(composition);
        renderedCompositions.Add(mixingSlot.gameObject);
      }
    }

    protected virtual void ClearPreviousRenders()
    {
      foreach (var renderedComposition in renderedCompositions)
      {
        DestroyImmediate(renderedComposition);
      }
      renderedCompositions.Clear();
    }
  }
}