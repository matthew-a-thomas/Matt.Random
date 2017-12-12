namespace Matt.Random.Adapters
{
    using System.Security.Cryptography;

    public sealed class RandomNumberGeneratorAdapter : IRandom
    {
        private readonly RandomNumberGenerator _rng;

        public RandomNumberGeneratorAdapter(RandomNumberGenerator rng)
        {
            _rng = rng;
        }

        public void Populate(
            byte[] buffer,
            int offset,
            int count) =>
            _rng.GetBytes(buffer, offset, count);
    }
}