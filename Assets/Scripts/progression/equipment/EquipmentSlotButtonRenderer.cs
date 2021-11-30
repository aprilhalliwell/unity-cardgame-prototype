using System.Collections.Generic;
using Assets.Data;
using core.Data.elements;
using progression.equipment.data;
using UnityEngine;
using world;

namespace progression.equipment
{
  public class EquipmentSlotButtonRenderer: VersionedDataBehaviour<EquipedSlotData>
  {
    private List<GameObject> renderedObjects = new List<GameObject>();
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private GameObject EmptyItemSlot;
    [SerializeField] private int MaxSlots = 6;
    protected override void dirtyUpdate()
    {
      List<ElementComposition> data;
      if (component.Has<EquipmentCardTypeData>())
      {
       data = Finder.Find<GameWorld>().Player.CardItems[component.Get<EquipmentCardTypeData>().CardBundleType];
      }
      else
      {
        data = Finder.Find<GameWorld>().Player.EquipmentItems[component.Get<EquipmentItemTypeData>().EquipmentType];
      }

      foreach (var o in renderedObjects)
      {
        Destroy(o);
      }
      renderedObjects.Clear();

      var createdSlots = data.Count;
      foreach (var comp in data)
      {
        var tab = Instantiate(ButtonPrefab, transform);
        tab.GetComponent<SlotButtonRenderer>().Create(comp);
        renderedObjects.Add(tab);
      }
      for (int i = 0; i < MaxSlots - createdSlots; i++)
      {
        var t = Instantiate(EmptyItemSlot, transform);
        renderedObjects.Add(t);
      }
    }
  }
}