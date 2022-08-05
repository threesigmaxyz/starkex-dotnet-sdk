namespace StarkEx.Crypto.SDK.Signing;

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

    /**
     * @param privateKey private key
     * @param x          x coordinate of selected point on the curve
     * @param y          y coordinate of selected point on the curve
     * @return private key with respect to selected point
     */
    public ECPrivateKeyParameters CreatePrivateKeyParams(BigInteger privateKey, BigInteger x, BigInteger y)
    {
        return new ECPrivateKeyParameters(
                privateKey,
                new ECDomainParameters(curve, curve.CreatePoint(x, y), N));
    }

    /**
     * @param publicKey public key
     * @param x         x coordinate of selected point on the curve
     * @param y         y coordinate of selected point on the curve
     * @return public key parameters with respect to selected point
     */
    public ECPublicKeyParameters CreatePublicKeyParams(BigInteger publicKey, BigInteger x, BigInteger y)
    {
        return new ECPublicKeyParameters(
                curve.DecodePoint(publicKey.ToByteArray()),
                new ECDomainParameters(curve, curve.CreatePoint(x, y), N));
    }

    /**
     * @param publicKey public key
     * @return public key parameter with respect to G
     */
    public ECPublicKeyParameters CreatePublicKeyParams(BigInteger publicKey)
    {
        return new ECPublicKeyParameters(
                curve.DecodePoint(publicKey.ToByteArray()),
                new ECDomainParameters(curve, curve.CreatePoint(GetGx(), GetGy()), N));
    }

    /**
     * creates public key from private key
     *
     * @param privateKey
     * @return public Key
     */
    public BigInteger GeneratePublicKeyFromPrivateKey(BigInteger privateKey)
    {
        return new BigInteger(pointG.Multiply(privateKey).GetEncoded(true));
    }

    /**
     * creates private key parameters with respect to G point
     *
     * @param privateKey
     * @return ECPrivateKeyParameters
     */
    public ECPrivateKeyParameters CreatePrivateKeyParams(BigInteger privateKey)
    {
        return CreatePrivateKeyParams(privateKey, GetGx(), GetGy());
    }

    /**
     *  returns point on curve which has given coordinates
     * @param x
     * @param y
     * @return point on the curve
     */
    public ECPoint CreatePoint(BigInteger x, BigInteger y)
    {
        return curve.CreatePoint(x, y);
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