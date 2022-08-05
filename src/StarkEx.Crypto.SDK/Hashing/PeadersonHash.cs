namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using StarkEx.Crypto.SDK.Constants;
using StarkEx.Crypto.SDK.Signing;

public class PeadersonHash : IPeadersonHash
{
    private static readonly BigInteger Prime = new("800000000000011000000000000000000000000000000000000000000000001", 16);
    private readonly StarkCurve starkCurve;
    private readonly ECPoint shiftPoint;

    public PeadersonHash(StarkCurve starkCurve)
    {
        this.starkCurve = starkCurve;
        shiftPoint = GetEcPoint(0);
    }

    public BigInteger CreateHash(BigInteger leftField, BigInteger rightField)
    {
        ValidateHashInput(leftField, nameof(leftField));
        ValidateHashInput(rightField, nameof(rightField));

        var point = CalculateEllipticCurvePoint(shiftPoint, 0, leftField);
        point = CalculateEllipticCurvePoint(point, 1, rightField);

        return point.XCoord.ToBigInteger();
    }

    private static void ValidateHashInput(BigInteger input, string fieldName)
    {
        if (!(input.CompareTo(BigInteger.Zero) >= 0 && input.CompareTo(Prime) < 0))
        {
            throw new ArgumentException($"Input to pedersen hash out of range: {input}", fieldName);
        }
    }

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

    private ECPoint GetEcPoint(int index)
    {
        var hexConstantPoint = EllipticCurveConstantPoints.HexConstantPoints.ElementAt(index);
        var pointX = new BigInteger(hexConstantPoint.Item1, 16);
        var pointY = new BigInteger(hexConstantPoint.Item2, 16);
        return starkCurve.CreatePoint(pointX, pointY);
    }
}