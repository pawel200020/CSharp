using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Lecture5.Sample3_ServiceLocator_Fixed
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
        // dodanie pola z Print managerem zainicjowanego w konstruktorze
        private readonly IPrintManager _printManager;

        public DocumentManager(IPrintManager printManager)
        {
            _printManager = printManager;
        }

        public IPrintedDocument Print(Document document)
        {
            document.DateTime = DateTime.Now;
            // PrinterManager to jest zależność, którą chcemy otrzymać inaczej - najlepiej przez wstrzyknięcie do konstruktora
            // var manager = SampleServiceLocator.Resolve<IPrintManager>();
            // tu używamy zależności wstrzykniętej w konstruktorze
            return _printManager.Print(document);
        }
    }


    public class DocumentManagerTests
    {
        [Test]
        public void PrintTest()
        {
            //Arrange:
            var testDocument = new Document { Name = "Testowy dokument" };
            
            // teraz możemy Mock IPrintManagera oraz zwracanego przez niego Mock IPrintedDocument, stworzyć lokalnie i przekazać od razu do DocumentManagera
            var resultMock = Mock.Of<IPrintedDocument>();
            var printMock = new Mock<IPrintManager>();
            printMock.Setup(f => f.Print(It.IsAny<Document>())).Returns(resultMock);

            // przekazujemy go w konstruktorze (wszysto dzieje sie lokalnie w teście, już nie jest rejestrowane globalnie w lokatorze)
            var documentManager = new DocumentManager(printMock.Object);

            #region Don't do that
            
            // Tego nie chcemy robić, bo np. w innym teście jeśli ktoś chce aby inny Mock PrintManagera zwracał inny mock dokumentu,
            // to musi taki Mock PrintManagera również zarejestrować w globalnym stanie - ServiceLocatorze
            // Jeśli oba te testy uruchomią się równocześnie i najpierw pierwszy test zarejestruje swojego mocka, a potem drugi
            // to w ServiceLokatorze będzie tylko Mock tego drugiego testu
            // teraz DocumentManager w obu testach dostanie tego samego Mocka (z testu drugiego) zamiast swój właściwy Mock i test pierwszy się nie powiedzie
            // jeśli testy nie będą uruchomione równocześnie to wszystko będzie działać - testy nie są deterministyczne i nie działają w izolacji
            //var resultMock = Mock.Of<IPrintedDocument>();
            //var printMock = new Mock<IPrintManager>();
            //printMock.Setup(f => f.Print(It.IsAny<Document>())).Returns(resultMock);
            //SampleServiceLocator.Register<IPrintManager>(() => printMock.Object);

            #endregion

            //Act:
            var printedDocument = documentManager.Print(testDocument);

            //Assert:
            Assert.IsNotNull(printedDocument);
        }
    }
}
