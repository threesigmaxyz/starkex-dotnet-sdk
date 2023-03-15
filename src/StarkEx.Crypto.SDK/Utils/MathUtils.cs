namespace StarkEx.Crypto.SDK.Utils;

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;

public class MathUtils
{
    /// <summary>
    /// Computes m * point + shift_point using the same steps like the AIR and throws an exception if.
    /// and only if the AIR errors.
    /// </summary>
    /// <param name="value">The multiplication value.</param>
    /// /// <param name="point">The multiplication point.</param>
    /// /// <param name="shiftPoint">The multiplication shift point.</param>
    /// <returns>The AIR compliant multiplication result.</returns>
    public static ECPoint MimicEcMultiplicationAir(BigInteger value, ECPoint point, ECPoint shiftPoint)
    {
        var partialSum = shiftPoint;
        for (var i = 0; i < 251; i++)
        {
            if (value.TestBit(0))
            {
                partialSum = partialSum.Add(point);
            }

            point = point.Multiply(new BigInteger("2"));
            value = value.ShiftRight(1);
        }

        return partialSum;
    }

    public static Tuple<BigInteger, BigInteger, BigInteger> Igcdex(BigInteger a, BigInteger b)
    {
        if (a.Equals(BigInteger.Zero) && b.Equals(BigInteger.Zero))
        {
            return Tuple.Create(BigInteger.Zero, BigInteger.One, BigInteger.Zero);
        }

        if (a.Equals(BigInteger.Zero))
        {
            return Tuple.Create(BigInteger.Zero, b.Divide(b.Abs()), b.Abs());
        }

        if (b.Equals(BigInteger.Zero))
        {
            return Tuple.Create(a.Divide(a.Abs()), BigInteger.Zero, a.Abs());
        }

        var xSign = BigInteger.One;
        var ySign = BigInteger.One;

        // check if a < 0
        if (a.SignValue == -1)
        {
            a = a.Negate();
            xSign = xSign.Negate();
        }

        // check if b < 0
        if (b.SignValue == -1)
        {
            b = b.Negate();
            ySign = ySign.Negate();
        }

        var x = BigInteger.One;
        var y = BigInteger.Zero;
        var r = BigInteger.Zero;
        var s = BigInteger.One;

        while (!b.Equals(BigInteger.Zero))
        {
            var c = a.Mod(b); // a % b;
            var q = a.Divide(b); // a / b;

            var tempR = r;
            r = x.Subtract(q.Multiply(r)); // x - q * r;
            x = tempR;

            var tempS = s;
            s = y.Subtract(q.Multiply(s)); // y - q * s;
            y = tempS;

            a = b;
            b = c;
        }

        return Tuple.Create(x.Multiply(xSign), y.Multiply(ySign), a);
    }
}
