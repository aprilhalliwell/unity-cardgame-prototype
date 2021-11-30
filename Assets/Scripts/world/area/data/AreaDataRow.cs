using Assets.Data;

namespace area.data
{
  public class AreaDataRow : VersionedDataElement
  {
    public int CurrentRow;
    public int CameraNode = 0;
    public AreaDataRow(int currentRow, int cameraNode)
    {
      CurrentRow = currentRow;
      CameraNode = cameraNode;
    }

    public void UpdateRow(int currentRow, int cameraNode)
    {
      CurrentRow = currentRow;
      CameraNode = cameraNode;
      markDirty();
    }
    public override DataElement Clone()
    {
      return new AreaDataRow(CurrentRow,CameraNode);
    }
  }
}