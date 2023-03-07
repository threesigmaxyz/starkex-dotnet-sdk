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
        "0200499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a002439",
        "5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
        "4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3")]
    [InlineData(
        "c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
        "00499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a002439",
        "5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
        "4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3")]
    [InlineData(
        "c465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
        "499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a002439",
        "5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
        "4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3")]
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

    [Theory]
    [InlineData(
        "21fbf0696d5e0aa2ef41a2b4ffb623bcaf070461d61cf7251c74161f82fec3a4370854bc0a34b3ab487c1bc021cd318c734c51ae29374f2beb0e6f2dd49b4bf41c",
        "766f11e90cd7c7b43085b56da35c781f8c067ac0d578eabdceebc4886435bda")]
    public void GetPrivateStarkKeyFromEthSignature_InputsAreValid_PrivateStarkKeyMatches(
        string fullEthSignature,
        string privateStarkKey)
    {
        // Arrange
        var ethSignature = new SignatureModel
        {
            R = fullEthSignature[..64],
            S = fullEthSignature.Substring(64, 64),
        };

        var target = CreateStarkExSigner();

        // Act
        var result = target.GetPrivateStarkKeyFromEthSignature(ethSignature);

        // Assert
        result.Should().Be(privateStarkKey);
    }

    [Theory]
    [InlineData("0x1", "0x1ef15c18599971b7beced415a40f0c7deacfd9b0d1819e03d723d8bc943cfca")]
    [InlineData("0x2", "0x759ca09377679ecd535a81e83039658bf40959283187c654c5416f439403cf5")]
    [InlineData("0x3", "0x411494b501a98abd8262b0da1351e17899a0c4ef23dd2f96fec5ba847310b20")]
    [InlineData("0x4", "0xa7da05a4d664859ccd6e567b935cdfbfe3018c7771cb980892ef38878ae9bc")]
    [InlineData("0x5", "0x788435d61046d3eec54d77d25bd194525f4fa26ebe6575536bc6f656656b74c")]
    [InlineData("0x6", "0x1efc3d7c9649900fcbd03f578a8248d095bc4b6a13b3c25f9886ef971ff96fa")]
    [InlineData("0x7", "0x743829e0a179f8afe223fc8112dfc8d024ab6b235fd42283c4f5970259ce7b7")]
    [InlineData("0x8", "0x6eeee2b0c71d681692559735e08a2c3ba04e7347c0c18d4d49b83bb89771591")]
    [InlineData("0x9", "0x216b4f076ff47e03a05032d1c6ee17933d8de8b2b4c43eb5ad5a7e1b25d3849")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000000", "0x5c79074e7f7b834c12c81a9bb0d46691a5e7517767a849d9d98cb84e2176ed2")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000001", "0x1c4f24e3bd16db0e2457bc005a9d61965105a535554c6b338871e34cb8e2d3a")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000002", "0xdfbb89b39288a9ddacf3942b4481b04d4fa2f8ed3c424757981cc6357f27ac")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000003", "0x41bef28265fd750b102f4f2d1e0231de7f4a33900a214f191a63d4fec4e72f4")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000004", "0x24de66eb164797d4b414e81ded0cfa1a592ef0a9363ebbcb440d4d03cb18af1")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000005", "0x5efb18c3bc9b69003746acc85fb6ee0cfbdc6adfb982f089cc63e1e5495daad")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000006", "0x10dc71f00918a8ebfe4085c834d41dd22b251b9f81eef8b9a4fab77e7e1afe9")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000007", "0x4267ebfd379b1c8caae73febc5920b0c95bd6f9f3536f47c5ddad1259c332ff")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000008", "0x6da515118c8e01fd5b2e96b814ee95bad7d60be4d2ba6b47e0d283f579d9671")]
    [InlineData("0x800000000000000000000000000000000000000000000000000000000000009", "0x7a5b4797f4e56ed1473876bc2693fbe3f2fef7e050717cbae924ff23d426052")]
    [InlineData("0x2e9c99d8382fa004dcbbee720aef8a97002de0e991f6a8344e6dc636a71b59e", "0x1ff6803ae740e7e596504ac5c6afbea472e53679361e214f12be0155b13e25d")]
    [InlineData("0x8620458785138df8722214e073a91b8f55076ea78197cf41007692dd27fd90", "0x5967da40b90d7ca1e36dc4024381d7d4b403c6ac1a0ab358b0743984934a805")]
    [InlineData("0x1b920e7dfb49ba5ada673882af5342e7448d3e9335e0ac37feb6280cd7289ce", "0x78c7ab46333968fbde3201cf512c1eeb5529360259072c459a158dee4449b57")]
    [InlineData("0x704170dbfd5dc63caef69d2ce6dfc2b2dbb2af6e75851242bbe79fb6e62a118", "0x534bd8d6ebe4bb2f6992e2d7c19ef3146247e10c2849f357e44eddd283b2af6")]
    [InlineData("0x4b58bf4228f39550eca59b5c96a0cb606036cc9495eef9a546f24f01b1b7829", "0x1097a8c5a46d94596f1c8e70ca66941f2bb11e3c8d4fd58fdc4589f09965be8")]
    [InlineData("0x2e93226c90fb7a2381a24e940a94b98433e3553dcbf745d3f54d62963c75604", "0x369f0e8c8e984f244290267393a004dba435a4df091767ad5063fece7b1884c")]
    [InlineData("0x4615f94598cd756ad1a551d7e57fd725916adfd0054eb773ceb482eef87d0b2", "0x1ee5b8d612102a2408cde59ce52a6498d2e38fe8789bb26d400dea310684ec9")]
    [InlineData("0x6ade54b7debd7ca1d4e8e932f9545f8fa4024d73be1efcc86df86367fc333f8", "0x37de3bf52412b2fb9b0030d232ca9dd921cd8f71fd67975cdc62546826e121")]
    [InlineData("0x618e7467dd24c2a3449c4df640439c12cdd0f8ea779afcee6e252b2cf494354", "0x71c2b578c432f2d305d3808bb645ecc46dd670cb43d4f4a076f75ccbff74fbc")]
    [InlineData("0x7eae185e1f41ec76d214d763f0592f194933622a9dd5f3d52d0209f71619c1a", "0x2b0160052e70176e5b0ff2a6eff90896ae07b732fc27219e36e077735abd57e")]
    [InlineData("0x178047D3869489C055D7EA54C014FFB834A069C9595186ABE04EA4D1223A03F", "0x1895a6a77ae14e7987b9cb51329a5adfb17bd8e7c638f92d6892d76e51cebcf")]
    public void GetPublicStarkKeyFromPrivateKey_InputsAreValid_PublicStarkKeyMatches(
        string privateStarkKey,
        string expectedPublicStarkKey)
    {
        // Arrange
        var target = CreateStarkExSigner();

        // Act
        var result = target.GetPublicStarkKeyFromPrivateKey(privateStarkKey);

        // Assert
        result.Should().Be(expectedPublicStarkKey);
    }

    private static IStarkExSigner CreateStarkExSigner()
    {
        return new StarkExSigner(new StarkCurve());
    }
}
