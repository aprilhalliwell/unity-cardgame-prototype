using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Editor.Utils
{
  /// <summary>
  /// Contains useful functions to find assets
  /// </summary>
  static class TileWindowUtils
  {
    /// <summary>
    /// Finds all assets in all resource folders given a specific filter
    /// </summary>
    /// <param name="filter">What to look for</param>
    /// <returns></returns>
    public static string[] LookThroughResources(string filter)
    {
      return AssetDatabase.FindAssets("").
          Select(x=>AssetDatabase.GUIDToAssetPath(x)).
          Where(x=>x.Contains("Resources") && x.Contains(filter) && !x.EndsWith(filter)).
          Select(x => GetResourcesPath(x)).
        ToArray();
    }
    /// <summary>
    /// Removes data from a resources path, and returns proper resources path to load.
    /// </summary>
    /// <param name="assetPath">Path to trim</param>
    /// <returns></returns>
    public static string GetResourcesPath(string assetPath)
    {
      var extension = Path.GetExtension(assetPath);
      assetPath = assetPath.Replace(extension, "");
      var resourceIndex = assetPath.IndexOf("/Resources/");//find our resources folder
      var substring = assetPath.Substring(resourceIndex + 11);//also remove our resources folder
      return substring;
    }
  }
}
