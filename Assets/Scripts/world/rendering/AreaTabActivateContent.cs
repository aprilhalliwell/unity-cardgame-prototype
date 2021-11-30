using area.data;
using Assets.Data;
using core.Data.elements;
using PixelsoftGames.PixelUI;

namespace world.rendering
{
  public class AreaTabActivateContent : TypedDataBehaviour<IdAndIndexData>
  {
    public void OnClick()
    {
      var comps = Finder.Find<GameWorld>().AreaCompositions;
      foreach (var comp in comps)
      {
        if (comp.Get<IdAndIndexData>().Index == component.Index)
        {
          comp.Get<AreaActiveTab>().Active = true;
        }
        else
        {
          comp.Get<AreaActiveTab>().Active = false;
        }
      }
    }
  }
}