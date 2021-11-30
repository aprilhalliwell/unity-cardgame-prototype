using UnityEngine;

namespace core.Components
{
  /// <summary>
  /// Fades the alpha of all canvas renderers under this object
  /// </summary>
  class FadeAway : MonoBehaviour
  {
    /// <summary>
    /// Collection of all canvas renderers
    /// </summary>
    
    CanvasRenderer[] renderers;
    /// <summary>
    /// Unity API
    /// </summary>
    void Start()
    {
      renderers = GetComponentsInChildren<CanvasRenderer>();
    }

    /// <summary>
    /// Unity API
    /// </summary>
    void Update()
    {
      foreach (var cR in renderers)
      {
        cR.SetAlpha(Mathf.Lerp(cR.GetAlpha(), 0, Time.deltaTime * 1.1f));
      }
    }
  }
}
