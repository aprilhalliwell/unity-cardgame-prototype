using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace core.CoroutineExecutor
{
    public static class CommandExtensions
    {
        public static Command asCommand(this IEnumerator cmd)
        {
            return new CastCommand(cmd);
        }
        public static Command Execute(this Command cmd)
        {
            return Executor.Find().Execute(cmd);
        }
        public static IEnumerator Execute(this IEnumerator cmd)
        {
            return Executor.Find().Execute(cmd);
        }

        public static IEnumerator Execute(this List<IEnumerator> cmds)
        {
            bool destroyFinished = false;
            while (!destroyFinished)
            {
                destroyFinished = true;
                foreach (var cmd in cmds)
                {
                    if (cmd.MoveNext())
                    {
                        destroyFinished = false;
                    }
                }
                if (!destroyFinished) yield return null;
            }
        }

        public static IEnumerator Then(this IEnumerator first, IEnumerator next)
        {
            while (first.MoveNext())
            {
                yield return first.Current;
            }

            while (next.MoveNext())
            {
                yield return next.Current;
            }
        }
        public static IEnumerator Then<T>(this T command, Func<T,IEnumerator> next) where T: IEnumerator
        {
            while (command.MoveNext())
            {
                yield return command.Current;
            }
            var t = next(command);
            while (t.MoveNext())
            {
                yield return t.Current;
            }
        }

        public static IEnumerator Then(this IEnumerator first, Action next)
        {
            while (first.MoveNext())
            {
                yield return first.Current;
            }

            var t = new SimpleCommand(next);
            while (t.MoveNext())
            {
                yield return t.Current;
            }
        }

        public static IEnumerator Then<T>(this IEnumerator first, Command next)
        {
            while (first.MoveNext())
            {
                yield return first.Current;
            }
            
            while (next.MoveNext())
            {
                yield return next.Current;
            }
        }
        
    }
}