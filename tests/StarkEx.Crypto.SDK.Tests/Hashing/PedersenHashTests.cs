namespace StarkEx.Crypto.SDK.Tests.Hashing;

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Hashing;
using StarkEx.Crypto.SDK.Signing;
using Xunit;

[ExcludeFromCodeCoverage]
public class PedersenHashTests
{
    [Theory]
    [InlineData("3d937c035c878245caf64531a5756109c53068da139362728feb561405371cb", "208a0a10250e382e1e4bbe2880906c2791bf6275695e02fbbc6aeff9cd8b31a", "30e480bed5fe53fa909cc0f8c4d99b8f9f2c016be4c41e13a4848797979c662")]
    [InlineData("58f580910a6ca59b28927c08fe6c43e2e303ca384badc365795fc645d479d45", "78734f65a067be9bdb39de18434d71e79f7b6466a4b66bbd979ab9e7515fe0b", "68cc0b76cddd1dd4ed2301ada9b7c872b23875d5ff837b3a87993e0d9996b87")]
    public void CreateHash_InputsAreValid_ResultIsAsExpected(
        string leftFieldHex,
        string rightFieldHex,
        string expectedOutputHex)
    {
        // Arrange
        var leftField = new BigInteger(leftFieldHex, 16);
        var rightField = new BigInteger(rightFieldHex, 16);
        var expectedOutput = new BigInteger(expectedOutputHex, 16);
        var target = CreatePedersenHash();

        // Act
        var result = target.CreateHash(leftField, rightField);

        // Assert
        result.Should().Be(expectedOutput);
    }

    private IPedersenHash CreatePedersenHash()
    {
        return new PedersenHash(
            new StarkCurve());
    }
}