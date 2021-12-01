using System;

namespace Lecture7.Attributes
{

    class Test
    {
        [Obsolete]                                          // atrybut określający, że ta metoda nie powinna już być używana
        public void Init()
        {
            // don't use this method anymore
        }

        [Obsolete("Use TestSynchronizer class instead")]
        public void Synchronize()
        {
            // don't use this method anymore
        }

        public void Run()
        {
            Synchronize();                                  // ostrzeżenie przy kompilacji oraz w IntelliSense
        }
    }
}
