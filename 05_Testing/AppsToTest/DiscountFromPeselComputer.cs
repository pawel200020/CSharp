﻿using _05_testing.Interfaces;
using System;
using System.Collections.Generic;

namespace _05_testing
{

    public class InvalidPeselException : Exception
    {
        public InvalidPeselException(string message) : base(message) { }
    }


    public class DiscountFromPeselComputer : IDiscountFromPeselComputer
    {

        public bool HasDiscount(string pesel)
        {
            try
            {
                int year = Int32.Parse(pesel.Substring(0, 2));
                int Month = Int32.Parse(pesel.Substring(2, 2));
                int day = Int32.Parse(pesel.Substring(4, 2));
                DateTime birthDate = new DateTime(DateTime.Now.Year - year > 2000 ? 2000 + year : 1900 + year, Month, day);
                if ((DateTime.Now.Year - birthDate.Year) == 18 || (DateTime.Now.Year - birthDate.Year) == 65)
                {
                    if (DateTime.Now.Month - birthDate.Month <= 0)
                    {
                        if (DateTime.Now.Day - birthDate.Day < 0)
                        {
                            return true;
                        }
                    }
                }
                else if ((DateTime.Now.Year - birthDate.Year) < 18 || (DateTime.Now.Year - birthDate.Year) > 65)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw new InvalidPeselException(e.Message);
            }
        }
    }
    //przykładowa implementacja z pegaza
    //    public bool HasDiscount(string pesel)
    //    {
    //        try
    //        {
    //            int year = Int32.Parse(pesel.Substring(0, 2));
    //            int Month = Int32.Parse(pesel.Substring(2, 2));
    //            int day = Int32.Parse(pesel.Substring(4, 2));
    //            DateTime birthDate = new DateTime(DateTime.Now.Year - year > 2000 ? 2000 + year : 1900 + year, Month, day);

    //            if (!Math.Floor(DateTime.Now.Subtract(birthDate).TotalDays / 365.2425).IsBetween(18, 65))
    //            {
    //                return true;
    //            }

    //            return false;
    //        }
    //        catch (Exception e)
    //        {
    //            throw new InvalidPeselException(e.Message);
    //        }
    //    }
    //}

    public static class ExtensionsNumeric
    {
        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0 && Comparer<T>.Default.Compare(item, end) <= 0;
        }
    }
}