using Assets.Data;
using gameplay.match.PlayerData;
using UnityEngine.UI;

namespace gameplay.match.rendering
{
  public class PlayerShieldRenderer : VersionedDataBehaviour<EntityShieldData>
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