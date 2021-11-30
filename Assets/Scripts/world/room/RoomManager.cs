using Assets.Data;

namespace gameplay.room
{
  public class RoomManager : DataBehaviour, IHasData
  {
    ElementComposition composition;
    public ElementComposition Composition => composition;
    public void CreateRoom(ElementComposition comp)
    {
      composition = comp;
    }
  }
}