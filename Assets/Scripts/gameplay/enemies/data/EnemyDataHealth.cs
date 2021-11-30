using Assets.Data;

namespace gameplay.match.PlayerData
{
  public class EnemyHealthData : VersionedDataElement
  {
    public int MaxHealth;
    public int CurrentHealth;
    public EnemyHealthData(int maxHealth, int currentHealth)
    {
      MaxHealth = maxHealth;
      CurrentHealth = currentHealth;
    }

    public void DealDamage(int damage)
    {
      CurrentHealth -= damage;
      markDirty();
    } public void HealDamage(int heal)
    {
      CurrentHealth += heal;
      markDirty();
    }
  }
}