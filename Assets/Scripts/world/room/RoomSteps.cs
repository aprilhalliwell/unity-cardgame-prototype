using System.Collections.Generic;
using Assets.Data;
using UnityEngine;
using world.match;
using world.room.data;

namespace gameplay.room
{
  public class RoomSteps : VersionedDataBehaviour<RoomDataMatches>
  {
    [SerializeField] private GameObject MatchPrefab;
    protected override void dirtyUpdate()
    {
      base.dirtyUpdate();
      foreach (var comp in component.Matches)
      {
        var room = Instantiate(MatchPrefab,transform);
        room.GetComponent<MatchRenderer>().Create(comp);
      }
    }

  }
}