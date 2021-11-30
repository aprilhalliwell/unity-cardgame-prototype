using UnityEngine;

namespace gameplay.card
{
  public class GlobalTransform
  {
    public GameObject gameObject;
    public Vector3 position;
    public GlobalTransform(Transform transform)
    {
      gameObject = transform.gameObject;
      position = transform.position;
    }
    public GlobalTransform(GameObject go)
    {
      gameObject = go;
      position = go.transform.position;
    }
  }
}