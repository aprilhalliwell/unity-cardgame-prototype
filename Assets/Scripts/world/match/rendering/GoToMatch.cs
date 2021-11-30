using Assets.Data;
using core.CoroutineExecutor;
using core.Data.elements;
using core.scene;
using gameplay.match;
using UnityEngine.SceneManagement;
using world;
using world.room.data;

public class GoToMatch : VersionedDataBehaviour<IdAndIndexData>
{
  public void OnClick()
  {
    new ChangeSceneCommand(SceneManager.GetActiveScene().name,"Match").Then(() =>
    {
      var world = Finder.Find<GameWorld>();
      world.Player.SetupStatsForGame();
      var comp = world.FindAndGoToMatch(component.Index);
      Finder.Find<MatchState>().CreateMatch(comp);
    }).Execute();
  }
}