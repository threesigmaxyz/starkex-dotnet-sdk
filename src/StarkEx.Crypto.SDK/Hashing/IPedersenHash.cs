namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;

public interface IPedersenHash
{
    /// <summary>
    /// Creates hash from the parameters
    /// </summary>
    /// <param name="leftField">Left field of hash function.</param>
    /// <param name="rightField">Right field of hash function.</param>
    /// <returns>
    /// Hash number
    /// </returns>
    BigInteger CreateHash(BigInteger leftField, BigInteger rightField);
}