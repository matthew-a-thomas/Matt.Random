namespace Matt.Random
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Cryptography;
    using Adapters;

    [SuppressMessage("ReSharper",
        "UnusedMember.Global")]
    public static class RandomExtensions
    {
        /// <summary>
        /// Adapts this <see cref="Random"/> into an <see cref="IRandom"/>.
        /// </summary>
        public static IRandom AsRandom(Random random) => new RandomAdapter(random);
        
        /// <summary>
        /// Adapts this <see cref="RandomNumberGenerator"/> into an <see cref="IRandom"/>.
        /// </summary>
        public static IRandom AsRandom(RandomNumberGenerator rng) => new RandomNumberGeneratorAdapter(rng);
        
        /// <summary>
        /// Populates the entire array with random bytes.
        /// </summary>
        public static void Populate(
            this IRandom random,
            byte[] buffer) =>
            random.Populate(
                buffer,
                0,
                buffer.Length);
    }
}