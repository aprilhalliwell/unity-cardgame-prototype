using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.enums;
using gameplay.match;
using gameplay.match.EntityData;
using UnityEngine;
using UnityEngine.UI;

namespace gameplay.card
{
  public class CardPlayableHandler : VersionedDataBehaviour<CardDataCost>
  {
    [SerializeField] private GraphicRaycaster caster;
    [SerializeField] private Image CardFront;
    
    
    private ElementComposition playerComp;
    private EntityStaminaData cachedStaminaComp;
    private EntityEssenceData cachedEssenceComp;
    private EntityChargeData cachedChargeComp;

    protected override ulong Version
    {
      get
      {
        var version = component.Version;
        if (cachedStaminaComp != null)
        {
          version += cachedStaminaComp.Version;
        }

        if (cachedEssenceComp != null)
        {
          version += cachedEssenceComp.Version;
        }

        if (cachedChargeComp != null)
        {
          version += cachedChargeComp.Version;
        }

        return version;
      }
    }

    protected override void awake()
    {
      caster = GetComponent<GraphicRaycaster>();
    }

    protected override void start()
    {
      playerComp = MatchState.PlayerComposition();
      cachedStaminaComp = playerComp.Get<EntityStaminaData>();
      cachedEssenceComp = playerComp.Get<EntityEssenceData>();
      if (playerComp.Has<EntityChargeData>())
      {
        cachedChargeComp = playerComp.Get<EntityChargeData>();
      }
      base.start();
    }

    public bool CanAfford()
    {
      var canAfford = true;
      foreach (var resourceCost in component.Costs)
      {
        switch (resourceCost.ResourceTypes)
        {
          case ResourceTypes.Essence:
            if (canAfford)
            {
              canAfford = cachedEssenceComp.CurrentEssence - resourceCost.Cost >= 0;
            }
            break;
          case ResourceTypes.Stamina:
            if (canAfford)
            {
              canAfford = cachedStaminaComp.CurrentStamina - resourceCost.Cost >= 0;
            }
            break;
          case ResourceTypes.Charge:
            if (canAfford && cachedChargeComp != null)
            {
                canAfford = cachedChargeComp.CurrentCharge - resourceCost.Cost >= 0;
            }
            break;
          default:
            if (canAfford)
            {
              canAfford = false;
            }
            break;
        }
      }

      return canAfford;
    }

    protected override void dirtyUpdate()
    {
      if (CanAfford())
      {
        caster.enabled = true;
        CardFront.color = Color.white;
      }
      else
      {
        caster.enabled = false;
        CardFront.color = Color.gray;
      }
    }
  }
}