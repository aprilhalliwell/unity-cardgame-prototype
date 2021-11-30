using System;
using System.Collections;
using System.Collections.Generic;
using area.rendering;
using Assets.Data;
using core.Data.elements;
using gameplay.card.data.rendering;
using gameplay.match;
using gameplay.match.EntityData;
using UnityEngine;

namespace gameplay.mixingTable
{
  [RequireComponent(typeof(PileLocation))]
 public abstract class PileRenderer<T> : VersionedDataBehaviour<T> where T : VersionedDataElement, IPileRenderer 
  {
    [SerializeField] protected PileLocation Location;
    [SerializeField] protected List<GameObject> renderedCompositions = new List<GameObject>();
    protected override void awake()
    {
      Location = GetComponent<PileLocation>();
    }

    protected override void start()
    {
      base.start();
      component.PileLocation = Location;
    }

    protected override void dirtyUpdate()
    {
      ClearPreviousRenders();
      CreateRenderedSlots();
    }

    protected virtual void CreateRenderedSlots()
    {
      foreach (var composition in component.ItemsToRender)
      {
        var mixingSlot = Instantiate(Location.cardPrefab, transform);
        mixingSlot.transform.localPosition = Vector3.zero;
        mixingSlot.GetComponent<Card>().Create(composition);
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