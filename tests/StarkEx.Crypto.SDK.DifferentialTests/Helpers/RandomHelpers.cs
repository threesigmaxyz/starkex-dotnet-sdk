namespace StarkEx.Crypto.SDK.DifferentialTests.Helpers;

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

/// <summary>
/// A collection of helper methods for generating random values.
/// </summary>
public class RandomHelpers
{
    /// <summary>
    /// Generates a random <see cref="BigInteger"/> with the specified bit length.
    /// </summary>
    /// <param name="maxValue">The max value of the <see cref="BigInteger"/> to generate.</param>
    /// <param name="bitLength">The bit length of the <see cref="BigInteger"/> to generate.</param>
    /// <returns>A random <see cref="BigInteger"/> with the specified bit length.</returns>
    public static BigInteger GetRandomBigInteger(BigInteger maxValue, int bitLength = 256)
    {
        var random = new SecureRandom();
        var seed = random.GenerateSeed(bitLength);
        return new BigInteger(seed).Mod(maxValue);
    }
}
