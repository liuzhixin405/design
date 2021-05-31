using System;
namespace MarvellousWorks.PracticalPattern.Concept.Delegating
{
    public class MulticastDelegateInvoker
    {
        private string[] message = new string[3];
        public MulticastDelegateInvoker()
        {
            StringAssignmentEventHandler handler = null;
            handler += new StringAssignmentEventHandler(AppendHello);
            handler += new StringAssignmentEventHandler(AppendComma);
            handler += new StringAssignmentEventHandler(AppendWorld);
            handler.Invoke();
        }

        public void AppendHello() { message[0] = "hello"; }
        public void AppendComma() { message[1] = ","; }
        public void AppendWorld() { message[2] = "world"; }

        public string this[int index] { get { return message[index]; } }
    }
}
 
