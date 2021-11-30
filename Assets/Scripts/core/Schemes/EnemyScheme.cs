using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using System;
using System.Collections.Generic;
using System.IO;
using gameplay.enums;
using UnityEngine;

[Serializable]
public class EnemyScheme : Scheme
{
  public IntTrait Rank = new IntTrait(1);
  public IntTrait Health = new IntTrait(0);
  /// <summary>
  /// The name of the character
  /// </summary>
  public StringTrait Name = new StringTrait("");

  /// <summary>
  /// An icon that represents this character
  /// </summary>
  public SpriteTrait EnemyImage = new SpriteTrait(null,null);

  public PrefabTrait EnemyPrefap = new PrefabTrait(null);
  public AbilityListTrait Abilities = new AbilityListTrait(new List<Ability>());

  /// <summary>
  /// Given a scheme name generate a character scheme class
  /// </summary>
  /// <param name="Name">Name of a character scheme</param>
  /// <returns></returns>
  public static EnemyScheme CreateEnemy(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/EnemyScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/EnemyScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<EnemyScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/EnemyScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}