using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using gameplay.enums;
using UnityEngine;

[Serializable]
public class CardBundleScheme : Scheme
{
  public StringTrait Name = new StringTrait("");
  public StringTrait Description = new StringTrait("");
  public SpriteTrait Image = new SpriteTrait(null,null);
  public StringListTrait Cards = new StringListTrait(new List<string>());
  public StringListTrait LevelUps = new StringListTrait(new List<string>());
  public CardBundleTrait BundleType = new CardBundleTrait(CardBundleTypes.Mutations);
  public PrimaryResourceTrait PrimaryResouce = new PrimaryResourceTrait(ResourceTypes.Essence);
  public static CardBundleScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/CardBundleScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/CardBundleScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<CardBundleScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/CardBundleScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}