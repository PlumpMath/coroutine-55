using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class CoroutineManager
    {
        public CoroutineManager()
        {
            coroutines = new List<Coroutine>();
        }

        public void StartCoroutine(IEnumerable<CoroutineWaitState> enumerable)
        {
            Coroutine coroutine = new Coroutine(enumerable);
            coroutines.Add(coroutine);
        }

        public void Advance(float deltaTime)
        {
            coroutines = coroutines.Where((Coroutine coroutine) =>
                {
                    return !coroutine.Ready;
                }).ToList();
            foreach (Coroutine coroutine in coroutines)
            {
                coroutine.Advance(deltaTime);
            }
        }

        private List<Coroutine> coroutines;
    }
}
