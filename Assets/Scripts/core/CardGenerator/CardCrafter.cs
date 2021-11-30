using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using gameplay.enums;
using UnityEngine;
using Random = System.Random;

[System.Serializable]
public class TempCard
{
  [SerializeField] public string rarities = "";
  [SerializeField] public List<string> cost = new List<string>();
  [SerializeField] public List<string> effects = new List<string>();
}

[Serializable]
public class CardCrafter
{
  PointRules pointRules = new PointRules();
  [SerializeField] List<CardScheme> commonCards = new List<CardScheme>();
  [SerializeField] List<CardScheme> uncommonCards = new List<CardScheme>();
  [SerializeField] List<CardScheme> rareCards = new List<CardScheme>();

  public CardCrafter(int numberOfCardsToMake)
  {
    Random rnd = new Random();
    for (int i = 0; i < numberOfCardsToMake; i++)
    {
      TempCard tempCard = new TempCard();
      //pick a rarity
      var rarity = pointRules.CardRaritieses[rnd.Next(0, 3)];
      tempCard.rarities = rarity.ToString();
      //get rules
      var maxPoints = pointRules.maxPointsPerRarity[rarity];
      var freePoints = pointRules.freePointsPerRarity[rarity];
      var wantedPoints = maxPoints;// rnd.Next(rnd.Next(0, 5) + freePoints, maxPoints);
      var leftOverPoints = wantedPoints - freePoints;
      //accrue enough points
      while (leftOverPoints != 0)
      {
        var potentialGainer = pointRules.pointsGainers[rnd.Next(0, pointRules.pointsGainers.Count)];
        if (leftOverPoints - potentialGainer.Item1 >= 0) // potenial is 2  left over is 1
        {
          leftOverPoints -= potentialGainer.Item1;
          tempCard.cost.Add(potentialGainer.Item3);
        }
      }

      //try and spend the points on abilities
      while (wantedPoints != 0)
      {
        var potentialSpender = pointRules.pointsSpenders[rnd.Next(0, pointRules.pointsSpenders.Count)];
        if (wantedPoints - potentialSpender.Item1 >= 0 && !tempCard.cost.Contains(potentialSpender.Item3))
        {
          if (potentialSpender.Item3 == "Additional Target"
              // && !tempCards.spenders.Contains("All Target")
              && !tempCard.effects.Contains("Damage")
              && !tempCard.effects.Contains("Stun Target"))
          {
          }
          else if (potentialSpender.Item3 == "All Target"
                   // && !tempCards.spenders.Contains("Additional Target")
                   && !tempCard.effects.Contains("Damage") 
                   && !tempCard.effects.Contains("Stun Target"))
          {
          }
          else if (potentialSpender.Item3 == "Shuffle Discard" && tempCard.effects.Contains("Shuffle Discard"))
          {
            
          }
          else
          {
            wantedPoints -= potentialSpender.Item1;
            if (potentialSpender.Item3 == "Damage" || potentialSpender.Item3 == "Block")
            {
              tempCard.effects.Add(potentialSpender.Item3);
            }
            tempCard.effects.Add(potentialSpender.Item3);
          }
        }
      }
      tempCard.effects = tempCard.effects.GroupBy(x => x).Select(x=>$"{x.Count()} x {x.Key}").ToList();
      tempCard.cost = tempCard.cost.GroupBy(x => x).Select(x=>$"{x.Count()} x {x.Key}").ToList();

      CardScheme scheme  =new CardScheme();
      string gameText = "";
      scheme.Name = new StringTrait("Test Card " + i.ToString());
      foreach (var cardEffect in tempCard.effects)
      {
        var split = cardEffect.Split(new string[1]{" x "},StringSplitOptions.None);
        var ability = new Ability();
        gameText += cardEffect + "\n";
        ability.Amount = int.Parse(split[0]);
        ability.ScriptName = split[1];
        ability.Target = Targets.Enemy;
        scheme.Abilities.Items.Add(ability);
      }
      foreach (var cost in tempCard.cost)
      {
        var split = cost.Split(new string[1]{" x "},StringSplitOptions.None);
        var resourceCost = new ResourceCost();
        resourceCost.Cost = int.Parse(split[0]);
        resourceCost.ResourceTypes = (ResourceTypes)Enum.Parse(typeof(ResourceTypes), split[1], false);

        scheme.Resource.Items.Add(resourceCost);
      }
      scheme.CardImage = new SpriteTrait("package_potions_512x/potion_icons_256x/256x_beaker_red",null);
      scheme.GameText = new StringTrait(gameText);
      switch (rarity)
      {
        case PointRules.CardRarities.Common:
          commonCards.Add(scheme);
          break;
        case PointRules.CardRarities.Uncommon:
          uncommonCards.Add(scheme);
          break;
        case PointRules.CardRarities.Rare:
          rareCards.Add(scheme);
          break;
      }
    }
    

    var json = JsonUtility.ToJson(this, true);
    Debug.Log(json);
    var sr = File.CreateText(Application.dataPath + "/Resources/tempCards.json");
    sr.Write(json);
    sr.Close();
  }
}