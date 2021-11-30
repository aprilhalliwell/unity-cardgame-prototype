using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using core.SchemeLayout.Traits.BaseTraits;
using gameplay.enums;
using UnityEngine;
[Serializable]
public class CardStackScheme : Scheme
{
  public List<CardStackTrait> CardStackTraits = new List<CardStackTrait>();
  public static CardStackScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/CardStackScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/CardStackScheme/" + Name).text;
    }
    var instance = JsonUtility.FromJson<CardStackScheme>(scheme);
    return instance;
  }

  public void Save(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/CardStackScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}