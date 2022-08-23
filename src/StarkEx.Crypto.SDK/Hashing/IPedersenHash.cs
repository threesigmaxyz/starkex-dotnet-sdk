namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;

public interface IPedersenHash
{
    /// <summary>
    ///     Creates hash from array of valid 252-bit integers parameters
    /// </summary>
    /// <param name="fields">Left field of hash function.</param>
    /// <returns>
    ///     Hash number
    /// </returns>
    BigInteger CreateHash(params BigInteger[] fields);
}