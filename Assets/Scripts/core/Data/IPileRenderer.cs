using System.Collections.Generic;
using gameplay.enums;
using gameplay.match;

namespace Assets.Data
{
  public interface IPileRenderer : ISlotRenderer
  {
    PileLocation PileLocation { get; set; }

  }
  public interface ISlotRenderer
  {
    List<ElementComposition> ItemsToRender { get; }
  }
}