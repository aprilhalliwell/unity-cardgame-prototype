using System.Collections.Generic;

namespace DefaultNamespace
{
  public class CardDetails
  {
    List<string> CardAffliates = new List<string>
    {
      "Fire",
      "Water",
      "Earth",
      "Air",
      "Mystic",
      "Decay",
      "Lightning",
      "Ice",
      "Smoke"
    };
    
    Dictionary<string,List<(string,int)>> afiliateSpendersProbabilities = new Dictionary<string, List<(string,int)>>
    {
      {"Fire", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Water", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 5),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Earth", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Air", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Mystic", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Decay", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Lightning", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Ice", new List<(string,int)>
      {
        ("Damage", 35),
        ("Block", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Stun Target", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }},
      {"Smoke", new List<(string,int)>
      {
        ("Block", 25),
        ("Stun Target", 20),
        ("Damage", 15),
        ("All Target", 10),
        ("Additional Target", 10),
        ("Draw Card", 10),
        ("Reduce Energy", 5),
        ("Reduce Essence", 5),
        ("Energy", 5),
        ("Essence", 0),
        ("Shuffle Discard", 0),
      }}
      
      
    };
  }
}