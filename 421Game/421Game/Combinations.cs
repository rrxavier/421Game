using System;
using System.Collections.Generic;

namespace _421Game
{
    /// <summary>
    /// Class that returns the correct Combination.
    /// </summary>
    public static class Combinations
    {
        public static Combination GetCorrectCombination(int diceRoll)
        {
            if (Is421(diceRoll))
                return Get421();
            else if (IsMac(diceRoll))
                return GetMac(diceRoll);
            else if (IsBrelan(diceRoll))
                return GetBrelan(diceRoll);
            else if (IsSuite(diceRoll))
                return GetSuite();
            else if (IsNenette(diceRoll))
                return GetNennette();
            else
                return GetOther();
        }

        private static bool Is421(int diceRoll)
        {
            if (diceRoll == 421)
                return true;
            else
                return false;
        }

        private static bool IsMac(int diceRoll)
        {
            // I do a modulo of 11 on the two last numbers AND the two first because the possible combinations are : 11, 22, 33, 44, etc..
            // So ifthe modulo returns 0, it means that there are two numbers that are the same.
            // I return false if the diceroll equals 221 because that is the "Nennette" combination.
            if (Convert.ToInt32(diceRoll.ToString().Substring(1)) % 11 == 0 || Convert.ToInt32(diceRoll.ToString().Substring(0, 2)) % 11 == 0 && diceRoll != 221)
                return true;
            else
                return false;
        }

        private static bool IsBrelan(int diceRoll)
        {
            // I do a modulo of 11 on the two last numbers because the possible combinations are : 11, 22, 33, 44, etc..
            // So if the modulo returns 0, it means that there are two numbers that are the same.
            // Then, I check if the first digit is the same as the last one.
            // I return false if the diceroll equals 221 because that is the "Nennette" combination.
            if (Convert.ToInt32(diceRoll.ToString().Substring(1)) % 11 == 0 && diceRoll.ToString()[0] == diceRoll.ToString()[2] && diceRoll != 221)
                return true;
            else
                return false;
        }

        private static bool IsSuite(int diceRoll)
        {
            var digitsList = new List<int>();

            // Taking each digit individually
            for (int tmpValue = diceRoll; tmpValue != 0; tmpValue /= 10)
                digitsList.Add(tmpValue % 10);

            int[] digitsArray = digitsList.ToArray();
            Array.Reverse(digitsArray);

            if (digitsArray[2] + 1 == digitsArray[1] && digitsArray[1] + 1 == digitsArray[0])
                return true;
            else
                return false;
        }

        private static bool IsNenette(int diceRoll)
        {
            if (diceRoll == 221)
                return true;
            else
                return false;
        }

        private static Combination Get421()
        {
            return new Combination(6, 10, "421");
        }

        private static Combination GetMac(int diceRoll)
        {
            int tokenValue = Convert.ToInt32(diceRoll.ToString()[0].ToString());
            return new Combination(5, tokenValue, "Mac");
        }

        private static Combination GetBrelan(int diceRoll)
        {
            int tokenValue = Convert.ToInt32(diceRoll.ToString()[0].ToString());
            return new Combination(4, tokenValue, "Brelan");
        }

        private static Combination GetSuite()
        {
            return new Combination(3, 2, "Suite");
        }

        private static Combination GetNennette()
        {
            return new Combination(2, 4, "Nennette");
        }

        private static Combination GetOther()
        {
            return new Combination(1, 1, "Normal combination");
        }
    }
}
