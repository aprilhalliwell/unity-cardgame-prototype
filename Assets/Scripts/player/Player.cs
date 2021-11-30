using System.Collections.Generic;
using System.Linq;
using Assets.Data;
using player.data;
using progression.cardBundles.data;
using progression.equipment.data;

public abstract class Player 
{
  
  public Player()
  {
    PlayerStats.Add(new ExperienceData(0));
  }
  public List<ElementComposition> InventoryItemsSlots = new List<ElementComposition>();
  public List<ElementComposition> InventoryCardSlots = new List<ElementComposition>();
  public Dictionary<CardBundleTypes,List<ElementComposition>> CardItems = new Dictionary<CardBundleTypes, List<ElementComposition>>();
  public Dictionary<EquipmentTypes,List<ElementComposition>> EquipmentItems = new Dictionary<EquipmentTypes, List<ElementComposition>>();

  public Dictionary<CardBundleTypes,ElementComposition> EquippedCards = new Dictionary<CardBundleTypes, ElementComposition>();
  public Dictionary<EquipmentTypes,ElementComposition> EquippedItems = new Dictionary<EquipmentTypes, ElementComposition>();
  public ElementComposition LevelUpData = new ElementComposition();

  public ElementComposition PlayerStats = new ElementComposition();
  public void EquipCard(CardBundleTypes cardType, ElementComposition composition)
  {
    EquippedCards[cardType] = composition;
    var inventorySlot = InventoryCardSlots.Find(x => x.Get<EquipmentCardTypeData>().CardBundleType == cardType);
    inventorySlot.Get<EquipedSlotData>().UpdateEquipment(composition);
  }

  public bool IsMixingEnalbed()
  {
    return EquippedCards.Values.ToList().Exists(comp =>
      comp.Get<CardItemsData>().Data
        .Exists(x => x == "blood_root" || x == "foamcap" || x == "vefiram" || x == "night_cap"));
  }

  public abstract void InitializePlayer();
  public abstract void SetupStatsForGame();
}