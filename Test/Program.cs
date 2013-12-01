using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CoroutineManager coroutineManager = new CoroutineManager();
            coroutineManager.StartCoroutine(WaitForAnotherCoroutine());
            long lastTicks = DateTime.Now.Ticks;
            while (true)
            {
                long currentTicks = DateTime.Now.Ticks;
                float deltaTime = (float)((currentTicks - lastTicks) / 1e7);
                coroutineManager.Advance(deltaTime);
                lastTicks = currentTicks;
            }
        }

        static IEnumerable<CoroutineWaitState> WaitForAnotherCoroutine()
        {
            Console.WriteLine("Start WaitForAnotherCoroutine at " + DateTime.Now.ToLongTimeString());
            yield return new Coroutine(WaitForSecondsCoroutine(6.0f));
            Console.WriteLine("WaitForAnotherCoroutine finished at " + DateTime.Now.ToLongTimeString());
        }

        static IEnumerable<CoroutineWaitState> WaitForSecondsCoroutine(float wait)
        {
            Console.WriteLine("Start WaitForSecondsCoroutine at " + DateTime.Now.ToLongTimeString());
            yield return new WaitForSeconds(wait);
            Console.WriteLine("WaitForSecondsCoroutine finished at " + DateTime.Now.ToLongTimeString());
        }
    }
}
