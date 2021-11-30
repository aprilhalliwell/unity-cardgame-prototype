using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using Assets.Scheme;
using System.IO;
using Assets.Scheme.Traits;
using System.Reflection;
using Assets.Scheme.Traits.BaseTraits;
using core.SchemeLayout.Traits.BaseTraits;
using UnityEditor.Animations;
using Editor.Utils;
using Editor;
using gameplay.abilities;
using gameplay.enums;

namespace Assets.MapPainter.Editor
{
  /// <summary>
  /// Creates a scheme which is used to generate the data for a character.
  /// </summary>
  class SchemeCreationView : WindowView
  {
    /// <summary>
    /// Name of our scheme
    /// </summary>
    string schemeName = "";

    /// <summary>
    /// Base Scheme class
    /// </summary>
    Scheme.Scheme scheme;

    /// <summary>
    /// Current scheme mode
    /// </summary>
    SchemeMode schemeMode = SchemeMode.Create;
    
    SchemeFilters schemeFilters = SchemeFilters.All;


    /// <summary>
    /// List of json scheme names
    /// </summary>
    List<string> names = new List<string>();

    /// <summary>
    /// List of c# schemes
    /// </summary>
    List<string> schemes = new List<string>();

    Dictionary<string,string> schemeToPath = new Dictionary<string, string>();

    /// <summary>
    /// List of traits for a given scheme
    /// </summary>
    Dictionary<string, object> traits = new Dictionary<string, object>();

    /// <summary>
    /// All fields that are part of a scheme
    /// </summary>
    FieldInfo[] fields;

    /// <summary>
    /// Current scroll position
    /// </summary>
    Vector2 scrollPos = Vector2.zero;

    /// <summary>
    /// Selected scheme to edit
    /// </summary>
    int schemeSelection = 0;

    /// <summary>
    /// Selected kind of scheme
    /// </summary>
    int selectedScheme = 0;

    /// <summary>
    /// Renders our scheme view
    /// </summary>
    protected override void Render()
    {
      schemeMode = (SchemeMode) GUILayout.SelectionGrid((int) schemeMode, MapPainterConstants.EventChoicesLabels, 3,
        EditorStyles.toolbarButton);
      switch (schemeMode)
      {
        case SchemeMode.Edit:
          EditScheme();
          break;
        case SchemeMode.Create:
          CreateScheme();
          break;
      }
    }

    /// <summary>
    /// Selects an available Schemes
    /// </summary>
    void SelectScheme()
    {
      GUILayout.Label("Select Scheme", EditorStyles.boldLabel);
      string[] foldersToSearch;
      if (AssetDatabase.IsValidFolder("Assets/Scripts/CustomSchemes"))
      {
        foldersToSearch = new string[] {"Assets/Scripts/core/Schemes", "Assets/Scripts/CustomSchemes"};
      }
      else
      {
        foldersToSearch = new string[] {"Assets/Scripts/core/Schemes"};
      }

      var guids = AssetDatabase.FindAssets("", foldersToSearch);
      names.Clear();
      foreach (var guid in guids)
      {
        var path = AssetDatabase.GUIDToAssetPath(guid).Split('/');
        names.Add(path[path.Length - 1].Replace(".cs", ""));
      }

      selectedScheme = GUILayout.SelectionGrid(selectedScheme, names.ToArray(), 3, EditorStyles.miniButton);
    }

