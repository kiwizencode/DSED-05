using System;
using System.Collections.Generic;
using System.Text;

namespace DSED05_App.Common
{
    /// <summary>
    /// Singleton Design Pattern
    /// </summary>
    public sealed class RandomGeneratorSingleton
    {
        /// <summary>
        /// using .NET 4's Lazy<T> type
        /// </summary>
        private static readonly Lazy<RandomGeneratorSingleton> lazy = new Lazy<RandomGeneratorSingleton>(() => new RandomGeneratorSingleton());
        public static RandomGeneratorSingleton Instance { get { return lazy.Value; } }

        private Random _random;
        public Random Seed { get { return _random; } }
        private RandomGeneratorSingleton()
        {
            _random = new Random(System.DateTime.Now.Millisecond);
        }
    }
}
