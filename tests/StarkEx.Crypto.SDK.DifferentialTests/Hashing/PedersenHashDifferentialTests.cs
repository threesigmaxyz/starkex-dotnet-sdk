namespace StarkEx.Crypto.SDK.DifferentialTests.Hashing;

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using StarkEx.Crypto.SDK.DifferentialTests.Helpers;
using StarkEx.Crypto.SDK.DifferentialTests.Helpers.Attributes;
using StarkEx.Crypto.SDK.Hashing;
using StarkEx.Crypto.SDK.Signing;
using Xunit;

[ExcludeFromCodeCoverage]
public class PedersenHashDifferentialTests
{
    [Theory]
    [Repeat(10)]
    public void CreateHash_InputsAreValid_ResultsMatch(int runId)
    {
        // Generate random inputs.
        var leftField = RandomHelpers.GetRandomBigInteger(PedersenHash.Prime);
        var rightField = RandomHelpers.GetRandomBigInteger(PedersenHash.Prime);

        // Run C# implementation.
        var target = CreatePedersenHash();
        var result = target.CreateHash(leftField, rightField);

        // Run Python implementation.
        var controlResult = PythonHelpers.Hash(leftField, rightField);

        // Compare results.
        result.Should().Be(controlResult);
    }

    private IPedersenHash CreatePedersenHash()
    {
        return new PedersenHash(new StarkCurve());
    }
}
