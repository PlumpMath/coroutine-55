using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public abstract class CoroutineWaitState
    {
        public abstract bool Ready { get; protected set; }
        public abstract bool Advance(float deltaTime);
    }
}
