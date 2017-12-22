namespace Matt.Random.Adapters
{
    using System.Security.Cryptography;

    /// <inheritdoc />
    /// <summary>
    /// Adapts a <see cref="T:System.Security.Cryptography.RandomNumberGenerator" /> into an <see cref="T:Matt.Random.IRandom" />.
    /// </summary>
    public sealed class RandomNumberGeneratorAdapter : IRandom
    {
        private readonly RandomNumberGenerator _rng;

        /// <summary>
        /// Adapts a <see cref="T:System.Security.Cryptography.RandomNumberGenerator" /> into an <see cref="T:Matt.Random.IRandom" />.
        /// </summary>
        public RandomNumberGeneratorAdapter(RandomNumberGenerator rng)
        {
            _rng = rng;
        }

        /// <inheritdoc />
        public void Populate(
            byte[] buffer,
            int offset,
            int count) =>
            _rng.GetBytes(buffer, offset, count);
    }
}