namespace StarkEx.Crypto.SDK.Hashing;

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using StarkEx.Crypto.SDK.Constants;
using StarkEx.Crypto.SDK.Signing;

public class PedersenHash : IPedersenHash
{
    private static readonly BigInteger Prime = new("800000000000011000000000000000000000000000000000000000000000001", 16);
    private readonly ECPoint shiftPoint;
    private readonly StarkCurve starkCurve;

    public PedersenHash(StarkCurve starkCurve)
    {
        this.starkCurve = starkCurve;
        shiftPoint = GetEcPoint(0);
    }

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