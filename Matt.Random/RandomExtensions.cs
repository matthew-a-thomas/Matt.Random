namespace Matt.Random
{
    public static class RandomExtensions
    {
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