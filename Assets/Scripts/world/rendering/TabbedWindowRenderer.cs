using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using UnityEngine;

namespace world.rendering
{
  public class TabbedWindowRenderer : DataBehaviour
  {
    [SerializeField] private GameObject PanelPrefab;
    public IEnumerator Start()
    {
      var world = Finder.Find<GameWorld>();
      while (!world.IsInitialized)
      {
        yield return null;
      }
      foreach (var comp in world.AreaCompositions)
      {
        var tab = Instantiate(PanelPrefab, transform);
        tab.GetComponent<AreaWindow>().Create(comp);
      }
    }
  }
}