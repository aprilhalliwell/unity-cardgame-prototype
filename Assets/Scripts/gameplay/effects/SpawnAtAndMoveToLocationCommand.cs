using System;
using System.Collections;
using Assets.Data;
using core.CoroutineExecutor;
using gameplay.card;
using gameplay.card.data.rendering;
using UnityEngine;
using Object = UnityEngine.Object;

namespace gameplay.effects
{
  public class SpawnAtAndMoveToLocationCommand: Command
  {
    private ElementComposition card;
    private GameObject prefab;
    private GlobalTransform fromPos;
    private Transform toPos;
    private Vector3 velocity = Vector2.zero;
    private Vector3 scaleVel = Vector2.zero;

    public SpawnAtAndMoveToLocationCommand(ElementComposition card, GameObject prefab, GlobalTransform from, Transform to)
    {
      this.card = card;
      this.prefab = prefab;
      this.fromPos = from;
      this.toPos = to;
    }
    public override IEnumerator execute()
    {
      var spawnedCard = Object.Instantiate(prefab,fromPos.position,Quaternion.identity,toPos);
      spawnedCard.GetComponent<Card>().Create(card);
      yield return new WaitForSeconds(0.1f);
      while (spawnedCard != null &&  Vector2.Distance(spawnedCard.transform.position,toPos.position) > .2f)
      {
        spawnedCard.transform.position = Vector3.SmoothDamp(
          spawnedCard.transform.position, 
          toPos.transform.position, 
          ref velocity, 
          0.5f);
        spawnedCard.transform.localScale = Vector3.SmoothDamp(
          spawnedCard.transform.localScale,
          toPos.localScale,
          ref scaleVel,
          0.2f);
        yield return null;
      }
      card.Get<GameObjectData>().UpdatePosition(spawnedCard);
      Object.Destroy(spawnedCard);
    }
  }
}