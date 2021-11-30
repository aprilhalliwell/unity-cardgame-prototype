using System;
using Assets.Data;

namespace gameplay.card.data.rendering
{
  public class CardDataID : DataElement
  {
    public Guid CardID { get; private set; }
    public CardDataID()
    {
      CardID = Guid.NewGuid();
    }
  }
}