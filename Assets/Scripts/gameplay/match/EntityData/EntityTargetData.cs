using Assets.Data;
using gameplay.enums;
using gameplay.match.PlayerData;

namespace gameplay.match.EntityData
{
  public class EntityTargetData: VersionedDataElement
  {
    public Targets Target;

    public EntityTargetData(Targets target)
    {
      Target = target;
    }
  }
}