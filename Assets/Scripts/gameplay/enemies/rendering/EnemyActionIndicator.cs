using Assets.Data;
using gameplay.card.data.rendering;
using UnityEngine;
using UnityEngine.UI;

namespace gameplay.enemies.rendering
{
  public class EnemyActionIndicator : VersionedDataBehaviour<EnemyAbilityData>
  {
    [SerializeField] private Image image;
    [SerializeField] private Text text;
    [SerializeField] private Sprite DamageIcon;
    [SerializeField] private Sprite DefaultIcon;
    protected override void dirtyUpdate()
    {
      var amount = component.GetIndicatorAmount();
      if (amount.HasValue)
      {
        text.text = $"x{amount}";
      }

      switch (component.GetIndicator())
      {
        case "DamageIcon": image.sprite = DamageIcon;
          break;
        default: image.sprite = DefaultIcon;
          break;
      }
    }
  }
}