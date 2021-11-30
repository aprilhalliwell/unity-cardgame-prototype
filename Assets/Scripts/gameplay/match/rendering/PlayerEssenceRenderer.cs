using Assets.Data;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;
using UnityEngine.UI;

namespace gameplay.match.rendering
{
  public class PlayerEssenceRenderer : VersionedDataBehaviour<EntityEssenceData>
  {
    private Text text;
    protected override void awake()
    {
      text = GetComponent<Text>();
    }

    protected override void dirtyUpdate()
    {
      text.text = component.GetText();
    }
  }
}