using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using gameplay.enums;
using UnityEngine;

/*
 *  {
    "name" : "Potion of Clarity",
    "image": "asset",
    "rank": 1,
    "gameText": "Draw a card, than discard a card.",
    "cost":{
        "amount": 1,
        "kind" : "Stamina"
    },
    abilities:[
        {
            "script": "DrawCard",
            "target": "Player",
            "amount": 1,
        },
        {
            "script": "DiscardCard",
            "target": "Player",
            "amount": 1,
        }
    ]  
 }
 */
/// <summary>
/// The card scheme. Reads a json file to create an instance of this class.
/// 
/// </summary>
[Serializable]
public class CardScheme : Scheme
{
  /// <summary>
  /// The name of the character
  /// </summary>
  public StringTrait Name = new StringTrait("");

  /// <summary>
  /// Descriptive information about the character
  /// </summary>
  public StringTrait GameText = new StringTrait("");

  /// <summary>
  /// An icon that represents this character
  /// </summary>
  public SpriteTrait CardImage = new SpriteTrait(null,null);
  public ResourceTrait Resource = new ResourceTrait(new List<ResourceCost>());
  public AbilityListTrait Abilities = new AbilityListTrait(new List<Ability>());
  public EffectTrait Effect = new EffectTrait("");

  /// <summary>
  /// Given a scheme name generate a character scheme class
  /// </summary>
  /// <param name="Name">Name of a character scheme</param>
  /// <returns></returns>
  public static CardScheme CreateCard(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/CardScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/CardScheme/" + Name).text;
    }
    return JsonUtility.FromJson<CardScheme>(scheme);
  }
  public static bool DoesCardExist(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/CardScheme/", Name);
    if (File.Exists(filePath))
    {
      return true;
    }
    return Resources.Load<TextAsset>("Schemes/CardScheme/" + Name) != null;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/CardScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }

  public override string ToString()
  {
    StringBuilder sb = new StringBuilder();
    sb.Append("Card Scheme \n");
    sb.Append($"Name {Name.Text} \n");
    sb.Append($"Text {GameText.Text} \n");
    return sb.ToString();
  }
}