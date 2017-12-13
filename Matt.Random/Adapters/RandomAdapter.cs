namespace Matt.Random.Adapters
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// Adapts a <see cref="T:System.Random" /> into an <see cref="T:Matt.Random.IRandom" />.
    /// </summary>
    public sealed class RandomAdapter : IRandom
    {
        private readonly Random _random;

        public RandomAdapter(Random random)
        {
            _random = random;
        }

        public void Populate(
            byte[] buffer,
            int offset,
            int count)
        {
            var temp = new byte[count];
            _random.NextBytes(temp);
            temp.CopyTo(buffer, offset);
        }
    }
}