    /// <summary>
    /// Creates a scheme based on selections
    /// </summary>
    void CreateScheme()
    {
      if (scheme == null)
      {
        SelectScheme();
        if (GUILayout.Button("Create Scheme?"))
        {
          if (names[selectedScheme] == "AbilityScheme")
          {
            scheme = new AbilitySchema();
          }
          else if (names[selectedScheme] == "EnemyScheme")
          {
            scheme = new EnemyScheme();
          }
          else if (names[selectedScheme] == "AreaScheme")
          {
            scheme = new AreaScheme();
          }
          else if (names[selectedScheme] == "RoomScheme")
          {
            scheme = new RoomScheme();
          }
          else if (names[selectedScheme] == "MatchScheme")
          {
            scheme = new MatchScheme();
          }
          else if (names[selectedScheme] == "CardBundleScheme")
          {
            scheme = new CardBundleScheme();
          }
          else if (names[selectedScheme] == "EquipmentScheme")
          {
            scheme = new EquipmentScheme();
          }
          else if (names[selectedScheme] == "LevelUpScheme")
          {
            scheme = new LevelUpScheme();
          }
          else if (names[selectedScheme] == "InventoryCardSlotScheme")
          {
            scheme = new InventoryCardSlotScheme();
          }
          else if (names[selectedScheme] == "InventoryItemSlotScheme")
          {
            scheme = new InventoryItemSlotScheme();
          }
          else if (names[selectedScheme] == "CardStackScheme")
          {
            scheme = new CardStackScheme();
          }
          else
          {
            scheme = new CardScheme();
          }
          fields = scheme.GetType().GetFields();

          InitTraits(traits,fields,scheme);
        }
      }
      else
      {
        RemoveScheme();
        GUILayout.Label("Scheme Name", EditorStyles.boldLabel);
        schemeName = GUILayout.TextField(schemeName);
        SetTraits(traits,fields,false,scheme);
        SaveScheme(false);
      }
    }

    /// <summary>
    /// Removes a scheme from being used.
    /// </summary>
    private void RemoveScheme()
    {
      if (GUILayout.Button("Back"))
      {
        scheme = null;
        traits.Clear();
        fields = null;
      }
    }

    public string[] getFoldersToSearch()
    {
      switch (schemeFilters)
      {
        case SchemeFilters.Area:
          return new [] { "Assets/Resources/Schemes/AreaScheme"};
        case SchemeFilters.Card:
          return new [] { "Assets/Resources/Schemes/CardScheme","Assets/Resources/Schemes/CardStackScheme"};
          case SchemeFilters.Enemy:
          return new [] {"Assets/Resources/Schemes/EnemyScheme"};
          case SchemeFilters.Equipment:
          return new [] {"Assets/Resources/Schemes/EquipmentScheme"};
          case SchemeFilters.Match:
          return new [] {"Assets/Resources/Schemes/MatchScheme"};
          case SchemeFilters.Rooms:
          return new [] {"Assets/Resources/Schemes/RoomScheme"};
          case SchemeFilters.CardBundle:
          return new [] {"Assets/Resources/Schemes/CardBundleScheme"};
          case SchemeFilters.InventoryCards:
          return new [] { "Assets/Resources/Schemes/InventoryCardSlotScheme"};
          case SchemeFilters.InventoryItems:
          return new [] {"Assets/Resources/Schemes/InventoryItemSlotScheme"};
          case SchemeFilters.LevelUp:
          return new [] {"Assets/Resources/Schemes/LevelUpScheme"};
          default:
            return new [] {"Assets/Resources/Schemes/AbilityScheme", "Assets/Resources/Schemes/CardScheme", "Assets/Resources/Schemes/EnemyScheme", "Assets/Resources/Schemes/AreaScheme", "Assets/Resources/Schemes/RoomScheme", "Assets/Resources/Schemes/MatchScheme", "Assets/Resources/Schemes/CardBundleScheme", "Assets/Resources/Schemes/InventoryCardSlotScheme", "Assets/Resources/Schemes/EquipmentScheme", "Assets/Resources/Schemes/InventoryItemSlotScheme", "Assets/Resources/Schemes/LevelUpScheme"};
      }
    }
    
