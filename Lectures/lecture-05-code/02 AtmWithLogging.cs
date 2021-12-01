using Moq;
using NUnit.Framework;
using System;

namespace Lecture5.Sample2_Mock
{
    public interface IBankOperationsLogger
    {
        void LogWithdraw(int amount);
    }

    public class BankOperationsLogger : IBankOperationsLogger
    {
        public void LogWithdraw(int amount)
        {
            //Logowanie do bazy danych wypłaconej kwoty.
            //Nie mamy dostępu ze środowiska developerów
            //więc dostaniemy wyjątek:

            throw new Exception("Cannot connect to DB.");
        }
    }

    /// <summary>
    /// Bankomat z logowaniem
    /// </summary>
    public class AtmWithLogging
    {
        private readonly IBankOperationsLogger _bankOperationsLogger;

        public AtmWithLogging(IBankOperationsLogger bankOperationsLogger)
        {
            _bankOperationsLogger = bankOperationsLogger;
        }

        /// <summary>
        /// Ile jest jeszcze pieniedzy w bankomacie .
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Proba wyjecia pieniedzy z bankomatu.
        /// </summary>
        public bool Withdraw(int amount)
        {
            if (amount > Balance)
                return false;
            _bankOperationsLogger.LogWithdraw(amount);
            Balance -= amount;
            return true;
        }
    }

    [TestFixture]
    class AtmWithLoggingTestsWithoutMock
    {
        [Test]
        public void TestMoneyWithdrawal()
        {
            //Arrange:
            var account = new AtmWithLogging(new BankOperationsLogger())
            { Balance = 50 };

            //Act:
            account.Withdraw(10);

            //Assert:
            Assert.AreEqual(40, account.Balance);
        }
    }

    [TestFixture]
    class AtmWithLoggingTests
    {
        [Test]
        public void TestMoneyWithdrawal()
        {
            //Arrange:
            var loggerMock = Mock.Of<IBankOperationsLogger>();
            var atm = new AtmWithLogging(loggerMock) { Balance = 50 };

            //Act:
            atm.Withdraw(10);

            //Assert:
            Assert.AreEqual(40, atm.Balance);
        }

        [Test]
        public void TestMoneyWithdrawal_NoConnectionToDb()
        {
            //Arrange:
            var loggerMock = new Mock<IBankOperationsLogger>();     
            loggerMock
                .Setup(mock => mock.LogWithdraw(-10))
                .Throws<Exception>();

            var atm = new AtmWithLogging(loggerMock.Object) { Balance = 50 };

            //Act:
            TestDelegate operation =
                () => atm.Withdraw(-10);

            //Assert:
            Assert.Throws<Exception>(operation);

            #region Co jest złego w tym teście?
            // przykład testu, który testuje Mocki, a nie logikę programu
            #endregion
        }


        [Test]
        public void TestMoneyWithdrawal_LogsExactlyOnce()
        {
            //Arrange:
            var loggerMock = new Mock<IBankOperationsLogger>(MockBehavior.Strict);         // MockBehavior.Strict
            loggerMock
                .Setup(mock => mock.LogWithdraw(10));

            var atm = new AtmWithLogging(loggerMock.Object) { Balance = 50 };

            //Act:
            atm.Withdraw(10);
            atm.Withdraw(20);

            //Assert:
            Assert.AreEqual(20, atm.Balance);
            loggerMock.Verify(mock => mock.LogWithdraw(10), Times.Once);
        }
    }
}
