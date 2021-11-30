using area.data;
using Assets.Data;
using core.Data.elements;
using gameplay.room.data;
using UnityEngine.UI;

namespace world.room.rendering
{
  public class RoomTitle: VersionedDataBehaviour<TitleData>
  {
    private Text text;
    protected override void awake()
    {
      text = GetComponent<Text>();
    }

    protected override void dirtyUpdate()
    {
      
      switch (component.Get<RoomDataState>().RowStates)
      {
        case RoomRowStates.Available:
        case RoomRowStates.Completed:
          text.text = component.Title;
          break;
        default:
          text.text = "?";
          break;
      }
    }
  }
}