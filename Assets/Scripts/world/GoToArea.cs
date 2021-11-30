using area.data;
using Assets.Data;
using core.CoroutineExecutor;
using core.Data.elements;
using core.scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace world
{
  public class GoToArea : TypedDataBehaviour<IdAndIndexData>
  {
    public void OnClick()
    {
      // GameWorld.Find().Composition.Get<GameWorldInstance>().UpdateArea(Area);
      new ChangeSceneCommand(SceneManager.GetActiveScene().name,"Area").Then(() =>
      {
        Finder.Find<AreaManager>().CreateArea(Finder.Find<GameWorld>().FindAndGoToArea(component.ID));
      }).Then(new SpawnPopupCommand(Resources.Load<GameObject>("progression/Story"),Finder.Find<GameWorld>().Player.LevelUpData,true)).Execute();
    }
  }
}