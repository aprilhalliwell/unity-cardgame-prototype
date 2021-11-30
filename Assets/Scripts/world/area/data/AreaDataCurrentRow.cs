using Assets.Data;

namespace area.data
{
  public class AreaDataCurrentRow : VersionedDataElement
  {
    private int currentRow;

    public int CurrentRow
    {
      get => currentRow;
      set
      {
        currentRow = value;
        markDirty();
      }
    }
    public AreaDataCurrentRow(int currentRow)
    {
      CurrentRow = currentRow;
    }
    public override DataElement Clone()
    {
      return new AreaDataCurrentRow(currentRow);
    }
  }
}