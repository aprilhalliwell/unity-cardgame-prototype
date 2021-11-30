using System;
using System.Collections;
using Assets.Data;
using core.CoroutineExecutor;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace gameplay.effects
{
  public class SpawnAndMoveToLocationCommand: Command
  {
    private ElementComposition card;
    private GameObject prefab;
    private Transform fromPos;
    private Transform toPos;
    private Vector3 velocity = Vector2.zero;
    private Vector3 scaleVel = Vector2.zero;

    public SpawnAndMoveToLocationCommand(ElementComposition card, GameObject prefab, Transform from, Transform to)
    {
      this.card = card;
      this.prefab = prefab;
      this.fromPos = from;
      this.toPos = to;
    }
    public override IEnumerator execute()
    {
      var spawnedCard = Object.Instantiate(prefab,fromPos.transform.position,Quaternion.identity,fromPos);
      spawnedCard.GetComponent<Card>().Create(card);
      yield return new WaitForSeconds(Random.Range(0,.05f));
      while (spawnedCard != null && Vector2.Distance(spawnedCard.transform.position,toPos.position) > .35f)
      {
        spawnedCard.transform.position = Vector3.SmoothDamp(
          spawnedCard.transform.position, 
          toPos.position, 
          ref velocity, 
          0.2f);
          spawnedCard.transform.localScale = Vector3.SmoothDamp(
            spawnedCard.transform.localScale,
            toPos.localScale,
            ref scaleVel,
            0.2f);

        yield return null;
      }
      Object.Destroy(spawnedCard);
    }
  }
}