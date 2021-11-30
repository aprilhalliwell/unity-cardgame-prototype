using System.Collections.Generic;
using Assets.Data;
using gameplay.room;
using UnityEngine;

namespace world.tier
{
  public class Tier : MonoBehaviour
  {
    [SerializeField] private GameObject RoomPrefab;
    public void Create(List<ElementComposition> compositions)
    {
      foreach (var comp in compositions)
      {
        var room = Instantiate(RoomPrefab,transform);
        room.GetComponent<RoomRenderer>().Create(comp);
      }
    }
  }
}