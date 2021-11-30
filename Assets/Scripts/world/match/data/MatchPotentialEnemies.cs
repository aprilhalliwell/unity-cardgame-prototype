using System.Collections.Generic;
using Assets.Data;
using Assets.Scheme.Traits.BaseTraits;

namespace world.match.data
{
  public class MatchPotentialEnemies : VersionedDataElement
  {
    public List<EnemyScheme> PotentialEnemies { get; private set; }

    public MatchPotentialEnemies(List<EnemyScheme> enemies)
    {
      PotentialEnemies = enemies;
    }

    public void Update(List<EnemyScheme> enemies)
    {
      PotentialEnemies = enemies;
      markDirty();
    }
    
    public override DataElement Clone()
    {
      return new MatchPotentialEnemies(new List<EnemyScheme>(PotentialEnemies));
    }
  }
}