using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using System;
using System.Collections.Generic;
using System.IO;
using gameplay.enums;
using UnityEngine;

[Serializable]
public class MatchScheme : Scheme
{
  public IntTrait HealthPool = new IntTrait(0);
  public StringListTrait PotentialEnemies = new StringListTrait(new List<string>());
  public BooleanTrait UseAllEnemies = new BooleanTrait(false);
  public SpriteTrait MatchPreview = new SpriteTrait(null,null);
  public StringListTrait BattleScreens = new StringListTrait(new List<string>());
  public static MatchScheme CreateMatch(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/MatchScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/MatchScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<MatchScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/MatchScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}