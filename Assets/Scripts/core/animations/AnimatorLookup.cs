using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace core.animations
{
  public class AnimatorLookup : MonoBehaviour
  {
    public static int AnimatorTrigger = Animator.StringToHash("Trigger");
    public static int AnimatorAlternate = Animator.StringToHash("Alternate");
    public static int AnimatorType = Animator.StringToHash("Type");
    public Pool Pool;
    public List<ModelEffectAnimation> Lookup = new List<ModelEffectAnimation>();
    
  }
}