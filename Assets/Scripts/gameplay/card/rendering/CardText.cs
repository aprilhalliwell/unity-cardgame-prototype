using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using UnityEngine;
using UnityEngine.UI;

public class CardText : VersionedDataBehaviour<CardDataText>
{
  [SerializeField] private Text text;    

  protected override void dirtyUpdate()
  {
    text.text = component.GameText;
  }
}