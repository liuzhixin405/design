using System;
using System.Collections.Generic;
using System.Threading;
namespace MarvellousWorks.PracticalPattern.Concept.Delegating
{
    public class AsyncInvoker
    {
        // 纪录异步执行的结果
        private IList<string> output = new List<string>();

        public AsyncInvoker()
        {
            Timer slowTimer = new Timer(new TimerCallback(OnTimerInterval), 
                "slow", 2500, 2500);
            Timer fastTimer = new Timer(new TimerCallback(OnTimerInterval), 
                "fast", 2000, 2000);
            output.Add("method");
        }

        private void OnTimerInterval(object state)
        {
            output.Add(state as string);
        }

        public IList<string> Output { get { return output; } }
    }
}
