using Assets.Data;
using core.CoroutineExecutor;
using core.Data.elements;
using core.scene;
using gameplay.room;
using UnityEngine.SceneManagement;
using world;
using world.room.data;

public class GoToRoom : VersionedDataBehaviour<IDData>
  {
    public void OnClick()
    {
      new ChangeSceneCommand(SceneManager.GetActiveScene().name,"Room").Then(() =>
      {
        Finder.Find<RoomManager>().CreateRoom(Finder.Find<GameWorld>().FindAndGoToRoom(component.ID));
      }).Execute();
    }
  }
