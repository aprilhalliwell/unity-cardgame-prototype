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
  public class SpawnAtLocationCommand: Command
  {
    private ElementComposition card;
    private GameObject prefab;
    private Transform fromPos;
    private Vector3 velocity = Vector2.zero;
    private Vector3 scaleVel = Vector2.zero;

    public SpawnAtLocationCommand(ElementComposition card, GameObject prefab, Transform from)
    {
      this.card = card;
      this.prefab = prefab;
      this.fromPos = from;
    }
    public override IEnumerator execute()
    {
      var spawnedCard = Object.Instantiate(prefab,fromPos.position,Quaternion.identity,fromPos);
      spawnedCard.GetComponent<Card>().Create(card);
      yield return new WaitForSeconds(0.1f);
      if (card.Has<GameObjectData>())
      {
        card.Get<GameObjectData>().UpdatePosition(spawnedCard);
      }
      else
      {
        card.Add<GameObjectData>(new GameObjectData(spawnedCard));
      }

      Object.Destroy(spawnedCard);
    }
  }
}