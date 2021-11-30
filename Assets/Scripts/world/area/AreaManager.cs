using System.Collections.Generic;
using area.data;
using Assets.Data;
using gameplay.room.data;
using UnityEngine;
using world;
using world.room.data;

public class AreaManager : DataBehaviour, IHasData
{
  ElementComposition composition;
  public ElementComposition Composition => composition;
  public void CreateArea(ElementComposition areaComp)
  {
    composition = areaComp;
  }
}