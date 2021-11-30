using UnityEngine;

namespace core.Components
{
    public class DontDestoryOnLoad : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}