using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using UnityEngine;

[Serializable]
public class EquipmentScheme : Scheme
{
  public StringTrait Title = new StringTrait("");
  public StringTrait Description = new StringTrait("");
  public AbilityListTrait Abilities = new AbilityListTrait(new List<Ability>());
  public SpriteTrait Image = new SpriteTrait(null,null);

  public static EquipmentScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/EquipmentScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/EquipmentScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<EquipmentScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/EquipmentScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}