using System.Collections.Generic;
using System.Linq;
using Assets.Data;
using core.SchemeLayout.Traits.BaseTraits;
using gameplay.abilities;
using gameplay.abilities.card;
using gameplay.abilities.enemy;
using gameplay.card.data.rendering;
using gameplay.enemies.data;
using gameplay.enums;
using gameplay.hover;
using gameplay.match.EntityData;
using gameplay.match.PlayerData;
using gameplay.mixingTable.data;
using player.data;
using world;

namespace gameplay.match
{
  public static class MatchFactories
  {
    public static ElementComposition CreateCard(string cardFile, bool singleUse)
    {
      if (CardScheme.DoesCardExist(cardFile))
      {
        return GenerateCard(CardScheme.CreateCard(cardFile), singleUse,new List<ElementComposition>());
      }

      CardStackScheme scheme = CardStackScheme.Create(cardFile);
      var baseCard = scheme.CardStackTraits.Find(x => x.predicate == PredicateType.Noop);
      var altCards = scheme.CardStackTraits.Where(x => x.predicate != PredicateType.Noop).Select(x =>
        GenerateAltCard(x.cardScheme, x.GetPredicate(), singleUse)).ToList();
      return GenerateCard(baseCard.cardScheme, singleUse, altCards);
    }

    public static ElementComposition GenerateAltCard(CardScheme scheme,ICardPredicate predicate, bool singleUse)
    {
      List<CardAbility> abilities = new List<CardAbility>(scheme.Abilities.Items.Count);
      foreach (var ability in scheme.Abilities.Items)
      {
        abilities.Add(AbilityFactory.GenerateCardAbility(ability));
      }

      List<CardAbility> discardAbilities = new List<CardAbility>();
      if (singleUse)
      {
        discardAbilities.Add(new CardConsumed());
      }
      else
      {
        discardAbilities.Add(new CardUsed());
      }

      return new ElementComposition(
        new CardDataID(),
        new CardPredicateData(predicate),
        new CardDataHandPosition(),
        new CardDataAbilities(abilities, discardAbilities),
        new CardDataInteractiveState(CardInteractive.Normal),
        new CardDataCost(scheme.Resource),
        new CardDataImage(scheme.CardImage),
        new CardDataName(scheme.Name),
        new CardDataText(scheme.GameText)
      );
    }
    public static ElementComposition GenerateCard(CardScheme scheme, bool singleUse, List<ElementComposition> altCards)
    {
      List<CardAbility> abilities = new List<CardAbility>(scheme.Abilities.Items.Count);
      foreach (var ability in scheme.Abilities.Items)
      {
        abilities.Add(AbilityFactory.GenerateCardAbility(ability));
      }

      List<CardAbility> discardAbilities = new List<CardAbility>();
      if (singleUse)
      {
        discardAbilities.Add(new CardConsumed());
      }
      else
      {
        discardAbilities.Add(new CardUsed());
      }
      return new ElementComposition(
        new CardDataID(),
        new CardAltData(altCards),
        new CardDataHandPosition(),
        new CardDataAbilities(abilities, discardAbilities),
        new CardDataInteractiveState(CardInteractive.Normal),
        new CardDataCost(scheme.Resource),
        new CardDataImage(scheme.CardImage),
        new CardDataName(scheme.Name),
        new CardDataText(scheme.GameText)
      );
    }

    public static ElementComposition CreateEnemies(EnemyScheme scheme, int slot)
    {
      List<EnemyAbility> abilities = new List<EnemyAbility>(scheme.Abilities.Items.Count);
      foreach (var ability in scheme.Abilities.Items)
      {
        abilities.Add(AbilityFactory.GenerateEnemyAbility(ability));
      }

      return new ElementComposition(
        new EntityTargetData(Targets.Enemy),
        new EntityStatusData(),
        new EntityIDData(slot),
        new EnemyAbilityData(abilities, new List<EnemyAbility>()),
        new EnemyDataInteractiveState(PileInteractiveStates.Normal),
        new EntityHealthData(scheme.Health.Amount, scheme.Health.Amount),
        new EnemyDataPrefab(scheme.EnemyPrefap)
      );
    }

    public static ElementComposition CreatePlayer(List<ElementComposition> cards, PileLocations locations)
    {
      var world = Finder.Find<GameWorld>();
      var stats = world.Player.PlayerStats.Get<PlayerStats>();
      var slots = world.Player.PlayerStats.Get<MixingSlotCountData>().Slots;
      List<ElementComposition> slotsComps = new List<ElementComposition>(slots);
      for (int i = 0; i < slots; i++)
      {
        slotsComps.Add(new ElementComposition(
          new MixingSlotInteractiveStateData(PileInteractiveStates.Normal),
          new MixingSlotSelectedCardData()
        ));
      }

      var playerComposition = new ElementComposition(
        new EntityTargetData(Targets.Player),
        new EntityDeckData(cards, locations.Deck),
        new EntityPresentData(locations.Present),
        new EntityDiscardData(locations.Discard),
        new EntityMixingTableData(slotsComps, locations.Mixing),
        new EntityHoverSelectedCardData(),
        new EntityHandData()
      );
      var validResources = new List<ResourceTypes>
      {
        ResourceTypes.Essence,
        ResourceTypes.Health,
        ResourceTypes.Shield,
        ResourceTypes.Stamina
      };
      foreach (var playerStat in stats.Stats)
      {
        switch (playerStat.ResourceTypes)
        {
          case ResourceTypes.Charge:
            if (!playerComposition.Has<EntityChargeData>())
            {
              validResources.Add(ResourceTypes.Charge);
              playerComposition.Add(new EntityChargeData(playerStat.MaxStat, playerStat.CurrentStat));
            }

            break;
          case ResourceTypes.Essence:
            playerComposition.Add(new EntityEssenceData(playerStat.MaxStat, playerStat.CurrentStat));
            break;
          case ResourceTypes.Health:
            playerComposition.Add(new EntityHealthData(playerStat.MaxStat, playerStat.CurrentStat));
            break;
          case ResourceTypes.Shield:
            playerComposition.Add(new EntityShieldData(playerStat.MaxStat, playerStat.CurrentStat));
            break;
          default:
            playerComposition.Add(new EntityStaminaData(playerStat.MaxStat, playerStat.CurrentStat));
            break;
        }
      }

      playerComposition.Add(new EntityValidResources(validResources));
      return playerComposition;
    }
  }
}