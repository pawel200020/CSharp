using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Inheritance_Liskov
{
    //3.2
    class QueueComposition
    {
        private ArrayList arrayList;
        public QueueComposition()
        {
            arrayList = new ArrayList();
        }
        public void Enqueue(Object value) {
            int c = arrayList.Add(value);

        }
        public Object Dequeue() {
            if (arrayList.Count !=0)
            {
                Object temp = arrayList[0];
                arrayList.RemoveAt(0);
                return temp;
            } else
            {
                throw new Exception("Queue is empty!");
            }
        }

    }
}
