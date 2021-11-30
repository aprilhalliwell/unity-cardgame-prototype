using System.Linq;
using gameplay.match;
using progression.cardBundles.data;
using UnityEngine;
using world;

namespace gameplay.mixingTable
{
  public class ToggleMixingTables : MonoBehaviour
  {
    public GameObject AvailableMixingTable;
    public GameObject UnavailableMixingTable;

    void Start()
    {
      var world = Finder.Find<GameWorld>();
      var conatinsMixCard = world.Player.IsMixingEnalbed();
      AvailableMixingTable.SetActive(conatinsMixCard);
      UnavailableMixingTable.SetActive(!conatinsMixCard);
    }
  }
}