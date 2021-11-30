using Assets.Data;
using UnityEngine;

namespace gameplay.card.data.rendering
{
  public class GameObjectData : VersionedDataElement
  {
    public GlobalTransform Transform;
    public GameObjectData(GameObject obj)
    {
      Transform = new GlobalTransform(obj);
    }

    public void UpdatePosition(GameObject go)
    {
      Transform = new GlobalTransform(go);
    }
  }
}