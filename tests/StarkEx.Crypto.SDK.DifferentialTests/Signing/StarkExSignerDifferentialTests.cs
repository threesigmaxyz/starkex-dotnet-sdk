namespace StarkEx.Crypto.SDK.DifferentialTests.Signing;

using FluentAssertions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.DifferentialTests.Helpers;
using StarkEx.Crypto.SDK.DifferentialTests.Helpers.Attributes;
using StarkEx.Crypto.SDK.Signing;
using Xunit;

public class StarkExSignerDifferentialTests
{
    [Theory]
    [Repeat(10)]
    public void SignMessage_InputsAreValid_ResultsMatch(int runId)
    {
        // Generate random inputs.
        var messageHash = RandomHelpers.GetRandomBigInteger(new BigInteger("2").Pow(251)).ToString(16);
        var privateKey = RandomHelpers.GetRandomBigInteger(new BigInteger("2").Pow(251)).ToString(16);

        // Run C# implementation.
        var target = CreateStarkExSigner();
        var result = target.SignMessage(messageHash, privateKey);

        // Run Python implementation.
        var controlResult = PythonHelpers.Sign(messageHash, privateKey);

        // Compare results.
        result.R.Should().Be(controlResult.R);
        result.S.Should().Be(controlResult.S);
    }

    [Theory]
    [Repeat(10)]
    public void VerifySignature_DifferentialTesting_ResultsMatch(int runId)
    {
        // Generate random inputs.
        var messageHash = RandomHelpers.GetRandomBigInteger(new BigInteger("2").Pow(251)).ToString(16);
        var privateKey = RandomHelpers.GetRandomBigInteger(new BigInteger("2").Pow(251)).ToString(16);

        // Compute other inputs.
        var target = CreateStarkExSigner();
        var publicKey = target.GetPublicStarkKeyFromPrivateKey(privateKey);
        var signature = target.SignMessage(messageHash, privateKey);

        // Run C# implementation.
        var result = target.VerifySignature(messageHash, publicKey, signature);

        // Run Python implementation.
        var controlResult = PythonHelpers.Verify(messageHash, signature, publicKey);

        // Compare results.
        result.Should().BeTrue();
        controlResult.Should().BeTrue();
    }

    private static IStarkExSigner CreateStarkExSigner()
    {
        return new StarkExSigner(new StarkCurve());
    }
}
