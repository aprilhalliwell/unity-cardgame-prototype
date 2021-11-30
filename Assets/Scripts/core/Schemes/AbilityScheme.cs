using Assets.Scheme;
using Assets.Scheme.Traits;
using Assets.Scheme.Traits.BaseTraits;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*
  {
    "script": "DrawCard",
    "target": "Player",
    "amount": 1,
    "kind": "Alchemical",
     "options":[
                {
                    "chance": 90,
                    "name": "Lumbering Bear",
                 },
                 {
                    "chance": 40,
                    "name": "Black Bear",
                 },
                 {
                    "chance": 10,
                    "name": "Polar Bear",
                 },
                 {
                    "chance": 10,
                    "name": "Gentle Breeze",
                 }
            ],
  }
 */
/// <summary>
/// The card scheme. Reads a json file to create an instance of this class.
/// 
/// </summary>
[Serializable]
public class AbilitySchema : Scheme
{
    public IntTrait Amount = new IntTrait(1);
    public StringTrait Script = new StringTrait("");
    public StringTrait Target = new StringTrait("");
    public ListAbilityOptionTrait Abilities = new ListAbilityOptionTrait(new List<AbilityOption>());
    public StringTrait Kind = new StringTrait("");

    public static AbilitySchema CreateAbility(string Name)
    {
        var filePath = string.Concat(Application.persistentDataPath, "/Scheme/AbilityScheme/", Name);
        var scheme = "";
        scheme = File.Exists(filePath) ? File.ReadAllText(filePath) : Resources.Load<TextAsset>("Schemes/" + Name).text;
        var instance = JsonUtility.FromJson<AbilitySchema>(scheme);
        return instance;
    }

    public void SaveScheme(string name)
    {
        var json = JsonUtility.ToJson(this, true);
        var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/AbilityScheme/" + name + ".json");
        sr.Write(json);
        sr.Close();
    }
}