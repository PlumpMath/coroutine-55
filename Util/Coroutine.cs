using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Util
{
    public class Coroutine : CoroutineWaitState
    {
        internal Coroutine(IEnumerable<CoroutineWaitState> enumerable)
        {
            iterator = enumerable.GetEnumerator();
        }

        public override bool Advance(float deltaTime)
        {
            if(Ready)
                throw new Exception("coroutine has finished");

            if (currentWaitState != null && !currentWaitState.Advance(deltaTime))
                return false;

            if (iterator.MoveNext())
                currentWaitState = iterator.Current;
            else
                Ready = true;

            return Ready;
        }

        public override bool Ready
        {
            get;
            protected set;
        }

        private CoroutineWaitState currentWaitState;
        private IEnumerator<CoroutineWaitState> iterator;
    }
}
