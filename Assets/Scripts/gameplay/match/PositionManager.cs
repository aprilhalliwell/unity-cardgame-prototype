using System.Collections.Generic;
using UnityEngine;

namespace gameplay.match
{
  public class PositionManager : MonoBehaviour
  {
    [SerializeField] private List<PilePosition> Positions = new List<PilePosition>();
    private Dictionary<string, PilePosition> PositionLookup = new Dictionary<string, PilePosition>();

    public PilePosition GetPosition(string id)
    {
      PilePosition pile;
      PositionLookup.TryGetValue(id, out pile);
      if (pile == null)
      {
        Debug.Log($"Could not find a pile for {id}");
      }
      return pile;
    }
    public void RegisterPosition(PilePosition position)
    {
      if (PositionLookup.ContainsKey(position.ID))
      {
        Debug.Log($"Position {position.ID} already in Lookup",position);
      }
      PositionLookup.Add(position.ID,position);
      Positions.Add(position);
    }

    public void UnRegisterPosition(string id)
    {
      PositionLookup.Remove(id);
      var index = Positions.FindIndex(x => x.ID == id);
      Positions.RemoveAt(index);
    }
  }
}