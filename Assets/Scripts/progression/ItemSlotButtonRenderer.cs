using System.Collections;
using core.Data.elements;
using UnityEngine;
using world;
using world.rendering;

namespace progression
{
  public class ItemSlotButtonRenderer : MonoBehaviour
  {
    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private GameObject EmptyItemSlot;

    public IEnumerator Start()
    {
      var world = Finder.Find<GameWorld>();
      while (!world.IsInitialized)
      {
        yield return null;
      }

      foreach (var comp in world.Player.InventoryItemsSlots)
      {
        if (comp.Has<ImageData>())
        {
          var tab = Instantiate(ButtonPrefab, transform);
          tab.GetComponent<SlotButtonRenderer>().Create(comp);
        }
        else
        {
          var tab = Instantiate(EmptyItemSlot, transform);
          tab.GetComponent<SlotButtonRenderer>().Create(comp);
        }
      }
    }
  }
}