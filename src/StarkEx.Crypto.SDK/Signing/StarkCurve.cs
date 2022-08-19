﻿namespace StarkEx.Crypto.SDK.Signing;

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;

public class StarkCurve
{
    /* Curve parameters*/
    private static readonly BigInteger P = new("3618502788666131213697322783095070105623107215331596699973092056135872020481");
    private static readonly BigInteger A = BigInteger.One;
    private static readonly BigInteger B = new("3141592653589793238462643383279502884197169399375105820974944592307816406665");
    private static readonly BigInteger N = new("3618502788666131213697322783095070105526743751716087489154079457884512865583");
    private static readonly BigInteger H = BigInteger.One;
    private static readonly BigInteger Gx = new("874739451078007766457464989774322083649278607533249481151382481072868806602");

    private static readonly BigInteger Gy = new("152666792071518830868575557812948353041420400780739481342941381225525861407");
    /*******************/

    private readonly ECCurve curve;
    private readonly ECPoint pointG;

    public StarkCurve()
    {
        var dummy = new FpCurve(P, A, B, N, H);
        var configure = dummy.Configure();
        configure.SetCoordinateSystem(ECCurve.COORD_AFFINE);
        curve = configure.Create();
        pointG = curve.CreatePoint(Gx, Gy);
    }

    /// <summary>
    ///     Creates PublicKeys parameters.
    /// </summary>
    /// <param name="publicKey">Public key.</param>
    /// <returns>
    ///     Public key parameters with respect to G.
    /// </returns>
    public ECPublicKeyParameters CreatePublicKeyParams(BigInteger publicKey)
    {
        return new ECPublicKeyParameters(
            curve.DecodePoint(publicKey.ToByteArray()),
            new ECDomainParameters(curve, curve.CreatePoint(GetGx(), GetGy()), N));
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