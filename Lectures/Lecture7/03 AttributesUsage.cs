using System;

namespace Lecture7.AttributesUsage
{
    [Obsolete, Serializable, CLSCompliant(false)]
    class Decorated1 { }


    [Obsolete]
    [Serializable]
    [CLSCompliant(false)]
    class Decorated2 { }                                // najczytelniejsza konwencja


    [Obsolete, Serializable]
    [CLSCompliant(false)]
    class Decorated3 { }

    class Test
    {
        public void Run()
        {

        }
    }
}
