using area.data;
using Assets.Data;
using UnityEngine;

namespace world.rendering
{
  public class AreaTabVisible : VersionedDataBehaviour<AreaActiveTab>
  {
    [SerializeField] private GameObject Pane;
    protected override void dirtyUpdate()
    {
      Pane.SetActive(component.Active);
    }
  }
}