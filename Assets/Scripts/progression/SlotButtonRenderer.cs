using Assets.Data;

namespace progression
{
  public class SlotButtonRenderer: DataBehaviour, IHasData
  {
    ElementComposition composition;
    public ElementComposition Composition => composition;
    
    public void Create(ElementComposition comp)
    {
      composition = comp;
    }
  }
}