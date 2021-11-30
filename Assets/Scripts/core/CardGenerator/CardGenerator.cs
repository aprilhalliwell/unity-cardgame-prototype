using System;
using UnityEngine;

namespace DefaultNamespace
{
  public class CardGenerator : MonoBehaviour
  {
    public int numberOfCardsToMake;
    private void Start()
    {
      CardCrafter cardCrafter = new CardCrafter(numberOfCardsToMake);
    }
  }
}