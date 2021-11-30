using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scheme.Traits.BaseTraits
{
  /// <summary>
  /// Represents an Animiation Controller
  /// </summary>
  [Serializable]
  public class AnimationControllerTrait : Trait
  {
    /// <summary>
    /// Cached AnimatorController
    /// </summary>
    [NonSerialized]
    private AnimatorController animatorController;

    /// <summary>
    /// Return the loaded AnimatorController
    /// </summary>
    public AnimatorController AnimatorController
    {
      get
      {
        if (animatorController == null)
        {
          animatorController = Resources.Load<AnimatorController>(path);
        }
        return animatorController;
      }
      set
      {
        animatorController = value;
      }
    }
    /// <summary>
    /// Where this animation controll exists
    /// </summary>
    public string path;
    /// <summary>
    /// Sets the path to load the AnimatorController from
    /// </summary>
    /// <param name="path">Resources path to the AnimatorController</param>
    public AnimationControllerTrait(string path)
    {
      this.path = path;
    }
  }
}