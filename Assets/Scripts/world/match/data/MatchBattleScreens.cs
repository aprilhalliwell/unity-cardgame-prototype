using Assets.Data;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using System.Collections.Generic;

namespace world.match.data
{
  public class MatchBattleScreens: VersionedDataElement
  {
    public List<string> Matches { get; private set; }

    public MatchBattleScreens(StringListTrait screens)
    {
      Matches = screens.Items;
    }
    public MatchBattleScreens(List<string> screens)
    {
      Matches = screens;
    }


    public void Update(List<string> matches)
    {
      Matches = matches;
      markDirty();
    }
    public override DataElement Clone()
    {
      return new MatchBattleScreens(new List<string>(Matches));
    }
  }
}