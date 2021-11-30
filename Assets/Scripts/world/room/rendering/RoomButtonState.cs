using area.data;
using Assets.Data;
using core.CoroutineExecutor;
using core.scene;
using gameplay.room.data;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using world.room.data;

namespace world.room.rendering
{
  public class RoomButtonState: TypedDataBehaviour<RoomDataState>
  {
    private Button button;
    protected override void awake()
    {
      button = GetComponent<Button>();
    }
    protected override void start()
    {
      base.start();

      switch (component.RowStates)
      {
        case RoomRowStates.Available:
          button.interactable = true;
          break;
        default:
          button.interactable = false;
          break;
      }
    }
  }
}