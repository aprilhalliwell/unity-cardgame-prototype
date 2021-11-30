using System.Collections.Generic;
using Assets.Data;

namespace player.data
{
  public class PlayerCardBundles : VersionedDataElement
  {
    public List<string> CardBundles;

    public PlayerCardBundles(List<string> cardBundles)
    {
      CardBundles = cardBundles;
    }

    public void Update(string cardBundle)
    {
      
    }
    
  }
}