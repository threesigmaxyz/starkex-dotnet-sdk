namespace StarkEx.Crypto.SDK.DifferentialTests.Utils;

using FluentAssertions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.DifferentialTests.Helpers;
using StarkEx.Crypto.SDK.DifferentialTests.Helpers.Attributes;
using StarkEx.Crypto.SDK.Signing;
using StarkEx.Crypto.SDK.Utils;
using Xunit;

public class MathUtilsDifferentialTests
{
    [Theory]
    [Repeat(10)]
    #pragma warning disable xUnit1026
    public void MimicEcMultiplicationAir_DifferentialTesting_ResultsMatch(int runId)
    {
        // Generate random inputs.
        var value = RandomHelpers.GetRandomBigInteger(new BigInteger("2").Pow(251));

        // Compute other inputs.
        var starkCurve = new StarkCurve();
        var point = starkCurve.GetGenerator();
        var shiftPoint = starkCurve.GetEcPoint(0);

        // Run C# implementation.
        var result = MathUtils.MimicEcMultiplicationAir(value, point, shiftPoint);

        // Run Python implementation.
        var controlResult = PythonHelpers.MimicEcMultiplicationAir(value, point, shiftPoint);

        // Compare results.
        result.Should().Be(controlResult);
    }
    #pragma warning restore
}
