using core.CoroutineExecutor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace core.scene
{
    public class SceneTransition : MonoBehaviour
    {
      [SerializeField] private string ToScene;

      public void OnClick()
      {
        new ChangeSceneCommand(SceneManager.GetActiveScene().name,ToScene).Execute();
      }
    }
}