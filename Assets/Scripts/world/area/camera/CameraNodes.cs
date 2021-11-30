using System.Collections;
using System.Collections.Generic;
using area.data;
using Assets.Data;
using core.CoroutineExecutor;
using UnityEngine;

namespace DefaultNamespace
{
  public class CameraNodes : VersionedDataBehaviour<AreaDataRow>
  {
    private Vector3 velocity = Vector2.zero;
    private int currentNode = 0;
    [SerializeField] private List<CameraNode> nodes;
    [SerializeField] private Camera follow;
    
    protected override void dirtyUpdate()
    {
      var to = nodes[component.CameraNode];
      Move(transform, to.transform,to.nodePosition).Execute();
    }

    IEnumerator Move(Transform from, Transform to, int index)
    {
      while (Vector2.Distance(from.transform.position,to.position) > .2f)
      {
        follow.transform.position = Vector3.SmoothDamp(
          follow.transform.position, 
          to.transform.position, 
          ref velocity, 
          0.3f);
        yield return null;
      }
      currentNode = index;
    }
  }
}