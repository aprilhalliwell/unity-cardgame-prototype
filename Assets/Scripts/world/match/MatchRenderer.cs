using Assets.Data;

namespace world.match
{
  public class MatchRenderer : DataBehaviour, IHasData
  {
    ElementComposition composition;
    public ElementComposition Composition => composition;
    
    public void Create(ElementComposition comp)
    {
      composition = comp;
    }
  }
}