    /// <summary>
    /// Edits an existing scheme
    /// </summary>
    /// <param name="currentData">Current map data</param>
    void EditScheme()
    {
      schemeFilters = (SchemeFilters) GUILayout.SelectionGrid((int) schemeFilters, MapPainterConstants.SchemeFilterChoicesLabels, 10,
        EditorStyles.toolbarButton);
      
      
      if (scheme == null)
      {
        string[] foldersToSearch = getFoldersToSearch();
        
        var guids = AssetDatabase.FindAssets("", foldersToSearch);
        schemes.Clear();
        foreach (var guid in guids)
        {
          var originalPath = AssetDatabase.GUIDToAssetPath(guid);
          var path = originalPath.Split('/');
          var schemeName = path[path.Length - 1].Replace(".json", "");
          schemes.Add(schemeName);
          schemeToPath[schemeName] = originalPath;
        }

        schemeSelection = GUILayout.SelectionGrid(schemeSelection, schemes.ToArray(), 3, EditorStyles.miniButton);
        if (GUILayout.Button("Edit Scheme"))
        {
          schemeName = schemes[schemeSelection];
          switch (schemeToPath[schemeName])
          {
            case string t when t.Contains("CardScheme"):
              names[selectedScheme] = "CardScheme";
              scheme = CardScheme.CreateCard(schemeName);
              break;
            case string t when t.Contains("CardStackScheme"):
              names[selectedScheme] = "CardStackScheme";
              scheme = CardStackScheme.Create(schemeName);
              break;
            case string t when t.Contains("AbilityScheme"):
              names[selectedScheme] = "AbilityScheme";
              scheme = AbilitySchema.CreateAbility(schemeName);
              break;
            case string t when t.Contains("EnemyScheme"):
              names[selectedScheme] = "EnemyScheme";
              scheme = EnemyScheme.CreateEnemy(schemeName);
              break;
            case string t when t.Contains("AreaScheme"):
              names[selectedScheme] = "AreaScheme";
              scheme = AreaScheme.Create(schemeName);
              break;
            case string t when t.Contains("RoomScheme"):
              names[selectedScheme] = "RoomScheme";
              scheme = RoomScheme.Create(schemeName);
              break;
            case string t when t.Contains("MatchScheme"):
              names[selectedScheme] = "MatchScheme";
              scheme = MatchScheme.CreateMatch(schemeName);
              break;
            case string t when t.Contains("CardBundleScheme"):
              names[selectedScheme] = "CardBundleScheme";
              scheme = CardBundleScheme.Create(schemeName);
              break;
            case string t when t.Contains("EquipmentScheme"):
              names[selectedScheme] = "EquipmentScheme";
              scheme = EquipmentScheme.Create(schemeName);
              break;
            case string t when t.Contains("LevelUpScheme"):
              names[selectedScheme] = "LevelUpScheme";
              scheme = LevelUpScheme.Create(schemeName);
              break;
            case string t when t.Contains("InventoryCardSlotScheme"):
              names[selectedScheme] = "InventoryCardSlotScheme";
              scheme = InventoryCardSlotScheme.Create(schemeName);
              break;
            case string t when t.Contains("InventoryItemSlotScheme"):
              names[selectedScheme] = "InventoryItemSlotScheme";
              scheme = InventoryItemSlotScheme.Create(schemeName);
              break;
          }
          fields = scheme.GetType().GetFields();
          InitTraits(traits,fields,scheme);
        }
      }

      if (scheme != null)
      {
        schemeName = GUILayout.TextField(schemeName);
        RemoveScheme();
        SetTraits(traits, fields,false,scheme);
        SaveScheme(true);
      }
    }

