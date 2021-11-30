using Assets.Data;
using core.CoroutineExecutor;
using core.Data.elements;
using UnityEngine;

namespace progression
{
  public class SpawnEquipmentWindow : VersionedDataBehaviour<TitleData>
  {
    [SerializeField] private GameObject Window;
    public void OnClick()
    {
      new SpawnPopupCommand(Window, data.Composition,true).Execute();
    }
  }
}