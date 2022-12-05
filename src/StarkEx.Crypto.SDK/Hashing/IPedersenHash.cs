namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;

/// <summary>
/// Represents a Pedersen hash, which is a type of cryptographic hash function that uses elliptic curve cryptography.
/// A Pedersen hash is calculated for a pair of input field elements, (a,b), which are represented as 252-bit integers.
/// The hash is calculated as follows:
///
/// H(a,b) = [P0 + a_low * P1 + a_high * P2 + b_low * P3 + b_high * P4]x
///
/// where a_low is the low 248 bits of a, a_high is the high 4 bits of a (and similarly for b), P0, P1, P2, P3, and P4 are
/// constant points on the elliptic curve derived from the decimal digits of the mathematical constant π, and Px denotes
/// the x-coordinate of an elliptic-curve point P.
/// </summary>
public interface IPedersenHash
{
    /// <summary>
    /// Creates a Pedersen hash for the specified input fields.
    /// </summary>
    /// <param name="fields">The input fields to include in the hash calculation. The field elements should be
    /// represented as 252-bit integers.</param>
    /// <returns>The resulting Pedersen hash as a <see cref="BigInteger"/> object.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the number of input fields is less than 1 or if any of the input fields are out of range.
    /// </exception>
    /// <exception cref="Exception">Thrown if an error occurs while computing the Pedersen hash.</exception>
    BigInteger CreateHash(params BigInteger[] fields);
}