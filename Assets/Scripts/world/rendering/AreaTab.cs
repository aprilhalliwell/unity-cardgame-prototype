using Assets.Data;

namespace world.rendering
{
  public class AreaTab : DataBehaviour, IHasData
  {
    ElementComposition composition;
    public ElementComposition Composition => composition;

    public void Create(ElementComposition comp)
    {
      composition = comp;
    }
  }
}