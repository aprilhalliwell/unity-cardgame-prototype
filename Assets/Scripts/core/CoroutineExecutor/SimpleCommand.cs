using System;
using System.Collections;

namespace core.CoroutineExecutor
{
    public class SimpleCommand : Command
    {
        private readonly Action func;
        private readonly string fromScene;
        public SimpleCommand(Action func)
        {
            this.func = func;
        }
        public override IEnumerator execute()
        {
            func();
            yield break;
        }
    }

    public class CastCommand : Command
    {
        private IEnumerator cmd;
        public CastCommand(IEnumerator cmd)
        {
            this.cmd = cmd;
        }

        public override IEnumerator execute()
        {
            while (cmd.MoveNext())
            {
                yield return cmd.Current;
            }
        }
    }
}