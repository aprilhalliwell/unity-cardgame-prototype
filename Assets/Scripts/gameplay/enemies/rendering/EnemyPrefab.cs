using Assets.Data;
using gameplay.card.data.rendering;
using UnityEngine;

namespace gameplay.rendering
{
  public class EnemyPrefab : TypedDataBehaviour<EnemyDataPrefab>
  {
    private GameObject renderedEnemy;
    protected override void start()
    {
      base.start();
      Debug.Log(component.Prefab.name);
      Instantiate(component.Prefab, transform);
    }
  }
}