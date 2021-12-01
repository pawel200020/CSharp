using System;
using System.IO;
using System.Xml.Serialization;
using JetBrains.Annotations;

namespace Lecture7.CommonUsedAttributes
{
    #region Flags

    public enum Edges
    {
        Left,           // 0
        Top,            // 1
        Right,          // 2
        Bottom          // 3
    }

    [Flags]
    public enum EdgesFlags
    {
        Left,           // 0  0000
        Top,            // 1  0001
        Right,          // 2  0010
        Bottom          // 3  0011
    }

    [Flags]
    public enum EdgesFlagsCorrect
    {
        None = 0,       // 0000
        Left = 1,       // 0001
        Top = 2,        // 0010
        Right = 4,      // 0100
        Bottom = 8      // 1000
    }

    public enum EdgesLikeFlags
    {
        None = 0,       // 0000
        Left = 1,       // 0001
        Top = 2,        // 0010
        Right = 4,      // 0100
        Bottom = 8      // 1000
    }

    public class Test1
    {
        public void Run()
        {
            Edges visibleEdges = Edges.Top | Edges.Right;
            Console.WriteLine(visibleEdges.ToString());
            Console.WriteLine((visibleEdges & Edges.Top) == Edges.Top);
            Console.WriteLine((visibleEdges & Edges.Right) == Edges.Right);
            Console.WriteLine((visibleEdges & Edges.Bottom) == Edges.Bottom);

            EdgesFlags visibleEdgesFlags = EdgesFlags.Top | EdgesFlags.Right;
            Console.WriteLine(visibleEdgesFlags.ToString());
            Console.WriteLine((visibleEdgesFlags & EdgesFlags.Top) == EdgesFlags.Top);
            Console.WriteLine((visibleEdgesFlags & EdgesFlags.Right) == EdgesFlags.Right);
            Console.WriteLine((visibleEdgesFlags & EdgesFlags.Bottom) == EdgesFlags.Bottom);

            EdgesFlagsCorrect visibleEdgesFlagsCorrect = EdgesFlagsCorrect.Top | EdgesFlagsCorrect.Right;
            Console.WriteLine(visibleEdgesFlagsCorrect.ToString());
            Console.WriteLine((visibleEdgesFlagsCorrect & EdgesFlagsCorrect.Top) == EdgesFlagsCorrect.Top);
            Console.WriteLine((visibleEdgesFlagsCorrect & EdgesFlagsCorrect.Right) == EdgesFlagsCorrect.Right);
            Console.WriteLine((visibleEdgesFlagsCorrect & EdgesFlagsCorrect.Bottom) == EdgesFlagsCorrect.Bottom);

            EdgesLikeFlags visibleEdgesLikeFlags = EdgesLikeFlags.Top | EdgesLikeFlags.Right;
            Console.WriteLine(visibleEdgesLikeFlags.ToString());
            Console.WriteLine((visibleEdgesLikeFlags & EdgesLikeFlags.Top) == EdgesLikeFlags.Top);
            Console.WriteLine((visibleEdgesLikeFlags & EdgesLikeFlags.Right) == EdgesLikeFlags.Right);
            Console.WriteLine((visibleEdgesLikeFlags & EdgesLikeFlags.Bottom) == EdgesLikeFlags.Bottom);
        }
    }

    #endregion

    #region Serializable
    
    [Serializable]
    public class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [XmlIgnore]
        public string DisplayName
        {
            get { return $"{Name} {Surname}"; }
        }

        [XmlElement(ElementName ="PersonAge")]
        public int Age { get; set; }
    }

    public class Test2
    {
        public void Run()
        {
            var person = new Person() { Name = "Jan", Surname = "Nowak", Age = 24 };
            var serializer = new XmlSerializer(typeof(Person));
            var stringWriter = new StringWriter();

            serializer.Serialize(stringWriter, person);
            Console.WriteLine(stringWriter.ToString());
        }
    }

    //  <? xml version="1.0" encoding="utf-16"?>
    //  <Person xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    //    <Name>Jan</Name>
    //    <Surname>Nowak</Surname>
    //    <PersonAge>24</PersonAge>
    //  </Person>
    #endregion
    
    #region [NotNull] [CanBeNull]

    public class Test3
    {
        public bool IsAdult([NotNull] Person person)
        {
            return person.Age >= 18;
        }

        public void Run()
        {
            var a = IsAdult(null);
        }
    }
    #endregion
}
