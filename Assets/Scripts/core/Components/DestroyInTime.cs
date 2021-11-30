using System.Collections;
using UnityEngine;

namespace core.Components
{
  /// <summary>
  /// Destorys a gameobject after a specified amount of time
  /// </summary>
  class DestroyInTime : MonoBehaviour
  {
    /// <summary>
    /// How long to wait to destory the game object
    /// </summary>
    [SerializeField] int DestoryAfter;
    /// <summary>
    /// Unity API
    /// </summary>
    IEnumerator Start()
    {
      yield return new WaitForSeconds(DestoryAfter);
      Destroy(gameObject);
    }
  }
}
