using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vithal.Framework.Core.UnitTests
{

    public abstract class TestBase
    {
        Random _random;

        public TestBase()
        {
            _random = new Randomizer();
        }

        #region Random value methods

        /// <summary>
        /// Returns a random decimal value between 0 and 10,000.
        /// </summary>
        /// <returns>Decimal.</returns>
        protected decimal GetRandomDecimal()
        {
            return this.GetRandomDecimal(0, 10000);
        }

        /// <summary>
        /// Returns a random decimal between the given minimum and maximum values.
        /// </summary>
        /// <param name="minimum">Minimum value.</param>
        /// <param name="maximum">Maximum value.</param>
        /// <returns>Decimal.</returns>
        protected decimal GetRandomDecimal(decimal minimum, decimal maximum)
        {
            decimal randomValue = Convert.ToDecimal(_random.NextDouble());
            decimal range = Math.Abs(maximum - minimum);
            decimal adjustedValue = randomValue * range;
            return minimum + adjustedValue;
        }

        /// <summary>
        /// Returns a random DateTime value.
        /// </summary>
        /// <returns>DateTime.</returns>
        protected DateTime GetRandomDateTime()
        {
            int minutes = this.GetRandomInt(-10000, 10000);
            TimeSpan timeSpan = TimeSpan.FromMinutes(minutes);
            return DateTime.Now.Subtract(timeSpan);
        }

        /// <summary>
        /// Returns a random Guid value.
        /// </summary>
        /// <returns>Guid.</returns>
        protected Guid GetRandomGuid()
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// Returns a random integer between the given minimum and maximum values.
        /// </summary>
        /// <param name="minimum">Minimum value.</param>
        /// <param name="maximum">Maximum value.</param>
        /// <returns>Int.</returns>
        protected int GetRandomInt(int minimum, int maximum)
        {
            return _random.Next(minimum, maximum);
        }

        /// <summary>
        /// Returns a random string value.
        /// </summary>
        /// <returns>String.</returns>
        protected string GetRandomString()
        {
            return this.GetRandomGuid().ToString();
        }

        /// <summary>
        /// Returns a random string value.
        /// </summary>
        /// <returns>String.</returns>
        protected string GetRandomString(int length)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            Random rnd = new Random();
            for (int index = 0; index < length; index++)
            {
                char newChar = (char)rnd.Next(65, 95);
                builder.Append(newChar);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Returns a random bool value.
        /// </summary>
        /// <returns>Bool.</returns>
        protected bool GetRandomBool()
        {
            int randomNumber = this.GetRandomInt(1, 100);
            return (randomNumber % 2 == 0);
        }

        #endregion
    }
}
