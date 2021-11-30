using Assets.Data;
using UnityEngine;

namespace gameplay.card.data.rendering
{
  public class CardDataHandPosition : VersionedDataElement
  {
    public GameObject FakeCardObject { get; private set; }

    public void SetFakePosition(GameObject gameObject)
    {
      Debug.Log("Setting up fake pos");
      FakeCardObject = gameObject;
      markDirty();
    }
  }
}