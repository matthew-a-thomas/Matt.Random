namespace Matt.Random
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Cryptography;
    using Adapters;
    using Bits;

    public static class RandomExtensions
    {
        /// <summary>
        /// Adapts this <see cref="Random"/> into an <see cref="IRandom"/>.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static IRandom AsRandom(Random random) => new RandomAdapter(random);
        
        /// <summary>
        /// Adapts this <see cref="RandomNumberGenerator"/> into an <see cref="IRandom"/>.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static IRandom AsRandom(RandomNumberGenerator rng) => new RandomNumberGeneratorAdapter(rng);
        
        /// <summary>
        /// Populates the entire array with random bytes.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public static void Populate(
            this IRandom random,
            byte[] buffer) =>
            random.Populate(
                buffer,
                0,
                buffer.Length);
        
        /// <summary>
        /// Produces an endless sequence of random bits from this <see cref="IRandom"/>.
        /// </summary>
        [SuppressMessage("ReSharper", "IteratorNeverReturns")]
        public static IEnumerable<bool> ToEndlessBitSequence(this IRandom random)
        {
            var buffer = new byte[4];
            while (true)
            {
                random.Populate(buffer);
                foreach (var bit in buffer.ToBits())
                    yield return bit;
            }
        }
    }
}