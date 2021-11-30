using Assets.Data;
using core.Data.elements;
using progression.equipment.data;
using world;

namespace progression.equipment
{
  public class EquipOnClick : VersionedDataBehaviour<EquipmentCardTypeData>
  {
    protected override void dirtyUpdate()
    {
    }

    public void OnClick()
    {
      var world = Finder.Find<GameWorld>();
      world.Player.EquipCard(component.CardBundleType, data.Composition);
    }
  }
}