namespace Matt.Random
{
    /// <summary>
    /// Populates arrays with random bytes in a non-thread-safe way.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Populates the given array with random bytes in a non-thread-safe way.
        /// </summary>
        void Populate(
            byte[] buffer,
            int offset,
            int count);
    }
}