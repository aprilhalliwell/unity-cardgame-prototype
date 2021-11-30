using System.Collections.Generic;
using area.data;
using Assets.Data;
using core.Data.elements;
using gameplay.room.data;
using UnityEngine;
using world;
using world.match;
using world.room.data;

namespace gameplay.room
{
  public class AreaRoomConnectors : VersionedDataBehaviour<RoomDataNextRooms>
  {
    [SerializeField] private UILineRenderer ConnectorPrefab;

    protected override void dirtyUpdate()
    {
      /*
       * Find the row
       * get the rooms in the next row
       * for each next room in the row
       * create a connector
       * assign 2 points to the connector
       * the starting point and the end point
       * starting points should be the same
       * end points are deteremined by the index of the room in the rooms list
       * end point math can be determined via formula
       * pos[0].y = 50
       * pos[1].y +=* 2 top aka 150
       * pos[1].y -=* 2 bot aka -50
       */
      base.dirtyUpdate();
      var currentArea = Finder.Find<GameWorld>().CurrentArea;
      var currentRow = currentArea.Get<AreaDataCurrentRow>().CurrentRow;
      var roomsByRows = currentArea.Get<AreaRoomData>().RoomData;
      var row = component.Get<RoomDataRow>().Row;
      var state = component.Get<RoomDataState>().RowStates;
      var currentItemIndex =
        roomsByRows[row].FindIndex(x => x.Get<IDData>().ID == component.Get<IDData>().ID);

      if (roomsByRows.ContainsKey(row + 1))
      {
        var rooms = roomsByRows[row + 1];
        foreach (var roomID in component.NextRooms)
        {
          //fade out routes that are not the next ones
          var nextRoomIndex = rooms.FindIndex(x => x.Get<IDData>().ID == roomID);
          var nextRoomState = rooms.Find(x => x.Get<IDData>().ID == roomID).Get<RoomDataState>();

          var connector = Instantiate<UILineRenderer>(ConnectorPrefab, transform);

          if (state == RoomRowStates.Completed && nextRoomState.RowStates == RoomRowStates.Available)
          {
            connector.color = Color.yellow;
          }
          else if (state == RoomRowStates.Completed && nextRoomState.RowStates == RoomRowStates.Completed)
          {
            connector.color = Color.blue;
          }
          else if(row != currentRow || state == RoomRowStates.Skipped || state == RoomRowStates.Unavailable )
          {
            connector.color = Color.gray;
          }
          else
          {
            connector.color = Color.white;
          }

          connector.Points = new []{new Vector2(),new Vector2()};
          Debug.Log(connector.Points.Length);
          //so we need to move in segements of 110
          //the math depends on the location of the item and the row
          //first row 
          connector.Points[0].x = 100;
          connector.Points[0].y = 50;
          connector.Points[1].x = 170;
          switch (row)
          {
            case 0:
              /* if in the middle
               * nextRoomIndex 0 = 160
               * nextRoomIndex 1 = 50
               * nextRoomIndex 2 = -60
               */
              connector.Points[1].y = 160 - (110 * nextRoomIndex);
              break;
            case 3:
              /* if in the middle
               * currindex 0 = -60
               * currindex 1 = 50
               * currindex 2 = 160
               */
              connector.Points[1].y = -60 + (110 * currentItemIndex);
              break;
            default:
              /* if on top
               * nextRoomIndex 0 = 50
               * nextRoomIndex 1 = -60
               * nextRoomIndex 2 = -170
               * if in the middle
               * nextRoomIndex 0 = 160
               * nextRoomIndex 1 = 50
               * nextRoomIndex 2 = -60
               * if on bot
               * nextRoomIndex 0 = 270
               * nextRoomIndex 1 = 160
               * nextRoomIndex 2 = 50
               */
              var startingY = 50 + (currentItemIndex * 110);
              connector.Points[1].y = startingY - (110 * nextRoomIndex);
              break;
          }
        }
      }
    }
  }
}