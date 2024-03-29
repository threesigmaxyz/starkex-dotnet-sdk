﻿namespace StarkEx.Crypto.SDK.Signing;

using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using StarkEx.Commons.SDK.Models;
using StarkEx.Crypto.SDK.Constants;

/// <summary>
/// A STARK-friendly elliptic curve used in the ECDSA signature scheme.
///
/// A STARK curve is a STARK-friendly elliptic curve used is defined as follows:
/// y2 ≡ x3 + α⋅x + β (mod p).
///
/// Where:
/// α = 1
/// β= 3141592653589793238462643383279502884197169399375105820974944592307816406665
/// p= 3618502788666131213697322783095070105623107215331596699973092056135872020481
///
/// And the generator point used in the ECDSA scheme is:
/// G = (
///     874739451078007766457464989774322083649278607533249481151382481072868806602,
///     152666792071518830868575557812948353041420400780739481342941381225525861407
/// ).
///
/// Official documentation <see href="https://docs.starkware.co/starkex/crypto/stark-curve.html">here</see>.
/// </summary>
public class StarkCurve
{
    /* Curve parameters*/
    public static readonly BigInteger P = new("3618502788666131213697322783095070105623107215331596699973092056135872020481");
    private static readonly BigInteger A = BigInteger.One;
    private static readonly BigInteger B = new("3141592653589793238462643383279502884197169399375105820974944592307816406665");
    private static readonly BigInteger N = new("3618502788666131213697322783095070105526743751716087489154079457884512865583");
    private static readonly BigInteger H = BigInteger.One;
    private static readonly BigInteger Gx = new("874739451078007766457464989774322083649278607533249481151382481072868806602");

    private static readonly BigInteger Gy = new("152666792071518830868575557812948353041420400780739481342941381225525861407");
    /*******************/

    private readonly ECCurve curve;
    private readonly ECPoint pointG;

    /// <summary>
    /// Initializes a new instance of the <see cref="StarkCurve"/> class.
    /// </summary>
    public StarkCurve()
    {
        var dummy = new FpCurve(P, A, B, N, H);
        var configure = dummy.Configure();
        configure.SetCoordinateSystem(ECCurve.COORD_AFFINE);
        curve = configure.Create();
        pointG = curve.CreatePoint(Gx, Gy);
    }

    /// <summary>
    /// Gets the STARK curve order.
    /// </summary>
    /// <returns>The STARK curve order.</returns>
    public static BigInteger GetCurveOrder()
    {
        return N;
    }

    /// <summary>
    /// Gets the STARK curve generator point.
    /// </summary>
    /// <returns>The STARK curve generator point.</returns>
    public ECPoint GetGenerator()
    {
        return pointG;
    }

    /// <summary>
    /// Gets the elliptic curve point at the specified index.
    /// </summary>f
    /// <param name="index">The index of the point to retrieve.</param>
    /// <returns>The elliptic curve point at the specified index as an <see cref="ECPoint"/> object.</returns>
    public ECPoint GetEcPoint(int index)
    {
        var hexConstantPoint = EllipticCurveConstantPoints.HexConstantPoints.ElementAt(index);
        var pointX = new BigInteger(hexConstantPoint.Item1.RemoveHexPrefix(), 16);
        var pointY = new BigInteger(hexConstantPoint.Item2.RemoveHexPrefix(), 16);

        return CreatePoint(pointX, pointY);
    }

    /// <summary>
    /// Converts the specified public key to a STARK curve point.
    /// </summary>
    /// <param name="publicKey">The public key to convert to a STARK curve point.</param>
    /// <returns>The STARK curve point corresponding to the public key.</returns>
    public ECPoint GetEcPoint(BigInteger publicKey)
    {
        var encodedKey = publicKey.ToByteArray();
        var coordLength = (curve.FieldSize + 7) / 8;
        if (encodedKey.Length <= coordLength)
        {
            // pad key X coord to 64 bytes
            encodedKey = PadArray(encodedKey, coordLength);

            // add 0x02 prefix for compressed key encoding (only X)
            encodedKey = encodedKey.Prepend((byte)0x02).ToArray();
        }

        return curve.DecodePoint(encodedKey);
    }

    /// <summary>
    ///     Creates PrivateKey parameters.
    /// </summary>
    /// <param name="privateKey">X coordinate of selected point on the curve.</param>
    /// <returns>
    ///     Private key parameters with respect to G.
    /// </returns>
    public ECPrivateKeyParameters CreatePrivateKeyParams(BigInteger privateKey)
    {
        return CreatePrivateKeyParams(privateKey, GetGx(), GetGy());
    }

    /// <summary>
    ///     Creates a point in the curve.
    /// </summary>
    /// <param name="x">X coordinate of selected point on the curve.</param>
    /// <param name="y">Y coordinate of selected point on the curve.</param>
    /// <returns>
    ///     Return an point in the stark curve.
    /// </returns>
    public ECPoint CreatePoint(BigInteger x, BigInteger y)
    {
        return curve.CreatePoint(x, y);
    }

    /// <summary>
    ///     Creates a Stark Account from a Stark private key.
    /// </summary>
    /// <param name="privateKey">Stark Private key.</param>
    /// <returns>
    ///     A Stark Account.
    /// </returns>
    public StarkAccount GetStarkKeysFromPrivateStarkKey(BigInteger privateKey)
    {
        var publicKey = pointG.Multiply(privateKey);
        var publicKeyX = publicKey.XCoord.ToBigInteger();

        return new StarkAccount
        {
            PublicKey = publicKeyX.ToString(16).EnsureHexPrefix(),
            PrivateKey = privateKey.ToString(16).EnsureHexPrefix(),
        };
    }

    private static byte[] PadArray(byte[] arr, int size)
    {
        var padded = new byte[size];
        var startAt = padded.Length - arr.Length;
        Array.Copy(arr, 0, padded, startAt, arr.Length);
        return padded;
    }

    /// <summary>
    ///     Creates hash from the parameters.
    /// </summary>
    /// <param name="privateKey">Private key to apply to project from the given coords.</param>
    /// <param name="x">X coordinate of selected point on the curve.</param>
    /// <param name="y">Y coordinate of selected point on the curve.</param>
    /// <returns>
    ///     Private key with respect to selected point.
    /// </returns>
    private ECPrivateKeyParameters CreatePrivateKeyParams(BigInteger privateKey, BigInteger x, BigInteger y)
    {
        return new ECPrivateKeyParameters(
            privateKey,
            new ECDomainParameters(curve, curve.CreatePoint(x, y), N));
    }

    private BigInteger GetGx()
    {
        return pointG.XCoord.ToBigInteger();
    }

    private BigInteger GetGy()
    {
        return pointG.YCoord.ToBigInteger();
    }
}
