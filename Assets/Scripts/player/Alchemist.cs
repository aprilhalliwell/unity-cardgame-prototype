using System.Collections.Generic;
using System.Linq;
using Assets.Data;
using Assets.Scheme.Traits;
using core.Data.elements;
using gameplay.enums;
using player.data;
using progression.cardBundles.data;
using progression.equipment.data;

namespace player
{
  public class Alchemist : Player
  {
    public Alchemist() : base()
    {
      PlayerStats.Add(new MixingSlotCountData(2));
    }
    public override void SetupStatsForGame()
    {
      var stats = new HashSet<PlayerStat>
      {
        new PlayerStat(ResourceTypes.Essence, 0, 10),
        new PlayerStat(ResourceTypes.Health, 10, 10),
        new PlayerStat(ResourceTypes.Stamina, 10, 10),
        new PlayerStat(ResourceTypes.Shield, 0, 10)
      };
      foreach (var equippedCard in EquippedCards)
      {
        if (equippedCard.Value.Has<PrimaryResourceData>())
        {
          switch (equippedCard.Value.Get<PrimaryResourceData>().PrimaryResource)
          {
            case ResourceTypes.Charge:
              
              stats.Add(new PlayerStat(ResourceTypes.Charge, 0, 3));
              break;
          }
        }
      }

      if (PlayerStats.Has<PlayerStats>())
      {
        PlayerStats.Get<PlayerStats>().Update(stats.ToList());
      }
      else
      {
        PlayerStats.Add(new PlayerStats(stats.ToList()));
      }
    }

    public System.Collections.Generic.List<string> InventoryItemSlotsSchemes = new System.Collections.Generic.List<string>
    {
      "essoteric_slot",
      "mind_slot",
      "rune_slot"
    };

    public System.Collections.Generic.List<string> InventoryCardSlotsSchemes = new System.Collections.Generic.List<string>
    {
      "concoction_slot",
      "formulas_slot",
      "mutagen_slot"
    };

    public System.Collections.Generic.List<string> UnlockedCardBundles = new System.Collections.Generic.List<string>
    {
      "alchemicalmind",
      "guidetoalchemy",
      "batchofelixirs",
      "batchoftonics",
      "gryphon",
      "guidetobatteries",
      "clay_golem",
      "batchofherbs",
      "guidetocontainers",
      "abyssal_dragon",
      "batchofmandrake",
      "guidetotwilight"
    };

    public override void InitializePlayer()
    {
      CreateInventoryItems();
      //Create Empty Data
      EquippedItems.Add(EquipmentTypes.Alchemical_Mind, new ElementComposition());
      EquippedItems.Add(EquipmentTypes.Esoteric_Studies, new ElementComposition());
      EquippedItems.Add(EquipmentTypes.Rune_Stone, new ElementComposition());
      CreateInventoryItemSlots();
      EquipCard(CardBundleTypes.Concoctions,CardItems[CardBundleTypes.Concoctions][3]);
      EquipCard(CardBundleTypes.Formulas,CardItems[CardBundleTypes.Formulas][3]);
      EquipCard(CardBundleTypes.Mutations,CardItems[CardBundleTypes.Mutations][3]);
    }
    
    
    void CreateInventoryItems()
    {
      //initialize data structures
      EquipmentItems.Add(EquipmentTypes.Alchemical_Mind, new System.Collections.Generic.List<ElementComposition>());
      EquipmentItems.Add(EquipmentTypes.Esoteric_Studies, new System.Collections.Generic.List<ElementComposition>());
      EquipmentItems.Add(EquipmentTypes.Rune_Stone, new System.Collections.Generic.List<ElementComposition>());
      CardItems.Add(CardBundleTypes.Concoctions, new System.Collections.Generic.List<ElementComposition>());
      CardItems.Add(CardBundleTypes.Formulas, new System.Collections.Generic.List<ElementComposition>());
      CardItems.Add(CardBundleTypes.Mutations, new System.Collections.Generic.List<ElementComposition>());
      foreach (var cardBundle in UnlockedCardBundles)
      {
        var scheme = CardBundleScheme.Create(cardBundle);
        System.Collections.Generic.List<ElementComposition> levelUpData = new System.Collections.Generic.List<ElementComposition>();
        foreach (var item in scheme.LevelUps.Items)
        {
          var levelupScheme = LevelUpScheme.Create(item);
          levelUpData.Add(new ElementComposition(
            new DescriptionData(levelupScheme.Description),
            new TitleData(levelupScheme.Name),
            new ImageData(levelupScheme.Image)));
        }

        CardItems[scheme.BundleType.CardBundleType].Add(new ElementComposition(
          new CardItemsData(scheme.Cards.Items),
          new PrimaryResourceData(scheme.PrimaryResouce.Resource),
          new LevelUpData(levelUpData),
          new EquipmentCardTypeData(scheme.BundleType.CardBundleType),
          new DescriptionData(scheme.Description),
          new TitleData(scheme.Name),
          new ImageData(scheme.Image)
        ));
      }
    }
    
    void CreateInventoryItemSlots()
    {
      foreach (var cardSlot in InventoryCardSlotsSchemes)
      {
        var cardSlotScheme = InventoryCardSlotScheme.Create(cardSlot);
        InventoryCardSlots.Add(new ElementComposition(
            new TitleData(cardSlotScheme.Title),
            new DescriptionData(cardSlotScheme.Description),
            new EquipedSlotData(null),
            new EquipmentCardTypeData(cardSlotScheme.CardBundleTrait.CardBundleType)
          )
        );
      }

      foreach (var itemSlot in InventoryItemSlotsSchemes)
      {
        var itemSlotScheme = InventoryItemSlotScheme.Create(itemSlot);
        InventoryItemsSlots.Add(new ElementComposition(
            new TitleData(itemSlotScheme.Title),
            new DescriptionData(itemSlotScheme.Description),
            new EquipedSlotData(null),
            new EquipmentItemTypeData(itemSlotScheme.EquipmentType.EquipmentType)
          )
        );
      }
    }
  }
}