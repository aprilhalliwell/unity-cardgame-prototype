using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using UnityEngine;

namespace gameplay.effects
{
  public class SmoothFollow : VersionedDataBehaviour<CardDataHandPosition>
  {
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector2.zero;
    private CardDataInteractiveState state;
    protected override void start()
    {
      base.start();
      state = data.Composition.Get<CardDataInteractiveState>();
    }

    protected override void dirtyUpdate()
    {
      base.dirtyUpdate();
      if (component.FakeCardObject != null)
      {
        target = component.FakeCardObject.transform;
      }
    }

    protected override void update()
    {
      base.update();
      if (component.FakeCardObject != null)
      {
        if (state.CardState == CardInteractive.Dragging) return;
        var targetPosition = target.TransformPoint(new Vector3(0, 0, -1));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        data.Composition.Get<GameObjectData>().UpdatePosition(gameObject);
      }
    }
  }
}