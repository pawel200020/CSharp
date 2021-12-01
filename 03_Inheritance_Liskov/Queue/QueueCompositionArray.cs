using System;

namespace _03_Inheritance_Liskov
{
    //w drugim przypadku wystarczy zaalokować odpowiednio dużą tablicę
    //zrobiłem tutaj kolejkę w formie "nieskończonej tablicy" gdzie początek jest sklejony z końcem i przez to trudniej ją "zapchać"
    class QueueCompositionArray
    {
        const int MAX_ARRAY_SIZE = 2146435071;
        //const int MAX_ARRAY_SIZE = 6;
        object[] array;
        int first;
        int last;
        int size;
        public QueueCompositionArray()
        {
            array = new object[MAX_ARRAY_SIZE];
            first = 0;
            last = 0;
            size = 0;
        }

        public void Enqueue(Object value)
        {
            size++;
            if(size<=MAX_ARRAY_SIZE)
            {             
                array[last] = value;
                last = (last + 1) % MAX_ARRAY_SIZE;
            }
            else
            {
                throw new Exception("queue is full");
            }

        }
                
        public Object Dequeue()
        {
            if(size == 0)
            {
                throw new Exception("queue is empty");
            }
            else
            {
                int temp = first;
                first = (first + 1) % MAX_ARRAY_SIZE;
                size--;
                return (array[temp]);
            }
            
        }

    }
}
