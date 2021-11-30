using Assets.Data;

namespace gameplay.match.data
{
  public class MatchCardDragData : VersionedDataElement
  {
    public ElementComposition DraggedData { get; private set; }

    public MatchCardDragData()
    {
    }

    public void UpdateDragData(ElementComposition composition)
    {
      DraggedData = composition;
      markDirty();
    }
  }
}