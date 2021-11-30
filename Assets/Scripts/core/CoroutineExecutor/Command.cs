using System.Collections;
using UnityEngine;

namespace core.CoroutineExecutor
{
    public abstract class Command : IEnumerator
    {
        private IEnumerator wrappedCommand;
        private bool isCompleted = false;
        protected Command()
        {
            wrappedCommand =  execute();
        }
        
        
        public abstract IEnumerator execute();
        public bool MoveNext()
        {
            var next = wrappedCommand.MoveNext();
            if (!next)
            {
                isCompleted = true;
            }
            return next;
        }

        public bool Completed()
        {
            return isCompleted;
        }
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public object Current
        {
            get { return wrappedCommand.Current; }
            private set
            {
                throw new System.NotImplementedException();
            }
        }
    }
    
}