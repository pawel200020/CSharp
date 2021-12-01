using System;

namespace Lecture7.Model
{

    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class UnitTestFixtureAttribute : Attribute
    {
    }


    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class UnitTestAttribute : Attribute
    {
        public int Repetitions { get; set; }

        public string FailureMessage { get; set; }

        public UnitTestAttribute() : this(1) { }

        public UnitTestAttribute(int repetitions) { Repetitions = repetitions; }
    }
}
