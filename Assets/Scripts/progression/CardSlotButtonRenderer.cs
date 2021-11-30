using System.Collections;
using core.Data.elements;
using progression.equipment.data;
using UnityEngine;
using world;
using world.rendering;

namespace progression
{
  public class CardSlotButtonRenderer : MonoBehaviour
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

      foreach (var comp in world.Player.InventoryCardSlots)
      {
        var tab = Instantiate(ButtonPrefab, transform);
        tab.GetComponent<SlotButtonRenderer>().Create(comp);
      }
    }
  }
}