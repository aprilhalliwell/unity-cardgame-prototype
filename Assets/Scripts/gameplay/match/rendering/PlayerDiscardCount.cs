using Assets.Data;
using gameplay.match.EntityData;
using UnityEngine.UI;

namespace gameplay.match.rendering
{
  public class PlayerDiscardCount : VersionedDataBehaviour<EntityDiscardData>
  {
    private Text text;
    protected override void awake()
    {
      text = GetComponent<Text>();
    }

    protected override void dirtyUpdate()
    {
      text.text = component.Discard.Count.ToString();
    }
  }
}