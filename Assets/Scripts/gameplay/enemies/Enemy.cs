using Assets.Data;

namespace gameplay
{
  public class Enemy : DataBehaviour, IHasData
  {
    ElementComposition composition;

    public ElementComposition Composition => composition;

    public void CreateEnemy(ElementComposition composition)
    {
      this.composition = composition;
    }
  }
}