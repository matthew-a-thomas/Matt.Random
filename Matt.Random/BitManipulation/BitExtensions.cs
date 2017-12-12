namespace Matt.Random.BitManipulation
{
    using System.Collections.Generic;

    internal static class BitExtensions
    {
        public static IEnumerable<bool> ToBits(this IEnumerable<byte> bytes)
        {
            foreach (var @byte in bytes)
            {
                for (byte shift = 0; shift < 8; ++shift)
                    yield return ((@byte << shift) & 0x80) != 0;
            }
        }
        
        public static IEnumerable<byte> ToBytes(this IEnumerable<bool> bits)
        {
            byte shift = 0;
            byte accumulate = 0;
            foreach (var bit in bits)
            {
                accumulate <<= 1;
                if (bit)
                    accumulate |= 1;
                ++shift;

                if (shift != 8)
                    continue;
                
                yield return accumulate;
                accumulate = 0;
                shift = 0;
            }
            if (shift == 0)
                yield break;
            
            while (shift++ != 8)
                accumulate <<= 1;
            yield return accumulate;
        }
    }
}