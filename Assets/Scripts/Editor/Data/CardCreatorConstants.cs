using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MapPainter.Editor
{
  /// <summary>
  /// Contains all Constants used by the Editor Tools
  /// </summary>
  public static class MapPainterConstants
  {
    //Labels used by the map editor system
    /// <summary>
    /// Labels used for navigating the main window
    /// </summary>
    public static string[] TabLabels = new string[] { "Character Creation" };

    /// <summary>
    /// Labels used for selecting events
    /// </summary>
    public static string[] EventChoicesLabels = new string[] {  "Edit","Select" };
    public static string[] SchemeFilterChoicesLabels = new string[] {  "All","Card","Enemy","CardBundle","Equipment","InventoryCards","InventoryItems","LevelUp","Match","Rooms","Area" };

  }
}
