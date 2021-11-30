using System.Collections;
using core.CoroutineExecutor;
using UnityEngine;

namespace gameplay.effects
{
  /// <summary>
  /// Spawns an effect prefab at a specific location
  /// This command completes when the effect has finished.
  /// </summary>
  public class SpawnEffectAtLocation : Command
  {
    private Animation anim;

    public SpawnEffectAtLocation(string animationPrefab,Vector3 position)
    {
      this.anim = Object.Instantiate(Resources.Load<Animation>(animationPrefab),position, Quaternion.identity);
    }
    public override IEnumerator execute()
    {
      anim.Play();
      while (anim.isPlaying)
      {
        yield return null;
      }
    }
  }
}