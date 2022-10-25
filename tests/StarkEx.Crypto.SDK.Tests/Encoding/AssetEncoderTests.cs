namespace StarkEx.Crypto.SDK.Tests.Encoding;

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Encoding;
using StarkEx.Crypto.SDK.Enums;
using Xunit;

[ExcludeFromCodeCoverage]
public class AssetEncoderTests
{
    [Theory]
    [InlineData(AssetType.Eth, "1", null, null, null, "0x1142460171646987f20c714eda4b92812b22b811f56f27130937c267e29bd9e")]
    [InlineData(AssetType.Eth, "10000000", null, null, null, "0xd5b742d29ab21fdb06ac5c7c460550131c0b30cbc4c911985174c0ea4a92ec")]
    [InlineData(AssetType.Erc20, "10000", "0xdAC17F958D2ee523a2206206994597C13D831ec7", null, null, "0x352386d5b7c781d47ecd404765307d74edc4d43b0490b8e03c71ac7a7429653")]
    [InlineData(AssetType.Erc721, "1", "0xB18ed4768F87b0fFAb83408014f1caF066b91380", "1004", null, "0x2b0ff0c09505bc40f9d1659becf16855a7b2298b010f8a54f4b05325885b40c")]
    [InlineData(AssetType.Erc1155, "1", "0x22c36BfdCef207F9c0CC941936eff94D4246d14A", "0x539", null, "0x3bac60418017ad6c32f23980201722fbe672d9bd108765469484347b00afda")]
    [InlineData(AssetType.MintableErc20, "1000000000", "0x5da41d8b03b656ac0daac9f27b98feba461dfbad", null, "0xdeadbeef", "0x400f163c4d559288a2edbb10162eed11f4de87c56875b970fee1534da69cc80")]
    [InlineData(AssetType.MintableErc721, "1", "0x7a42586b2ab661458097094582b22b3c05342bd9", null, "0xdeadbeef", "0x400715adb86fb84bc0c27f4aff1f78fb6118b5b5e978fd7e0e047634a3a56d9")]
    public void GetAssetId_InputsAreValid_ResultIsAsExpected(
        AssetType assetType,
        string quantum,
        string tokenAddress,
        string tokenId,
        string mintingBlob,
        string expectedAssetId)
    {
        // Arrange && Act
        var result = AssetEncoder.GetAssetId(
            assetType,
            quantum: new BigInteger(quantum),
            address: tokenAddress,
            tokenId: tokenId,
            mintingBlob: mintingBlob);

        // Assert
        result.Should().Be(expectedAssetId);
    }
}