using _05_testing.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _05_testing
{
    [TestClass]
    public class IDiscountFromPeselComputerTest
    {
        private string getAgePesel(int age)
        {
            int year = DateTime.Now.Year - age;
            int month = DateTime.Now.Month;
            //if (year >= 2000)
            //{
            //    month += 20;
            //}
            int day = 1;

            return year.ToString()[2].ToString() + year.ToString()[3].ToString() + month.ToString() + day.ToString() + "03677";
        }
        [TestMethod]
        public void Discount18()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(false, t.HasDiscount(getAgePesel(18)));
        }
        [TestMethod]
        public void Discount19()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(false, t.HasDiscount(getAgePesel(19)));
        }
        [TestMethod]
        public void Discount17()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(true, t.HasDiscount(getAgePesel(17)));
        }
        [TestMethod]
        public void Discount64()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(false, t.HasDiscount(getAgePesel(64)));
        }
        [TestMethod]
        public void Discount65()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(false, t.HasDiscount(getAgePesel(65)));
        }
        [TestMethod]
        public void Discount66()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(true, t.HasDiscount(getAgePesel(66)));
        }
        [TestMethod]
        public void Discount40()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(false, t.HasDiscount(getAgePesel(40)));
        }
        [TestMethod]
        public void Discount20()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(false, t.HasDiscount(getAgePesel(20)));
        }
        [TestMethod]
        public void Discount2()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            Assert.AreEqual(true, t.HasDiscount(getAgePesel(2)));
        }
        [TestMethod]
        public void dayafter18birthday()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            int year = DateTime.Now.Year - 18;
            int month = DateTime.Now.Month != 1 ? DateTime.Now.Month - 1 : 1;
            int day = DateTime.Now.Day != 1 ? DateTime.Now.Day - 1 : 1;
            if (DateTime.Now.Month == 1 && DateTime.Now.Day == 1)
            {
                year -= 1;
                month = 12;
                day = 31;
            }
            if (DateTime.Now.Day == 1)
            {
                month -= 1;
                if (month == 1 || month == 3 || month == 5 || month == 6 || month == 8 || month == 10 || month == 12)
                {
                    day = 31;
                }
                if (month == 2)
                {
                    day = 28;
                }
                else
                {
                    day = 30;
                }
            }
            Assert.AreEqual(false, t.HasDiscount(year.ToString()[2].ToString() + year.ToString()[3].ToString() + month.ToString() + day.ToString() + "03677"));
        }
        [TestMethod]
        public void daybefore18birthday()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            int year = DateTime.Now.Year - 18;
            int month = DateTime.Now.Month;
            int day;
            if (DateTime.Now.Month == 12 && DateTime.Now.Day == 31)
            {
                year += 1;
                month = 1;
                day = 1;
            }
            else
            {
                if ((DateTime.Now.Day == 31 && (month == 1 || month == 3 || month == 5 || month == 6 || month == 8 || month == 10)) || DateTime.Now.Day == 28 && month == 2 || (DateTime.Now.Day == 30 && (month == 4 || month == 7 || month == 9 || month == 11)))
                {
                    day = 1;
                    month++;
                }
                else
                {
                    day = DateTime.Now.Day + 1;
                }
            }  
            Assert.AreEqual(true, t.HasDiscount(year.ToString()[2].ToString() + year.ToString()[3].ToString() + month.ToString() + day.ToString() + "03677"));
        }
        [TestMethod]
        public void daybefore65birthday()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            int year = DateTime.Now.Year - 65;
            int month = DateTime.Now.Month;
            int day;
            if (DateTime.Now.Month == 12 && DateTime.Now.Day == 31)
            {
                year += 1;
                month = 1;
                day = 1;
            }
            else
            {
                if ((DateTime.Now.Day == 31 && (month == 1 || month == 3 || month == 5 || month == 6 || month == 8 || month == 10)) || DateTime.Now.Day == 28 && month == 2 || (DateTime.Now.Day == 30 && (month == 4 || month == 7 || month == 9 || month == 11)))
                {
                    day = 1;
                    month++;
                }
                else
                {
                    day = DateTime.Now.Day + 1;
                }
            }
            Assert.AreEqual(true, t.HasDiscount(year.ToString()[2].ToString() + year.ToString()[3].ToString() + month.ToString() + day.ToString() + "03677"));
        }
        [TestMethod]
        public void dayafter65birthday()
        {
            IDiscountFromPeselComputer t = new DiscountFromPeselComputer();
            int year = DateTime.Now.Year - 65;
            int month = DateTime.Now.Month != 1 ? DateTime.Now.Month - 1 : 1;
            int day = DateTime.Now.Day != 1 ? DateTime.Now.Day - 1 : 1;
            if (DateTime.Now.Month == 1 && DateTime.Now.Day == 1)
            {
                year -= 1;
                month = 12;
                day = 31;
            }
            if (DateTime.Now.Day == 1)
            {
                month -= 1;
                if (month == 1 || month == 3 || month == 5 || month == 6 || month == 8 || month == 10 || month == 12)
                {
                    day = 31;
                }
                if (month == 2)
                {
                    day = 28;
                }
                else
                {
                    day = 30;
                }
            }
            Assert.AreEqual(false, t.HasDiscount(year.ToString()[2].ToString() + year.ToString()[3].ToString() + month.ToString() + day.ToString() + "03677"));
        }
    }
}


