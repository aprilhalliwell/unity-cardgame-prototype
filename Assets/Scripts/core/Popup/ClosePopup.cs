using UnityEngine;

namespace core.Popup
{
  public class ClosePopup : MonoBehaviour
  {
    [SerializeField] private GameObject Parent;
    public void OnClick()
    {
      Destroy(Parent);
    }
  }
}