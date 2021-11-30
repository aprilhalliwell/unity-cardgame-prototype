using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using UnityEngine;

[Serializable]
public class LevelUpScheme : Scheme
{
  public StringTrait Name = new StringTrait("");
  public StringTrait Description = new StringTrait("");
  public SpriteTrait Image = new SpriteTrait(null,null);
  public StringTrait LevelUpItem = new StringTrait("");

  public static LevelUpScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/LevelUpScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/LevelUpScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<LevelUpScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/LevelUpScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}