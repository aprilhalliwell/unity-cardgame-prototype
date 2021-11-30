using System;
using System.Collections.Generic;
using UnityEngine;

namespace gameplay.match
{
  public class PilePosition : MonoBehaviour
  {
    public string ID = "UnknownTarget";

    void Awake()
    {
      Finder.Find<PositionManager>().RegisterPosition(this);
    }

    void OnDestroy()
    {
      Finder.Find<PositionManager>().UnRegisterPosition(ID);      
    }
  }
}