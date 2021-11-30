using area.data;
using Assets.Data;
using core.Data.elements;
using UnityEngine.UI;

namespace area.rendering
{
  public class AreaDescription : VersionedDataBehaviour<DescriptionData>
  {
    private Text text;
    protected override void awake()
    {
      text = GetComponent<Text>();
    }

    protected override void dirtyUpdate()
    {
      text.text = component.Description;
    }
  }
}