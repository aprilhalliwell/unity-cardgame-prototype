using Assets.Data;

namespace gameplay.room
{
  public class RoomRenderer : DataBehaviour, IHasData
  {
    ElementComposition composition;
    public ElementComposition Composition => composition;
    public void Create(ElementComposition comp)
    {
      composition = comp;
    }
  }
}