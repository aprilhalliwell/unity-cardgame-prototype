using Assets.Data;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;
using UnityEngine;
using UnityEngine.UI;

namespace gameplay.match.rendering
{
  public class PlayerChargeRenderer : VersionedDataBehaviour<EntityChargeData>
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