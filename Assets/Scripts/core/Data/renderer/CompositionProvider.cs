using Assets.Data;

namespace area.rendering
{
  public class CompositionProvider : DataBehaviour, IHasData
  {
    ElementComposition composition;
    public ElementComposition Composition => composition;
    
    public void Create(ElementComposition comp)
    {
      composition = comp;
    }
  }
}