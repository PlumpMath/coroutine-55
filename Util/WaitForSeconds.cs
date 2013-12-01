using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class WaitForSeconds : CoroutineWaitState
    {
        public WaitForSeconds(float seconds)
        {
            this.seconds = seconds;
            this.elapsedTime = 0.0f;
        }

        public override bool Advance(float deltaTime)
        {
            elapsedTime += deltaTime;
            if (elapsedTime >= seconds)
                this.Ready = true;

            return this.Ready;
        }

        public override bool Ready
        {
            get
            {
                return ready;
            }
            protected set
            {
                ready = value;
            }
        }

        private bool ready;
        private float elapsedTime;
        private float seconds;
    }
}
