using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using gameplay.room;
using UnityEngine;

namespace world.rendering
{
  public class LevelTabRenderer: MonoBehaviour
  {
    [SerializeField] private GameObject TabPrefab;
    public IEnumerator Start()
    {
      var world = Finder.Find<GameWorld>();
      while (!world.IsInitialized)
      {
        yield return null;
      }
      foreach (var comp in world.AreaCompositions)
      {
        var tab = Instantiate(TabPrefab, transform);
        tab.GetComponent<AreaTab>().Create(comp);
      }
    }
  }
}