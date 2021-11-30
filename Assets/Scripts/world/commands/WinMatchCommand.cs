using System.Collections;
using System.Linq;
using area.data;
using core.CoroutineExecutor;
using core.Data.elements;
using core.scene;
using gameplay.room;
using gameplay.room.data;
using player;
using player.data;
using UnityEngine;
using UnityEngine.SceneManagement;
using world.match.data;
using world.room.data;

namespace world.commands
{
  public class WinMatchCommand  : Command
  {
    private int MatchIndex;

    public WinMatchCommand()
    {
    }
    public override IEnumerator execute()
    {
      //if we win the match than we should go back to the room
      yield return new ChangeSceneCommand(SceneManager.GetActiveScene().name, "Room");
      var GameWorld = Finder.Find<GameWorld>();
      var exp = GameWorld.Player.PlayerStats.Get<ExperienceData>();
      exp.Experience++;
      var shouldLevelUp = PlayerLevelUps.ShouldLevelUp(exp.Experience);
      if (shouldLevelUp)
      {
        yield return new SpawnPopupCommand(Resources.Load<GameObject>("progression/LevelUp"),GameWorld.Player.LevelUpData,true);
      }
      //check level ranges
      
      var matchComp = GameWorld.CurrentMatch;
      matchComp.Get<MatchCompletedData>().Completed = true;
      var comp = GameWorld.CurrentRoom;
      comp.Get<RoomDataCurrentMatchIndex>().MatchIndex++;
      var roomsInArea = GameWorld.CurrentArea.Get<AreaRoomData>().RoomData.Values.SelectMany(x => x).ToList();
      if (comp.Get<RoomDataMatches>().Matches.Count <= comp.Get<RoomDataCurrentMatchIndex>().MatchIndex)
      {
        comp.Get<RoomDataState>().RowStates = RoomRowStates.Completed;
        foreach (var roomComposition in roomsInArea)
        {
          if (roomComposition.Get<RoomDataState>().RowStates == RoomRowStates.Available)
          {
            roomComposition.Get<RoomDataState>().RowStates = RoomRowStates.Skipped;
          }
        }

        foreach (var nRoomID in comp.Get<RoomDataNextRooms>().NextRooms)
        {
          var nRoomComp =  roomsInArea.Find(x => x.Get<IDData>().ID == nRoomID);
          nRoomComp.Get<RoomDataState>().RowStates = RoomRowStates.Available;
        }
        //we have completed our room as well
        //todo some anim
        yield return new SpawnPopupCommand(Resources.Load<GameObject>("progression/LevelUp"),GameWorld.Player.LevelUpData,true);
        yield return new ChangeSceneCommand(SceneManager.GetActiveScene().name, "Area");
        var areaComp = Finder.Find<GameWorld>().CurrentArea;
        areaComp.Get<AreaDataCurrentRow>().CurrentRow++;
        if (areaComp.Get<AreaRoomData>().RoomData.Count <= areaComp.Get<AreaDataCurrentRow>().CurrentRow)
        {
          //todo some anim
          yield return new ChangeSceneCommand(SceneManager.GetActiveScene().name, "MainMenu");
        }
        else
        {
          Finder.Find<AreaManager>().CreateArea(areaComp);
        }
      }
      else
      {
        Finder.Find<RoomManager>().CreateRoom(comp);
      }
    }
  }
}