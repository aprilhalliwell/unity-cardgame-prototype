using System;
using System.IO;
using Assets.Scheme;
using Assets.Scheme.Traits;
using UnityEngine;

[Serializable]
public class InventoryItemSlotScheme : Scheme
{
  public StringTrait Title = new StringTrait("");
  public StringTrait Description = new StringTrait("");
  public EquipmentTypesTrait EquipmentType= new EquipmentTypesTrait(EquipmentTypes.Alchemical_Mind);

  public static InventoryItemSlotScheme Create(string Name)
  {
    string filePath = string.Concat(Application.persistentDataPath, "/Scheme/InventoryItemSlotScheme/", Name);
    string scheme = "";
    if (File.Exists(filePath))
    {
      scheme = File.ReadAllText(filePath);
    }
    else
    {
      scheme = Resources.Load<TextAsset>("Schemes/InventoryItemSlotScheme/" + Name).text;
    }

    var instance = JsonUtility.FromJson<InventoryItemSlotScheme>(scheme);
    return instance;
  }

  public void SaveScheme(string name)
  {
    var json = JsonUtility.ToJson(this, true);
    var sr = File.CreateText(Application.dataPath + "/Resources/Schemes/InventoryItemSlotScheme/" + name + ".json");
    sr.Write(json);
    sr.Close();
  }
}