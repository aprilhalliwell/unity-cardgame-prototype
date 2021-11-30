using System;
using Assets.Data;
using core.Data.elements;
using UnityEngine.UI;
using world.match.data;
using world.room.data;

namespace world.match.rendering
{
  public class MatchButtonRenderer : VersionedDataBehaviour<MatchCompletedData>
  {
    private Button button;

    protected override void awake()
    {
      button = GetComponent<Button>();
    }

    protected override void dirtyUpdate()
    {
      var curr = Finder.Find<GameWorld>().CurrentRoom.Get<RoomDataCurrentMatchIndex>().MatchIndex;
      button.interactable = component.Get<IdAndIndexData>().Index == curr;
    }
  }
}