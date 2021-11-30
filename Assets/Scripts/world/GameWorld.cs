using System;
using System.Collections.Generic;
using System.Linq;
using area.data;
using Assets.Data;
using core.Data.elements;
using gameplay.room.data;
using player;
using progression.cardBundles.data;
using progression.equipment.data;
using UnityEngine;
using world.match.data;
using world.room.data;

namespace world
{
  public class GameWorld : MonoBehaviour
  {
    public Player Player = new Alchemist(); //TODO allow this to switch to construct
    public bool IsInitialized = false;
    [SerializeField] private List<string> Areas;
    public List<ElementComposition> AreaCompositions = new List<ElementComposition>();
    private List<ElementComposition> RoomCompositions = new List<ElementComposition>();
    private List<ElementComposition> MatchCompositions = new List<ElementComposition>();
    
    private ElementComposition playerComposition;
    public ElementComposition CurrentArea;
    public ElementComposition CurrentRoom;
    public ElementComposition CurrentMatch;

    private void Start()
    {
      CreateAreaComposition();
      CreatePlayer();
    }
    
    
    public ElementComposition FindAndGoToArea(string AreaID)
    {
      var comp = AreaCompositions.Find(x => x.Get<IdAndIndexData>().ID == AreaID).Clone();
      CurrentArea = comp;
      return CurrentArea;
    }

    public ElementComposition FindAndGoToRoom(string RoomId)
    {
      var comp = CurrentArea.Get<AreaRoomData>().RoomData.Values.SelectMany(x => x).ToList()
        .Find(x => x.Get<IDData>().ID == RoomId);
      CurrentRoom = comp;
      return CurrentRoom;
    }

    public ElementComposition FindAndGoToMatch(int MatchIndex)
    {
      var comp = CurrentRoom.Get<RoomDataMatches>().Matches.Find(x => x.Get<IdAndIndexData>().Index == MatchIndex);
      CurrentMatch = comp;
      return CurrentMatch;
    }


    void checkRooms(RoomScheme room, Dictionary<string, RoomScheme> rooms, string roomId)
    {
      if (!rooms.ContainsKey(roomId))
      {
        rooms.Add(roomId, room);
        foreach (var roomsItem in room.NextRooms.Items)
        {
          checkRooms(RoomScheme.Create(roomsItem), rooms, roomsItem);
        }
      }
    }

    void CreateAreaComposition()
    {
      int areaIndex = 0;
      foreach (var area in Areas)
      {
        var areaComposition = AreaScheme.Create(area);
        Dictionary<string, RoomScheme> rooms = new Dictionary<string, RoomScheme>();
        // List<RoomScheme> rooms = new List<RoomScheme>();
        var room = RoomScheme.Create(areaComposition.StartRoom.Text);
        checkRooms(room, rooms, areaComposition.StartRoom.Text);
        Dictionary<int, List<ElementComposition>> roomsByRow = new Dictionary<int, List<ElementComposition>>();

        foreach (var roomScheme in rooms)
        {
          var row = roomScheme.Value.RoomRow.Amount;
          var roomMatches = new List<ElementComposition>();
          var matchIndex = 0;
          foreach (var match in roomScheme.Value.Matches.Items)
          {
            //construct match comps
            var matchScheme = MatchScheme.CreateMatch(match);
            var potentialEnemies = new List<EnemyScheme>();
            foreach (var enemy in matchScheme.PotentialEnemies.Items)
            {
              potentialEnemies.Add(EnemyScheme.CreateEnemy(enemy));
            }

            var matchData = new ElementComposition(
              new MatchPreview(matchScheme.MatchPreview),
              new MatchBattleScreens(matchScheme.BattleScreens),
              new MatchPotentialEnemies(potentialEnemies),
              new IdAndIndexData(match, matchIndex),
              new MatchCompletedData(false),
              new MatchHealthPool(matchScheme.HealthPool),
              new MatchUseAllEnemies(matchScheme.UseAllEnemies)
            );
            roomMatches.Add(matchData);
            MatchCompositions.Add(matchData);
            matchIndex++;
          }

          var roomData = new ElementComposition(
            new IDData(roomScheme.Key),
            new RoomDataState(row == 0 ? RoomRowStates.Available : RoomRowStates.Unavailable),
            new TitleData(roomScheme.Value.RoomName),
            new RoomDataRow(roomScheme.Value.RoomRow),
            new RoomDataCurrentMatchIndex(0),
            new RoomDataMatches(roomMatches),
            new RoomDataRewards(roomScheme.Value.Rewards), //TODO create comps
            new RoomDataNextRooms(roomScheme.Value.NextRooms),
            new RoomDataImage(roomScheme.Value.Image)
          );

          RoomCompositions.Add(roomData);
          if (roomsByRow.ContainsKey(row))
          {
            roomsByRow[row].Add(roomData);
          }
          else
          {
            roomsByRow[row] = new List<ElementComposition>();
            roomsByRow[row].Add(roomData);
          }
        }

        //add our area to our list 
        AreaCompositions.Add(new ElementComposition(
          new AreaStoryData(new Dictionary<string, string>
          {
            {"Prologue","Start of the game"},
            {"Area1", "Time to Start"},
            {"Area2","Lots to go"},
            {"Area3","Almost there"},
            {"Area4","Getting closer"},
            {"Area5","Something about getting to the end"},
            {"Finished","END"}
          }),
          new AreaDataCurrentRow(0),
          new AreaActiveTab(areaIndex == 0),
          new DescriptionData(areaComposition.AreaDescription),
          new IdAndIndexData(area, areaIndex),
          new TitleData(areaComposition.AreaName),
          new AreaRoomData(roomsByRow)));
        areaIndex++;
      }

      IsInitialized = true;
    }


    void CreatePlayer()
    {
      Player.InitializePlayer();
    }
  }
}