using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using UnityEngine;
using UnityEngine.UI;

public class CardResources : VersionedDataBehaviour<CardDataCost>
{
  [SerializeField] private ResourceTypes resource;
  [SerializeField] private Text text;    


  protected override void dirtyUpdate()
  {
    gameObject.SetActive(false);
    foreach (var resourceCost in component.Costs)
    {
      if (resourceCost.ResourceTypes == resource)
      {
        gameObject.SetActive(true);
        text.text = resourceCost.Cost.ToString();
      }
    }
  }
}