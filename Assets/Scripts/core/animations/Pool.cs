using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
  [SerializeField] private int count = 12;
  [SerializeField] private GameObject prefab = null;
  private List<GameObject> pool;
  private const string goName = "Pool";

  private void Awake()
  {
    pool = new List<GameObject>(count);
    for (var i = 0; i < count; i++)
    {
      pool.Add(New());
    }
  }

  private GameObject New()
  {
    var go = Instantiate(prefab);
    if (go != null)
    {
      go.transform.SetParent(transform, false);
      go.name = goName;
      go.SetActive(false);
    }
    return go;
  }

  public GameObject Enter()
  {
    GameObject go = null;
    for (var i = 0; (i < pool.Count) && (go == null); i++)
    {
      if (!pool[i].activeInHierarchy)
      {
        go = pool[i];
      }
    }

    if (go == null)
    {
      go = New();
      pool.Add(go);
    }

    go.SetActive(true);
    return go;
  }

  public void Exit(GameObject go)
  {
    if (go == null) return;
    go.name = goName;
    go.transform.parent = transform;
    go.SetActive(false);
  }
}