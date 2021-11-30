using System.Collections;
using UnityEngine;

namespace core.CoroutineExecutor
{
    /// <summary>
    /// Class used to execute coroutines in non monobehaviour contexts.
    /// </summary>
    class Executor : MonoBehaviour
    {
        /// <summary>
        /// Helper method to find the exector in any context
        /// </summary>
        /// <returns></returns>
        public static Executor Find()
        {
            return GameObject.FindGameObjectWithTag("CoroutineExecutor").GetComponent<Executor>();
        }

        public Command Execute(Command command)
        {
            var enumerator = command.execute();
            StartCoroutine(enumerator);
            return command;
        }
        public IEnumerator Execute(IEnumerator command)
        {
            StartCoroutine(command);
            return command;
        }
    }
}