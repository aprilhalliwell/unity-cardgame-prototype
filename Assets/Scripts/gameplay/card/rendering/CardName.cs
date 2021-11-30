using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using UnityEngine;
using UnityEngine.UI;

public class CardName : VersionedDataBehaviour<CardDataName>
{
  [SerializeField] private Text text;    


  protected override void dirtyUpdate()
  {
    text.text = component.CardName;
  }
}