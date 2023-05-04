namespace StarkEx.Crypto.SDK.Tests.Hashing;

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Hashing;
using StarkEx.Crypto.SDK.Models;
using StarkEx.Crypto.SDK.Signing;
using Xunit;

[ExcludeFromCodeCoverage]
public class MessageHasherTests
{
    [Theory]
    [InlineData(
        "5fa3383597691ea9d827a79e1a4f0f7989c35ced18ca9619de8ab97e661020",
        "774961c824a3b0fb3d2965f01471c9c7734bf8dbde659e0c08dca2ef18d56a",
        "70bf591713d7cb7150523cf64add8d49fa6b61036bba9f596bd2af8e3bb86f9",
        "2154686749748910716",
        "1470242115489520459",
        "7",
        0,
        "593128169",
        "21",
        "27",
        1580230800,
        "2a6c0382404920ebd73c1cbc319cd38974e7e255e00394345e652b0ce2cefbd")]
    [InlineData(
        "774961c824a3b0fb3d2965f01471c9c7734bf8dbde659e0c08dca2ef18d56a",
        "5fa3383597691ea9d827a79e1a4f0f7989c35ced18ca9619de8ab97e661020",
        "70bf591713d7cb7150523cf64add8d49fa6b61036bba9f596bd2af8e3bb86f9",
        "14702421154895",
        "21546867497489",
        "7",
        1,
        "593128169",
        "221",
        "227",
        1688266800,
        "1924a457d5573e6ab300b73cda341fd73a19e5f4077d805a3cb33d28ca105ee")]
    public void EncodeLimitOrderWithFees_InputsAreValid_ResultIsAsExpected(
        string assetIdSold,
        string assetIdBought,
        string assetIdUsedForFees,
        string quantizedAmountSold,
        string quantizedAmountBought,
        string quantizedAmountUsedForFees,
        uint nonce,
        string vaultIdUsedForFees,
        string vaultIdUsedForSelling,
        string vaultIdUsedForBuying,
        int expirationTimestamp,
        string expectedHashHex)
    {
        // Arrange
        var target = CreateSpotTradingEncoder();
        var expectedResult = new BigInteger(expectedHashHex, 16);

        // Act
        var result = target.EncodeLimitOrderWithFees(new EncodeLimitOrderWithFeesModel(
            assetIdSold,
            assetIdBought,
            assetIdUsedForFees,
            new BigInteger(quantizedAmountSold),
            new BigInteger(quantizedAmountBought),
            new BigInteger(quantizedAmountUsedForFees),
            nonce,
            new BigInteger(vaultIdUsedForFees),
            new BigInteger(vaultIdUsedForSelling),
            new BigInteger(vaultIdUsedForBuying),
            expirationTimestamp));

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void EncodeTransferWithFees_InputsAreValid_ResultIsAsExpected()
    {
        // Arrange
        var target = CreateSpotTradingEncoder();
        var expectedResult = new BigInteger("5359c71cf08f394b7eb713532f1a0fcf1dccdf1836b10db2813e6ff6b6548db", 16);

        // Act
        var result = target.EncodeTransferWithFees(new EncodeTransferWithFeesModel(
            "3003a65651d3b9fb2eff934a4416db301afd112a8492aaf8d7297fc87dcd9f4",
            "70bf591713d7cb7150523cf64add8d49fa6b61036bba9f596bd2af8e3bb86f9",
            "5fa3383597691ea9d827a79e1a4f0f7949435ced18ca9619de8ab97e661020",
            new BigInteger("34"),
            new BigInteger("21"),
            new BigInteger("593128169"),
            1,
            new BigInteger("2154549703648910716"),
            new BigInteger("7"),
            1580230800));

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void EncodeConditionalTransferWithFees_InputsAreValid_ResultIsAsExpected()
    {
        // Arrange
        var target = CreateSpotTradingEncoder();
        var expectedResult = new BigInteger("3af0db074a735ebd2c1e5d38e60414d012c2736b935d62aa4fe9657fe7f1c35", 16);

        // Act
        var result = target.EncodeConditionalTransferWithFees(
            new EncodeTransferWithFeesModel(
                "3003a65651d3b9fb2eff934a4416db301afd112a8492aaf8d7297fc87dcd9f4",
                "70bf591713d7cb7150523cf64add8d49fa6b61036bba9f596bd2af8e3bb86f9",
                "5fa3383597691ea9d827a79e1a4f0f7949435ced18ca9619de8ab97e661020",
                new BigInteger("34"),
                new BigInteger("21"),
                new BigInteger("593128169"),
                1,
                new BigInteger("2154549703648910716"),
                new BigInteger("7"),
                1580230800),
            "318ff6d26cf3175c77668cd6434ab34d31e59f806a6a7c06d08215bccb7eaf8");

        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(
        "5fa3383597691ea9d827a79e1a4f0f7989c35ced18ca9619de8ab97e661020",
        "774961c824a3b0fb3d2965f01471c9c7734bf8dbde659e0c08dca2ef18d56a",
        "2154686749748910716",
        "1470242115489520459",
        0,
        "21",
        "27",
        438953 * 3600,
        "397e76d1667c4454bfb83514e120583af836f8e32a516765497823eabe16a3f")]
    [InlineData(
        "774961c824a3b0fb3d2965f01471c9c7734bf8dbde659e0c08dca2ef18d56a",
        "5fa3383597691ea9d827a79e1a4f0f7989c35ced18ca9619de8ab97e661020",
        "14702421154895", // These should be the inverse of the first dataset row
        "21546867497489",
        1,
        "221",
        "227",
        468963 * 3600,
        "6adb14408452ede28b89f40ca1847eca4de6a2dd6eb2c7d6dc5584f9399586")]
    public void DeprecatedHashLimitOrder_InputsAreValid_ResultIsAsExpected(
        string assetIdSold,
        string assetIdBought,
        string quantizedAmountSold,
        string quantizedAmountBought,
        uint nonce,
        string vaultIdUsedForSelling,
        string vaultIdUsedForBuying,
        int expirationTimestamp,
        string expectedHashHex)
    {
        // Arrange
        var target = CreateSpotTradingEncoder();
        var expectedResult = new BigInteger(expectedHashHex, 16);

        // Act
        var result = target.DeprecatedHashLimitOrder(
            assetIdSold,
            assetIdBought,
            new BigInteger(quantizedAmountSold),
            new BigInteger(quantizedAmountBought),
            nonce,
            new BigInteger(vaultIdUsedForSelling),
            new BigInteger(vaultIdUsedForBuying),
            expirationTimestamp);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void DeprecatedHashTransferOrder_InputsAreValid_ResultIsAsExpected()
    {
        // Arrange
        var target = CreateSpotTradingEncoder();
        var expectedResult = new BigInteger("6366b00c218fb4c8a8b142ca482145e8513c78e00faa0de76298ba14fc37ae7", 16);

        // Act
        var result = target.DeprecatedHashTransferOrder(
            "3003a65651d3b9fb2eff934a4416db301afd112a8492aaf8d7297fc87dcd9f4",
            "5fa3383597691ea9d827a79e1a4f0f7949435ced18ca9619de8ab97e661020",
            new BigInteger("2154549703648910716"),
            1,
            new BigInteger("21"),
            new BigInteger("34"),
            438953 * 3600);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void DeprecatedHashConditionalTransfer_InputsAreValid_ResultIsAsExpected()
    {
        // Arrange
        var target = CreateSpotTradingEncoder();
        var expectedResult = new BigInteger("fa5f0ad1ebff93c9e6474379a213ba1e1f9e42f5f1cb361b0327e073720384", 16);

        // Act
        var result = target.DeprecatedHashConditionalTransfer(
            "3003a65651d3b9fb2eff934a4416db301afd112a8492aaf8d7297fc87dcd9f4",
            "5fa3383597691ea9d827a79e1a4f0f7949435ced18ca9619de8ab97e661020",
            new BigInteger("2154549703648910716"),
            1,
            new BigInteger("21"),
            new BigInteger("34"),
            438953 * 3600,
            "318ff6d26cf3175c77668cd6434ab34d31e59f806a6a7c06d08215bccb7eaf8");

        // Assert
        result.Should().Be(expectedResult);
    }

    private static ISpotTradingMessageHasher CreateSpotTradingEncoder()
    {
        return new SpotTradingMessageHasher(new PedersenHash(new StarkCurve()));
    }
}
