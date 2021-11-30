using System.Collections;
using System.Collections.Generic;
using Assets.Data;
using gameplay.card.data.rendering;
using UnityEngine;

namespace gameplay.match.rendering
{
  public class EnemyEntities : MonoBehaviour
  {
    List<GameObject> renderedEnemies = new List<GameObject>();
    [SerializeField] Enemy enemyPrefab;

    Dictionary<int, ElementComposition> composition;

    IEnumerator Start()
    {
      var go = Finder.Find<MatchState>();
      while (go.enemyCompositions == null)
      {
        yield return null;
      }

      Debug.Log(go.enemyCompositions);
      composition = go.enemyCompositions;
      CreateEnemies();
    }

    void CreateEnemies()
    {
      foreach (var renderedCard in renderedEnemies)
      {
        Destroy(renderedCard);
      }
      foreach (var composition in composition)
      {
        var enemy = Instantiate(enemyPrefab, transform);
        if (!composition.Value.Has<GameObjectData>())
        {
          composition.Value.Add(new GameObjectData(enemy.gameObject));
        }
        else
        {
          composition.Value.Get<GameObjectData>().UpdatePosition(enemy.gameObject);
        }
        enemy.CreateEnemy(composition.Value);
        renderedEnemies.Add(enemy.gameObject);
      }
    }
  }
}