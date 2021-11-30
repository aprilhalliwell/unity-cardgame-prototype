using System.Collections.Generic;

namespace gameplay.match
{
  public class MatchData
  {
    public int HealthPoints = 0;
    public List<string> PotentialEnemies = new List<string>();
    public bool isCompleted;
    
    public List<string> enemies = new List<string>()
    {
      "cubits",
      "bat",
      "skeletonwarrior"
    };
  }
}