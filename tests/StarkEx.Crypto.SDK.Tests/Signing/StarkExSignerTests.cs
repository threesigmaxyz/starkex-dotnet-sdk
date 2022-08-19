namespace StarkEx.Crypto.SDK.Tests.Signing;

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using StarkEx.Commons.SDK.Models;
using StarkEx.Crypto.SDK.Signing;
using Xunit;

[ExcludeFromCodeCoverage]
public class StarkExSignerTests
{
    [Theory]
    [InlineData(
        "c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
        "5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
        "4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3")]
    [InlineData(
        "00c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
        "5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
        "4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3")]
    [InlineData(
        "c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47a",
        "233b88c4578f0807b4a7480c8076eca5cfefa29980dd8e2af3c46a253490e9c",
        "28b055e825bc507349edfb944740a35c6f22d377443c34742c04e0d82278cf1")]
    public void SignMessage_InputsAreValid_SignatureIsSameAsExpected(
        string messageHash,
        string expectedR,
        string expectedS)
    {
        // Arrange
        var privateKey = "2dccce1da22003777062ee0870e9881b460a8b7eca276870f57c601f182136c";
        var target = CreateStarkExSigner();
        var expectedResult = new SignatureModel
        {
            R = expectedR,
            S = expectedS,
        };

        // Act
        var result = target.SignMessage(
            messageHash,
            privateKey);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [InlineData(
        "c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
        "0400499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a00243904745865467631492cf6ecc433a3cf4ecc580d698097d6b738ad8f3da7c4d66c",
        "5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
        "4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3")]
    [InlineData(
        "00c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
        "0400499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a00243904745865467631492cf6ecc433a3cf4ecc580d698097d6b738ad8f3da7c4d66c",
        "5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
        "4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3")]
    [InlineData(
        "c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47a",
        "0400499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a00243904745865467631492cf6ecc433a3cf4ecc580d698097d6b738ad8f3da7c4d66c",
        "233b88c4578f0807b4a7480c8076eca5cfefa29980dd8e2af3c46a253490e9c",
        "28b055e825bc507349edfb944740a35c6f22d377443c34742c04e0d82278cf1")]
    [InlineData(
        "7465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47a1",
        "0400499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a00243904745865467631492cf6ecc433a3cf4ecc580d698097d6b738ad8f3da7c4d66c",
        "b6bee8010f96a723f6de06b5fa06e820418712439c93850dd4e9bde43ddf",
        "1a3d2bc954ed77e22986f507d68d18115fa543d1901f5b4620db98e2f6efd80")]
    public void VerifySignature_InputsAreValid_SignatureIsValidated(
        string messageHash,
        string publicKey,
        string signatureR,
        string signatureS)
    {
        // Arrange
        var target = CreateStarkExSigner();
        var signature = new SignatureModel
        {
            R = signatureR,
            S = signatureS,
        };

        // Act
        var result = target.VerifySignature(
            messageHash,
            publicKey,
            signature);

        // Assert
        result.Should().Be(true);
    }

    private static IStarkExSigner CreateStarkExSigner()
    {
        return new StarkExSigner(new StarkCurve());
    }
}