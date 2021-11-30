using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using UnityEngine;

[Serializable]
public class RoomScheme : Scheme
{
  public StringTrait RoomName = new StringTrait("");
  public IntTrait RoomRow = new IntTrait(0);
  public StringListTrait NextRooms = new StringListTrait(new List<string>());
  public StringListTrait Matches = new StringListTrait(new List<string>());
  public StringListTrait Rewards = new StringListTrait(new List<string>());
  public SpriteTrait Image = new SpriteTrait("",null);
  public static RoomScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/RoomScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/RoomScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<RoomScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/RoomScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}