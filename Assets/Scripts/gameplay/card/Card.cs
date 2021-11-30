using area.rendering;
using UnityEngine;


public class Card : CompositionProvider
{
  protected override void awake()
  {
    GetComponent<Canvas>().worldCamera = Camera.main;
    base.awake();
  }
}