    /// <summary>
    /// Initialize our traits based on our scheme
    /// </summary>
    private static void InitTraits(Dictionary<string, object> traits,FieldInfo[] fields, Scheme.Scheme scheme)
    {
      traits.Clear();

      foreach (var field in fields)
      {
        if (field.FieldType == typeof(IntTrait))
        {
          traits.Add(field.Name, (IntTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(FloatTrait))
        {
          traits.Add(field.Name, (FloatTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(StringTrait))
        {
          traits.Add(field.Name, (StringTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(EffectTrait))
        {
          traits.Add(field.Name, (EffectTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(BooleanTrait))
        {
          traits.Add(field.Name, (BooleanTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(TextureTrait))
        {
          traits.Add(field.Name, (TextureTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(PrefabTrait))
        {
          traits.Add(field.Name, (PrefabTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(SpriteTrait))
        {
          traits.Add(field.Name, (SpriteTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(AnimationControllerTrait))
        {
          traits.Add(field.Name, (AnimationControllerTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(ResourceTrait))
        {
          traits.Add(field.Name, (ResourceTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(PrimaryResourceTrait))
        {
          traits.Add(field.Name, (PrimaryResourceTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(ListAbilityOptionTrait))
        {
          traits.Add(field.Name, (ListAbilityOptionTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(StringListTrait))
        {
          traits.Add(field.Name, (StringListTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(AbilityListTrait))
        {
          traits.Add(field.Name, (AbilityListTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(EquipmentTypesTrait))
        {
          traits.Add(field.Name, (EquipmentTypesTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(CardBundleTrait))
        {
          traits.Add(field.Name, (CardBundleTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(LevelUpTypeTrait))
        {
          traits.Add(field.Name, (LevelUpTypeTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(LevelUpTypeTrait))
        {
          traits.Add(field.Name, (LevelUpTypeTrait) field.GetValue(scheme));
        }
        else if (field.FieldType == typeof(List<CardStackTrait>))
        {
          traits.Add(field.Name, (List<CardStackTrait>) field.GetValue(scheme));
          
        }
      }
    }

    /// <summary>
    /// Set our traits based on menu settings
    /// </summary>
    private Vector2 SetTraits(Dictionary<string,object> traits, FieldInfo[] fields, bool externalScrollView, Scheme.Scheme schemeOverride)
    {
      if (fields != null)
      {
        GUILayout.Label("Set Traits", EditorStyles.boldLabel);
        if (!externalScrollView)
        {
          scrollPos = GUILayout.BeginScrollView(scrollPos);
        }

        foreach (var field in fields)
        {
          if (field.FieldType == typeof(IntTrait))
          {
            ((IntTrait) traits[field.Name]).Amount =
              EditorGUILayout.IntField(field.Name, ((IntTrait) traits[field.Name]).Amount);
          }
          else if (field.FieldType == typeof(FloatTrait))
          {
            ((FloatTrait) traits[field.Name]).Amount =
              EditorGUILayout.FloatField(field.Name, ((FloatTrait) traits[field.Name]).Amount);
          }
          else if (field.FieldType == typeof(StringTrait))
          {
            ((StringTrait) traits[field.Name]).Text =
              EditorGUILayout.TextField(field.Name, ((StringTrait) traits[field.Name]).Text);
          }
          else if (field.FieldType == typeof(EffectTrait))
          {
            List<string> effects = new List<string>();
            var guids = AssetDatabase.FindAssets("", new [] {"Assets/PixelEffects/Data"});
            foreach (var guid in guids)
            {
              var originalPath = AssetDatabase.GUIDToAssetPath(guid);
              var path = originalPath.Split('/');
              var name = path[path.Length - 1].Replace(".asset", "");
              effects.Add(name);
            }
            var t = EditorGUILayout.Popup(field.Name, Array.IndexOf(effects.ToArray(), ((EffectTrait) traits[field.Name]).Text), effects.ToArray());
            ((EffectTrait) traits[field.Name]).Text = effects[t > 0 ? t : 0];
          }
          else if (field.FieldType == typeof(BooleanTrait))
          {
            ((BooleanTrait) traits[field.Name]).State =
              EditorGUILayout.Toggle(field.Name, ((BooleanTrait) traits[field.Name]).State);
          }
          else if (field.FieldType == typeof(PrimaryResourceTrait))
          {
            ((PrimaryResourceTrait) traits[field.Name]).Resource = (ResourceTypes) EditorGUILayout.EnumPopup("PrimaryResource", ((PrimaryResourceTrait)traits[field.Name]).Resource, GUILayout.ExpandWidth(false));
          }
          else if (field.FieldType == typeof(ResourceTrait))
          {
            var list = ((ResourceTrait) traits[field.Name]).Items;
            var newCount = Mathf.Max(0, EditorGUILayout.IntField("Resources", list.Count));
            while (newCount < list.Count)
            {
              list.RemoveAt(list.Count - 1);
            }

            while (newCount > list.Count)
            {
              list.Add(new ResourceCost());
            }

            for (var i = 0; i < list.Count; i++)
            {
              EditorGUILayout.BeginHorizontal();
              EditorGUIUtility.labelWidth = 45;
              list[i].ResourceTypes = (ResourceTypes) EditorGUILayout.EnumPopup("ResourceTypes", list[i].ResourceTypes,
                GUILayout.ExpandWidth(false));
              list[i].Cost = EditorGUILayout.IntField("Cost", list[i].Cost, GUILayout.ExpandWidth(false));

              EditorGUILayout.EndHorizontal();
            }

            ((ResourceTrait) traits[field.Name]).Items = list;
          }
          else if (field.FieldType == typeof(TextureTrait))
          {
            ((TextureTrait) traits[field.Name]).Image = (Texture) EditorGUILayout.ObjectField(field.Name,
              ((TextureTrait) traits[field.Name]).Image, typeof(Texture), false);
            if (((TextureTrait) traits[field.Name]).Image != null)
            {
              ((TextureTrait) traits[field.Name]).ImagePath = TileWindowUtils.GetResourcesPath(AssetDatabase.GetAssetPath(((TextureTrait) traits[field.Name]).Image));
              field.SetValue(schemeOverride, ((TextureTrait) traits[field.Name]));
            }
          }
          else if (field.FieldType == typeof(PrefabTrait))
          {
            ((PrefabTrait) traits[field.Name]).Prefab = (GameObject) EditorGUILayout.ObjectField(field.Name,
              ((PrefabTrait) traits[field.Name]).Prefab, typeof(GameObject), false);
          }
          else if (field.FieldType == typeof(SpriteTrait))
          {
            ((SpriteTrait) traits[field.Name]).Image = (Sprite) EditorGUILayout.ObjectField(field.Name,
              ((SpriteTrait) traits[field.Name]).Image, typeof(Sprite), false);
            SpriteTrait trait = (SpriteTrait) traits[field.Name];
            if (trait.Image != null)
            {
              trait.ImagePath = TileWindowUtils.GetResourcesPath(AssetDatabase.GetAssetPath(trait.Image));
              trait.SpriteName = trait.Image.name; 
              field.SetValue(schemeOverride, trait);
            }
          }
          else if (field.FieldType == typeof(EquipmentTypesTrait))
          {
            ((EquipmentTypesTrait)traits[field.Name]).EquipmentType = (EquipmentTypes) EditorGUILayout.EnumPopup("EquipmentType", ((EquipmentTypesTrait)traits[field.Name]).EquipmentType,
              GUILayout.ExpandWidth(false));
          }
          else if (field.FieldType == typeof(CardBundleTrait))
          {
            ((CardBundleTrait)traits[field.Name]).CardBundleType = (CardBundleTypes) EditorGUILayout.EnumPopup("CardBundleType", ((CardBundleTrait)traits[field.Name]).CardBundleType,
              GUILayout.ExpandWidth(false));
          }
          else if (field.FieldType == typeof(LevelUpTypeTrait))
          {
            ((LevelUpTypeTrait)traits[field.Name]).LevelUpType = (LevelUpType) EditorGUILayout.EnumPopup("LevelUpType", ((LevelUpTypeTrait)traits[field.Name]).LevelUpType,
              GUILayout.ExpandWidth(false));
          }
          else if (field.FieldType == typeof(LevelUpTypeTrait))
          {
            ((LevelUpTypeTrait)traits[field.Name]).LevelUpType = (LevelUpType) EditorGUILayout.EnumPopup("LevelUpType", ((LevelUpTypeTrait)traits[field.Name]).LevelUpType,
              GUILayout.ExpandWidth(false));
          }
          else if (field.FieldType == typeof(AnimationControllerTrait))
          {
            ((AnimationControllerTrait) traits[field.Name]).AnimatorController =
              (AnimatorController) EditorGUILayout.ObjectField(field.Name,
                ((AnimationControllerTrait) traits[field.Name]).AnimatorController, typeof(AnimatorController), false);
          }
          else if (field.FieldType == typeof(ListAbilityOptionTrait))
          {
            EditorGUILayout.LabelField(field.Name);
            var list = ((ListAbilityOptionTrait) traits[field.Name]).Options;
            var newCount = Mathf.Max(0, EditorGUILayout.IntField("size", list.Count));
            while (newCount < list.Count)
            {
              list.RemoveAt(list.Count - 1);
            }

            while (newCount > list.Count)
            {
              list.Add(new AbilityOption());
            }

            for (var i = 0; i < list.Count; i++)
            {
              EditorGUILayout.BeginHorizontal();
              list[i].Option = EditorGUILayout.TextField(list[i].Option);
              list[i].Chance = EditorGUILayout.IntField(list[i].Chance);
              EditorGUILayout.EndHorizontal();
            }

            ((ListAbilityOptionTrait) traits[field.Name]).Options = list;
          }
          else if (field.FieldType == typeof(AbilityListTrait))
          {
            EditorGUILayout.LabelField(field.Name);
            var list = ((AbilityListTrait) traits[field.Name]).Items;
            var newCount = Mathf.Max(0, EditorGUILayout.IntField("Number of Abilities", list.Count));
            while (newCount < list.Count)
            {
              list.RemoveAt(list.Count - 1);
            }

            while (newCount > list.Count)
            {
              list.Add(new Ability());
            }

            for (var i = 0; i < list.Count; i++)
            {
              EditorGUILayout.BeginHorizontal();
              EditorGUIUtility.labelWidth = 35;
              var t = EditorGUILayout.Popup("Script", Array.IndexOf(AbilityFactory.CardAbilities, list[i].ScriptName),
                AbilityFactory.CardAbilities);
              list[i].ScriptName = AbilityFactory.CardAbilities[t > 0 ? t : 0];
              EditorGUIUtility.labelWidth = 65;
              list[i].Target =
                (Targets) EditorGUILayout.EnumPopup("Targets", list[i].Target, GUILayout.ExpandWidth(false));
              list[i].Amount = EditorGUILayout.IntField("Amount", list[i].Amount, GUILayout.ExpandWidth(false));

              EditorGUILayout.EndHorizontal();
            }

            ((AbilityListTrait) traits[field.Name]).Items = list;
          }
          else if (field.FieldType == typeof(StringListTrait))
          {
            EditorGUILayout.LabelField(field.Name);
            var list = ((StringListTrait) traits[field.Name]).Items;
            var newCount = Mathf.Max(0, EditorGUILayout.IntField("size", list.Count));
            while (newCount < list.Count)
            {
              list.RemoveAt(list.Count - 1);
            }

            while (newCount > list.Count)
            {
              list.Add(null);
            }

            for (var i = 0; i < list.Count; i++)
            {
              list[i] = EditorGUILayout.TextField(list[i]);
            }

            ((StringListTrait) traits[field.Name]).Items = list;
          }
          else if (field.FieldType == typeof(List<CardStackTrait>))
          {
            EditorGUILayout.LabelField(field.Name);
            var list = (List<CardStackTrait>) traits[field.Name];
            var newCount = Mathf.Min(Mathf.Max(0, EditorGUILayout.IntField("size", list.Count)),15);
            while (newCount < list.Count)
            {
              list.RemoveAt(list.Count - 1);
            }
            while (newCount > list.Count)
            {
              list.Add(new CardStackTrait());
            }
            DrawLine();

            for (var i = 0; i < list.Count; i++)
            {
              Dictionary<string, object> subTraits = new Dictionary<string, object>();
              var subFields = list[i].cardScheme.GetType().GetFields();
              list[i].predicate  = (PredicateType) EditorGUILayout.EnumPopup("Predicate Type",list[i].predicate, GUILayout.ExpandWidth(false));
              switch (list[i].predicate)
              {
                case PredicateType.Noop:
                  if(list[i].noopPredicate == null)
                  {
                    list[i].noopPredicate = new NoopCardPredicate();
                    list[i].ingPredicate = null;
                    list[i].tempPredicate = null;
                  }
                  EditorGUILayout.LabelField("Base Card");
                  break;
                case PredicateType.Ingredients:
                  if(list[i].ingPredicate == null)
                  {
                    list[i].noopPredicate = null;
                    list[i].ingPredicate = new IngredientCardPredicate();
                    list[i].tempPredicate = null;
                  }
                  // if (list[i].cardPredicate == null|| list[i].cardPredicate.GetType() != typeof(IngredientCardPredicate))
                  // {
                  //   list[i].cardPredicate = new IngredientCardPredicate();
                  // }
                  EditorGUILayout.LabelField("Select Ingredient Combination");
                  EditorGUILayout.BeginHorizontal();
                  ((IngredientCardPredicate) list[i].ingPredicate).slot1 = (Ingredients)EditorGUILayout.EnumPopup(((IngredientCardPredicate) list[i].ingPredicate).slot1);
                  ((IngredientCardPredicate) list[i].ingPredicate).slot2 = (Ingredients)EditorGUILayout.EnumPopup(((IngredientCardPredicate) list[i].ingPredicate).slot2);
                  ((IngredientCardPredicate) list[i].ingPredicate).slot3 = (Ingredients)EditorGUILayout.EnumPopup(((IngredientCardPredicate) list[i].ingPredicate).slot3);
                  EditorGUILayout.EndHorizontal();
                  break;
                case PredicateType.Temperature:
                  if(list[i].tempPredicate == null)
                  {
                    list[i].noopPredicate = null;
                    list[i].ingPredicate = null;
                    list[i].tempPredicate = new TemperatureCardPredicate();;
                  }
                  // if (list[i].cardPredicate == null || list[i].cardPredicate.GetType() != typeof(TemperatureCardPredicate))
                  // {
                  //   list[i].cardPredicate = new TemperatureCardPredicate();
                  // }
                  EditorGUILayout.LabelField("Select temperature range");
                  EditorGUILayout.BeginHorizontal();
                  ((TemperatureCardPredicate) list[i].tempPredicate).TemperatureMin = EditorGUILayout.IntField("TemperatureMin", ((TemperatureCardPredicate) list[i].tempPredicate).TemperatureMin);
                  ((TemperatureCardPredicate) list[i].tempPredicate).TemperatureMax = EditorGUILayout.IntField("TemperatureMax", ((TemperatureCardPredicate) list[i].tempPredicate).TemperatureMax);
                  EditorGUILayout.EndHorizontal();
                  break;
              }
              InitTraits(subTraits, subFields, list[i].cardScheme);
              SetTraits(subTraits, subFields,true,list[i].cardScheme);
              DrawLine();
              ((List<CardStackTrait>) traits[field.Name])[i] = list[i];
            }
          }
        }

        if (!externalScrollView)
        {
          GUILayout.EndScrollView();
        }
      }

      return scrollPos;
    }

    public void DrawLine()
    {
      var rect = EditorGUILayout.BeginHorizontal();
      Handles.color = Color.gray;
      Handles.DrawLine(new Vector2(rect.x - 15, rect.y), new Vector2(rect.width + 15, rect.y));
      EditorGUILayout.EndHorizontal();
      EditorGUILayout.Space();
    }

    /// <summary>
    /// Save our scheme to disk
    /// </summary>
    /// <param name="overwrite">If we are editing this will overwrite an existing file</param>
    private void SaveScheme(bool overwrite)
    {
      if (GUILayout.Button("Save Scheme"))
      {
        if (!overwrite && File.Exists($"{Application.dataPath}/Resources/Schemes/{names[selectedScheme]}/{schemeName}.json"))
        {
          Debug.LogError("Scheme Already Exists!");
        }
        else
        {
          foreach (var field in fields)
          {
            if (traits.ContainsKey(field.Name))
            {
              if (field.FieldType == typeof(TextureTrait))
              {
                TextureTrait trait = (TextureTrait) traits[field.Name];
                if (trait.Image != null)
                {
                  trait.ImagePath = TileWindowUtils.GetResourcesPath(AssetDatabase.GetAssetPath(trait.Image));
                  field.SetValue(scheme, trait);
                }
              }
              else if (field.FieldType == typeof(PrefabTrait))
              {
                PrefabTrait trait = (PrefabTrait) traits[field.Name];
                if (trait.Prefab != null)
                {
                  trait.PrefabPath = TileWindowUtils.GetResourcesPath(AssetDatabase.GetAssetPath(trait.Prefab));
                  field.SetValue(scheme, trait);
                }
              }
              else if (field.FieldType == typeof(SpriteTrait))
              {
                SpriteTrait trait = (SpriteTrait) traits[field.Name];
                if (trait.Image != null)
                {
                  trait.ImagePath = TileWindowUtils.GetResourcesPath(AssetDatabase.GetAssetPath(trait.Image));
                  trait.SpriteName = trait.Image.name; 
                  field.SetValue(scheme, trait);
                }
              }
              else if (field.FieldType == typeof(AnimationControllerTrait))
              {
                AnimationControllerTrait trait = (AnimationControllerTrait) traits[field.Name];
                if (trait.AnimatorController != null)
                {
                  trait.path = TileWindowUtils.GetResourcesPath(AssetDatabase.GetAssetPath(trait.AnimatorController));
                  field.SetValue(scheme, trait);
                }
              }
              else
              {
                field.SetValue(scheme, traits[field.Name]);
              }
            }
          }

          if (!AssetDatabase.IsValidFolder("Assets/Resources"))
          {
            AssetDatabase.CreateFolder("Assets", "Resources");
          }

          if (!AssetDatabase.IsValidFolder("Assets/Resources/Schemes"))
          {
            AssetDatabase.CreateFolder("Assets/Resources", "Schemes");
          }

          CheckFolder(names[selectedScheme]);

          if (names[selectedScheme] == "AbilityScheme")
          {
            ((AbilitySchema) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "CardScheme")
          {
            ((CardScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "EnemyScheme")
          {
            ((EnemyScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "AreaScheme")
          {
            ((AreaScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "RoomScheme")
          {
            ((RoomScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "MatchScheme")
          {
            ((MatchScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "CardBundleScheme")
          {
            ((CardBundleScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "EquipmentScheme")
          {
            ((EquipmentScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "LevelUpScheme")
          {
            ((LevelUpScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "InventoryCardSlotScheme")
          {
            ((InventoryCardSlotScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "InventoryItemSlotScheme")
          {
            ((InventoryItemSlotScheme) scheme).SaveScheme(schemeName);
          }
          else if (names[selectedScheme] == "CardStackScheme")
          {
            ((CardStackScheme) scheme).Save(schemeName);
          }
          else
          {
            scheme.SaveScheme(schemeName);
          }

          traits.Clear();
          AssetDatabase.Refresh();
          scheme = null;
        }
      }

      void CheckFolder(string Check)
      {
        if (!AssetDatabase.IsValidFolder($"Assets/Resources/Schemes/{Check}"))
        {
          AssetDatabase.CreateFolder("Assets/Resources/Schemes", Check);
        }
      }
      
    }
  }
}