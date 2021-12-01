using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlament
{
    public delegate void Notify(); // Delegata
    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // Zdarzenie
        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here..
            OnProcessCompleted();
        }
        protected virtual void OnProcessCompleted() //Metoda protected virtual
        {
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke(); //Zgłaszanie zdarzenia
        }
    }
    class Program2
    {
        public static void Main123()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
            bl.StartProcess();
        }
        // Tutaj mamy metodę, która uruchomi się kiedy event zostanie aktywowany
        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }
    }


}
