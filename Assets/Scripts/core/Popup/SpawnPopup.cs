using System.Collections;
using area.rendering;
using Assets.Data;
using core.CoroutineExecutor;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPopupCommand : Command
{
  private GameObject prefab;
  private ElementComposition comp;
  private bool hasClickShield;
  public SpawnPopupCommand(GameObject prefab, ElementComposition comp, bool hasClickShield)
  {
    this.hasClickShield = hasClickShield;
    this.prefab = prefab;
    this.comp = comp;
  }

  public override IEnumerator execute()
  {
    var popup = Object.Instantiate(prefab, GameObject.FindWithTag("PopupPin").transform);
    popup.GetComponent<CompositionProvider>().Create(comp);
    GameObject clickShield = null;
    if (hasClickShield)
    {
      GameObject.FindWithTag("ClickShield").GetComponent<Image>().enabled = true;
    }
    while (popup != null && popup.activeInHierarchy)
    {
      yield return null;
    }
    if (hasClickShield)
    {
      GameObject.FindWithTag("ClickShield").GetComponent<Image>().enabled = false;
    }
  }
}