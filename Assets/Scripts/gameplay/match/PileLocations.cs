using System.Collections.Generic;
using UnityEngine;

namespace gameplay.match
{
  public class PileLocations : MonoBehaviour
  {
    public PileLocation Deck;
    public PileLocation Discard;
    public PileLocation Present;
    public PileLocation Mixing;
    public List<PileLocation> MixingSlots = new List<PileLocation>();
  }
}