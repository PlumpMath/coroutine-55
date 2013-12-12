using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class CoroutineManager
    {
        private List<Coroutine> coroutines;
        private bool _inCoroutine;
        
        public bool InCoroutine
        {
            get { return _inCoroutine; }
            set { _inCoroutine = value; }
        }

        public CoroutineManager()
        {
            coroutines = new List<Coroutine>();
        }

        public Coroutine StartCoroutine(IEnumerable<CoroutineWaitState> enumerable)
        {
            Coroutine coroutine = new Coroutine(enumerable);
            if (!InCoroutine)
            {
                coroutines.Add(coroutine);
            }
            return coroutine;
        }

        public void Advance(float deltaTime)
        {
            coroutines = coroutines.Where((Coroutine coroutine) =>
                {
                    return !coroutine.Ready;
                }).ToList();
            InCoroutine = true;
            foreach (Coroutine coroutine in coroutines)
            {
                coroutine.Advance(deltaTime);
            }
            InCoroutine = false;
        }
    }
}
