using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Lecture5.Sample3_ServiceLocator
{
    public class Document
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
    }

    public interface IPrintedDocument
    {

    }

    public interface IPrintManager
    {
        IPrintedDocument Print(Document documentToPrint);
    }

    public static class SampleServiceLocator
    {
        private static readonly IDictionary<Type, Func<object>> Services
            = new Dictionary<Type, Func<object>>();
        public static void Register<T>(Func<T> resolver)
        {
            Services[typeof(T)] = () => resolver();
        }
        public static T Resolve<T>()
        {
            if (!Services.ContainsKey(typeof(T)))
                throw new Exception("Type is not registered in our service locator.");

            return (T)Services[typeof(T)]();
        }
    }


    class DocumentManager
    {
        public IPrintedDocument Print(Document document)
        {
            document.DateTime = DateTime.Now;
            var manager = SampleServiceLocator.Resolve<IPrintManager>();
            return manager.Print(document);

        }
    }


    public class DocumentManagerTests
    {

        [Test]
        public void PrintTest()
        {
            //Arrange:
            var testDocument = new Document { Name = "Testowy dokument" };
            var documentManager = new DocumentManager();

            #region Don't do that

            var resultMock = Mock.Of<IPrintedDocument>();
            var printMock = new Mock<IPrintManager>();
            printMock.Setup(f => f.Print(It.IsAny<Document>())).Returns(resultMock);
            SampleServiceLocator.Register<IPrintManager>(() => printMock.Object);

            #endregion

            //Act:
            var printedDocument = documentManager.Print(testDocument);

            //Assert:
            Assert.IsNotNull(printedDocument);
        }
    }
}
