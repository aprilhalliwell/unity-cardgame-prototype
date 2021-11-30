using Assets.MapPainter.Editor;
using UnityEditor;
using UnityEngine;

namespace Editor
{
  /// <summary>
  /// The main window for our Game Painting System.
  /// </summary>
  public class TileWindow : EditorWindow
  {
    /// <summary>
    /// The current tab selected.
    /// </summary>
    Mode mode = Mode.CardCreation;
    /// <summary>
    /// The current Window
    /// </summary>
    public static EditorWindow window;


    /// <summary>
    /// Controls how a characters data is made.
    /// </summary>
    SchemeCreationView schemeCreationView = new SchemeCreationView();



    /// <summary>
    /// Adds a new menu option to the Window tab called Platform Creator.
    /// </summary>
    [MenuItem("Window/CardEditor")]
    public static void ShowWindow()
    {
      window = EditorWindow.GetWindow(typeof(TileWindow),false,"Card Editor");
      window.Show();
    }

    /// <summary>
    /// Main GUI loop of our window, used to select different tabs which will then render different views.
    /// </summary>
    void OnGUI()
    {
      if (window == null)
      {
        window = EditorWindow.GetWindow(typeof(TileWindow));
      }
      schemeCreationView.RenderView();
    }

    /// <summary>
    /// When recompiling scripts, the current data map gets lost.
    /// This will refresh that.
    /// </summary>
    [ExecuteInEditMode]
    void Update() 
    {
      Repaint();
    }
    /// <summary>
    /// Hook up our grid input
    /// </summary>
    void OnEnable()
    {
      SceneView.duringSceneGui += GridUpdate;
    }

    /// <summary>
    /// Unhook our grid input
    /// </summary>
    void OnDisable()
    {
      SceneView.duringSceneGui -= GridUpdate;
    }


    /// <summary>
    /// Handles input that happens in our scene
    /// Switches passing input data into different tabs
    /// Forces users into the pan and view modes for the scene view.
    /// </summary>
    /// <param name="view"></param>
    void GridUpdate(SceneView view)
    {
      
      switch (mode)
      {
        case Mode.CardCreation:
          break;
      }
    }
  }
}