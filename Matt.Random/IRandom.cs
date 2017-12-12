namespace Matt.Random
{
    /// <summary>
    /// Populates arrays with random bytes.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Populates the given array with random bytes.
        /// </summary>
        void Populate(
            byte[] buffer,
            int offset,
            int count);
    }
}