using System;
using System.Collections;
using UnityEngine;

namespace core.animations
{
  public class SimpleEffectTrigger : MonoBehaviour
  {
    public string Name;
    private IEnumerator Start()
    {
      Debug.Log("Start");
      yield return new EffectTriggerCommand(Name, this.transform);
      Debug.Log("Fin");
    }
  }
}