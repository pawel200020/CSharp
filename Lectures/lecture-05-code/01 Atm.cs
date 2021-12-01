using NUnit.Framework;
using System;

namespace Lecture5.Sample1_UnitTests
{
    /// <summary>
    /// Uproszczony bankomat
    /// </summary>
    public class Atm
    {
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
            Balance -= amount;
            return true;
        }
    }

    [TestFixture]
    class AtmTests
    {
        [Test]
        public void TestMoneyWithdrawal()
        {
            //Arrange:
            var atm = new Atm { Balance = 50 };

            //Act:
            atm.Withdraw(10);

            //Assert:
            Assert.AreEqual(40, atm.Balance);           // Classic Model
            Assert.That(atm.Balance, Is.EqualTo(40));   // Constraint Model
        }

        [TestCase(50, 10, ExpectedResult = 40)]
        [TestCase(50, 50, ExpectedResult = 0)]
        [TestCase(50, 0, ExpectedResult = 50)]
        public int BalanceIsUpdatedAfterWithdrawal(int balance, int withdrawAmount)
        {
            //Arrange:
            var atm = new Atm { Balance = balance };

            //Act:
            atm.Withdraw(withdrawAmount);

            //Assert:
            return atm.Balance;
        }

        [Test]
        public void BalanceDoesNotChangeAfterWithdrawingMoreMoneyThanInAccount(
            [Values(50)]int balance,
            [Random(51, 1000, 20)] int withdrawAmount)
        {
            //Arrange:
            var atm = new Atm { Balance = balance };

            //Act:
            var withdrawResult = atm.Withdraw(withdrawAmount);

            //Assert:
            Assert.IsFalse(withdrawResult);
            Assert.AreEqual(balance, atm.Balance);
        }
    }
}
