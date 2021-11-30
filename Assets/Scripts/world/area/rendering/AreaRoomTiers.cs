using System.Collections.Generic;
using area.data;
using Assets.Data;
using UnityEngine;
using world.tier;

namespace area.rendering
{
  public class AreaRoomTiers : VersionedDataBehaviour<AreaRoomData>
  {
    List<GameObject> renderedRooms = new List<GameObject>();
    [SerializeField] private GameObject TierPrefab;
    protected override void dirtyUpdate()
    {
      foreach (var renderedRoom in renderedRooms)
      {
          Destroy(renderedRoom);
      }
      foreach (var row in component.RoomData.Keys)
      {
        var tier = Instantiate(TierPrefab, transform);
        tier.GetComponent<Tier>().Create(component.RoomData[row]);
      }
    }
  }
}