using System.Collections.Generic;
using Assets.Data;
using gameplay.card.data.rendering;
using gameplay.match;
using UnityEngine;

namespace gameplay.mixingTable
{
  public static class MixingResults
  {
    private static Dictionary<string,int> order = new Dictionary<string, int>
    {
      {"Blood Root(M)",1},
      {"Vefiram(M)",2},
      {"Foamcap(M)",3},
      {"Night Cap(M)",4},
    };
    
    public static ElementComposition MixedCard(ElementComposition card1, ElementComposition card2)
    {
      var card1Name = card1.Get<CardDataName>().CardName;
      var card2Name = card2.Get<CardDataName>().CardName;
      //order our card names
      if (order[card2Name] < order[card1Name])
      {
        Debug.Log($"Swapping card order {card1Name} < {card2Name}");
        var temp = card1Name;
        card1Name = card2Name;
        card2Name = temp;
      }
      /* Vefiram(M) = Herb
       * Blood Root(M) = Damage
       * Night Cap(M) = Filler
       * Foamcap(M) = Bark
       */
      
      Debug.Log($"{card1Name},{card2Name}");
      if (card1Name == "Blood Root(M)" && card2Name == "Blood Root(M)") return MatchFactories.CreateCard("bloody_murder",true);
      if (card1Name == "Blood Root(M)" && card2Name == "Vefiram(M)")    return MatchFactories.CreateCard("purgative",true);
      if (card1Name == "Blood Root(M)" && card2Name == "Night Cap(M)")  return MatchFactories.CreateCard("noxious_fumes",true);
      if (card1Name == "Blood Root(M)" && card2Name == "Foamcap(M)")    return MatchFactories.CreateCard("mad_cap",true);
      if (card1Name == "Vefiram(M)" && card2Name == "Vefiram(M)")       return MatchFactories.CreateCard("panacea",true);
      if (card1Name == "Vefiram(M)" && card2Name == "Night Cap(M)")     return MatchFactories.CreateCard("fortuna_fortinaticus",true);
      if (card1Name == "Vefiram(M)" && card2Name == "Foamcap(M)")       return MatchFactories.CreateCard("rotted_mind",true);
      if (card1Name == "Night Cap(M)" && card2Name == "Night Cap(M)")   return MatchFactories.CreateCard("explosive_heart",true);
      if (card1Name == "Night Cap(M)" && card2Name == "Foamcap(M)")     return MatchFactories.CreateCard("imp_stool",true);
      if (card1Name == "Foamcap(M)" && card2Name == "Foamcap(M)")       return MatchFactories.CreateCard("honey_comb",true);
      return null;
    }
  }
}