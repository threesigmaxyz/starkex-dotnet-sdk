namespace StarkEx.Crypto.SDK.Hashing;

using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using StarkEx.Crypto.SDK.Constants;
using StarkEx.Crypto.SDK.Signing;

/// <inheritdoc />
public class PedersenHash : IPedersenHash
{
    /// <summary>
    /// The prime number used in the calculation of the Pedersen hash.
    /// </summary>
    private static readonly BigInteger Prime = new("800000000000011000000000000000000000000000000000000000000000001", 16);

    /// <summary>
    /// The point used as the base for calculating the Pedersen hash.
    /// </summary>
    private readonly ECPoint shiftPoint;

    /// <summary>
    /// The elliptic curve used in the calculation of the Pedersen hash.
    /// </summary>
    private readonly StarkCurve starkCurve;

    /// <summary>
    /// Initializes a new instance of the <see cref="PedersenHash"/> class using the specified elliptic curve.
    /// </summary>
    /// <param name="starkCurve">The elliptic curve to use in the calculation of the Pedersen hash.</param>
    public PedersenHash(StarkCurve starkCurve)
    {
        this.starkCurve = starkCurve;
        shiftPoint = GetEcPoint(0);
    }

    /// <inheritdoc />
    public BigInteger CreateHash(params BigInteger[] fields)
    {
        if (fields.Length < 1)
        {
            throw new ArgumentException("Number of fields must be at least 1");
        }

        ValidateHashInput(fields[0], nameof(fields));

        var point = CalculateEllipticCurvePoint(shiftPoint, 0, fields[0]);
        var index = 1;

        foreach (var field in fields.Skip(1))
        {
            ValidateHashInput(field, nameof(fields));
            point = CalculateEllipticCurvePoint(point, index++, field);
        }

        return point.XCoord.ToBigInteger();
    }

    /// <summary>
    /// Validates that the specified input field is within the valid range for a Pedersen hash.
    /// </summary>
    /// <param name="input">The input field to validate.</param>
    /// <param name="fieldName">The name of the input field.</param>
    /// <exception cref="ArgumentException">
    /// Thrown if the input field is out of range.
    /// </exception>
    private static void ValidateHashInput(BigInteger input, string fieldName)
    {
        if (!(input.CompareTo(BigInteger.Zero) >= 0 && input.CompareTo(Prime) < 0))
        {
            throw new ArgumentException($"Input to pedersen hash out of range: {input}", fieldName);
        }
    }

    /// <summary>
    /// Calculates an elliptic curve point using the specified base point, index, and field value.
    /// </summary>
    /// <param name="basePoint">The base point to use in the calculation.</param>
    /// <param name="index">The index to use in the calculation.</param>
    /// <param name="field">The field value to use in the calculation.</param>
    /// <returns>The resulting elliptic curve point as an <see cref="ECPoint"/> object.</returns>
    private ECPoint CalculateEllipticCurvePoint(ECPoint basePoint, int index, BigInteger field)
    {
        var newPoint = basePoint;

        for (var i = 0; i < 252; i++)
        {
            var tmpCoords = GetEcPoint(2 + (index * 252) + i);

            if (basePoint.XCoord.Equals(tmpCoords.XCoord))
            {
                throw new Exception("Error computing pedersen hash");
            }

            if (!field.And(BigInteger.One).Equals(BigInteger.Zero))
            {
                newPoint = newPoint.Add(tmpCoords);
            }

            field = field.ShiftRight(1);
        }

        return newPoint;
    }

    /// <summary>
    /// Gets the elliptic curve point at the specified index.
    /// </summary>f
    /// <param name="index">The index of the point to retrieve.</param>
    /// <returns>The elliptic curve point at the specified index as an <see cref="ECPoint"/> object.</returns>
    private ECPoint GetEcPoint(int index)
    {
        var hexConstantPoint = EllipticCurveConstantPoints.HexConstantPoints.ElementAt(index);
        var pointX = new BigInteger(hexConstantPoint.Item1.RemoveHexPrefix(), 16);
        var pointY = new BigInteger(hexConstantPoint.Item2.RemoveHexPrefix(), 16);

        return starkCurve.CreatePoint(pointX, pointY);
    }
}
