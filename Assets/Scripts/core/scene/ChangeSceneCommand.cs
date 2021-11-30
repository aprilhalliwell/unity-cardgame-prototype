using System.Collections;
using core.CoroutineExecutor;
using UnityEngine.SceneManagement;

namespace core.scene
{
    public class ChangeSceneCommand : Command
    {
        private readonly string toScene;
        private readonly string fromScene;
        public ChangeSceneCommand(string fromScene, string toScene)
        {
            this.toScene = toScene;
            this.fromScene = fromScene;
        }
        public override IEnumerator execute()
        {
            SceneManager.LoadScene(toScene);
            yield return null;
        }
    }
}