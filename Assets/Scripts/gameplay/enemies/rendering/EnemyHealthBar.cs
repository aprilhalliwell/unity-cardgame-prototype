using Assets.Data;
using gameplay.match.EntityData;
using UnityEngine;
using UnityEngine.UI;

namespace gameplay.enemies.rendering
{
  public class EnemyHealthBar : VersionedDataBehaviour<EntityHealthData>
  {
    [SerializeField] private Text HealthLabel;
    [SerializeField] private Slider slider;
    protected override void dirtyUpdate()
    {
      slider.value = (float)component.CurrentHealth / component.MaxHealth;
      HealthLabel.text = $"{component.CurrentHealth}/{component.MaxHealth}";
    }
  }
}