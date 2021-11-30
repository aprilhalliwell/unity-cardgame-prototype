using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using UnityEngine;

[Serializable]
public class AreaScheme : Scheme
{
  public StringTrait AreaDescription = new StringTrait("");
  public StringTrait AreaName = new StringTrait("");
  public StringTrait StartRoom = new StringTrait("");
  public static AreaScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/AreaScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/AreaScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<AreaScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/AreaScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}