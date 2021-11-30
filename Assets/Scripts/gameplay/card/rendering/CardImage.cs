using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using UnityEngine;
using UnityEngine.UI;

public class CardImage : VersionedDataBehaviour<CardDataImage>
{
  [SerializeField] private Image image;    
  protected override void dirtyUpdate()
  {
    image.sprite = component.Image;
  }
}