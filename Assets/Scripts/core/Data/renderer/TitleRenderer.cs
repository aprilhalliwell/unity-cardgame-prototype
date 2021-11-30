using area.data;
using Assets.Data;
using core.Data.elements;
using UnityEngine.UI;

namespace area.rendering
{
  public class TitleRenderer : VersionedDataBehaviour<TitleData>
  {
    private Text text;
    protected override void awake()
    {
      text = GetComponent<Text>();
    }

    protected override void dirtyUpdate()
    {
      text.text = component.Title;
    }
  }
}