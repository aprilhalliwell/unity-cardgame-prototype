using System.Collections;
using System.Linq;
using area.data;
using core.CoroutineExecutor;
using core.Data.elements;
using core.scene;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.match.data;
using gameplay.match.EntityData;
using gameplay.room;
using gameplay.room.data;
using player;
using player.data;
using UnityEngine;
using UnityEngine.SceneManagement;
using world;
using world.match.data;
using world.room.data;

namespace gameplay.match.commands
{
  public class EndMatchCommand : Command
  {
    public override IEnumerator execute()
    {
     //if we win the match than we should go back to the room
      var GameWorld = Finder.Find<GameWorld>();
      yield return new SpawnPopupCommand(Resources.Load<GameObject>("match/GameOver"),GameWorld.Player.PlayerStats,true);
      yield return new ChangeSceneCommand(SceneManager.GetActiveScene().name, "MainMenu");
    }
  }
}