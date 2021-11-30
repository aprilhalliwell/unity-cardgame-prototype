using System.Collections;
using core.CoroutineExecutor;
using gameplay.card;
using UnityEngine;

namespace core.animations
{
  public class EffectTriggerCommand : Command
  {
    public string name;
    Vector2 p = Vector2.zero;
    bool setAlternate = false;
    bool alternate = false;
    bool setType = false;
    float type = 0f;
    bool setColor = false;
    Color? color = null;
    public Transform caster;
    public GlobalTransform target;

    public EffectTriggerCommand(string name,Transform caster)
    {
      this.caster = caster;
      this.name = name;
    }
    public EffectTriggerCommand(string name,GlobalTransform target)
    {
      this.target = target;
      this.name = name;
    }
    public override IEnumerator execute()
    {
      var lookup = Finder.Find<AnimatorLookup>();
      Material _materialNormal = new Material(Shader.Find("Sprites/Default")) { color = Color.white };
      Material  _materialAdditive = new Material(Shader.Find("Custom/Additive")) { color = Color.white };
      var o = lookup.Pool.Enter();
      if (caster != null)
      {
        o.transform.parent = caster;
      }
      else if (target != null)
      {
        if (target.gameObject != null)
        {
          o.transform.parent = target.gameObject.transform;
        }
        else
        {
          o.transform.position = target.position;
        }
      }

      var model = lookup.Lookup.Find(x => x.name == name);
      o.transform.localPosition = new Vector3(p.x, p.y, 0);
      // o.transform.localScale = Vector3.one;
      var spriteRenderers = o.GetComponentsInChildren<SpriteRenderer>();
      foreach (var spriteRenderer in spriteRenderers)
      {
        spriteRenderer.color = (setColor && color != null && color.HasValue) ? color.Value : Color.white;
        spriteRenderer.material = model.Blend ? _materialAdditive : _materialNormal;
      }
      spriteRenderers[1].transform.localPosition = model.BackOffset;
      spriteRenderers[1].sortingOrder = -1;
      spriteRenderers[2].transform.localPosition = model.ForeOffset;
      spriteRenderers[2].sortingOrder = 2;
      spriteRenderers[0].transform.localPosition = model.Offset;
      spriteRenderers[0].sortingOrder = 1;
      var animator = o.GetComponentInChildren<Animator>();
      animator.runtimeAnimatorController = model.Controller;
      animator.SetTrigger(AnimatorLookup.AnimatorTrigger);
      while (o.activeSelf)
      {
        yield return null;
      }
    }
  }
}