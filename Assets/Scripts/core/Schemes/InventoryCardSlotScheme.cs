using System;
using System.IO;
using Assets.Scheme;
using Assets.Scheme.Traits;
using UnityEngine;

[Serializable]
public class InventoryCardSlotScheme : Scheme
{
  public StringTrait Title = new StringTrait("");
  public StringTrait Description = new StringTrait("");
  public CardBundleTrait CardBundleTrait = new CardBundleTrait(CardBundleTypes.Concoctions);
  public static InventoryCardSlotScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/InventoryCardSlotScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/InventoryCardSlotScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<InventoryCardSlotScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/InventoryCardSlotScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}