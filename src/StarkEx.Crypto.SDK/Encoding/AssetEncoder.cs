namespace StarkEx.Crypto.SDK.Encoding;

using System.Text;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Util;
using Org.BouncyCastle.Math;
using StarkEx.Crypto.SDK.Enums;
using StarkEx.Crypto.SDK.Guards;

// Based on https://docs.starkware.co/starkex-v4/starkex-deep-dive/starkex-specific-concepts#assetinfo-assettype-and-assetid
public static class AssetEncoder
{
    private const string EthSelector = "0x8322fff2";
    private const string Erc20Selector = "0xf47261b0";
    private const string Erc721Selector = "0x02571792";
    private const string Erc1155Selector = "0x3348691d";
    private const string MintableErc721Selector = "0xb8b86672";
    private const string MintableErc20Selector = "0x68646e2d";
    private static readonly BigInteger BitMask = new("03FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", 16);
    private static readonly BigInteger MintableAndBitMask = new("0000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", 16);
    private static readonly BigInteger MintableOrBitMask = new("400000000000000000000000000000000000000000000000000000000000000", 16);

    /// <summary>
    /// Gets the asset ID for the specified asset type.
    /// </summary>
    /// <param name="assetType">The type of the asset.</param>
    /// <param name="mintingBlob">The minting blob for mintable assets. This parameter should be specified
    /// only for <see cref="AssetType.MintableErc721"/> and <see cref="AssetType.MintableErc20"/> assets.</param>
    /// <param name="address">The address of the contract holding the asset. This parameter should be specified
    /// only for ERC-20, ERC-721, and ERC-1155 assets.</param>
    /// <param name="tokenId">The token ID of the ERC-721 or ERC-1155 asset. This parameter should be specified
    /// only for ERC-721 and ERC-1155 assets.</param>
    /// <param name="quantum">The quantum value for the asset. This parameter should be specified
    /// only for ETH and ERC-20 assets.</param>
    /// <returns>The asset ID for the specified asset type.</returns>
    public static string GetAssetId(
        AssetType assetType,
        string mintingBlob = null,
        string address = null,
        string tokenId = null,
        BigInteger quantum = null)
    {
        quantum ??= BigInteger.One;

        return assetType switch
        {
            AssetType.Eth => GetEthAssetId(quantum),
            AssetType.Erc20 => GetErc20AssetId(quantum, address),
            AssetType.Erc721 => GetErc721AssetId(tokenId, address),
            AssetType.Erc1155 => GetErc1155AssetId(tokenId, address),
            AssetType.MintableErc721 => GetMintableErc721AssetId(mintingBlob, address),
            AssetType.MintableErc20 => GetMintableErc20AssetId(mintingBlob, address, quantum),
            _ => throw new ArgumentOutOfRangeException(nameof(assetType), assetType, "Asset type isn't valid"),
        };
    }

    /// <summary>
    /// Gets the asset type for the specified parameters.
    /// </summary>
    /// <param name="assetType">The type of the asset.</param>
    /// <param name="quantum">The quantum value for the asset.</param>
    /// <param name="address">The address of the contract holding the asset. This parameter should
    /// be specified only for ERC-20, ERC-721, and ERC-1155 assets.</param>
    /// <returns>The asset type for the specified parameters.</returns>
    public static string GetAssetType(AssetType assetType, BigInteger quantum, string address = null)
    {
        Guards.NotNull(quantum);

        var assetInfo = GetAssetInfo(assetType, address);
        assetInfo = assetInfo
            .ShiftLeft(256)
            .Add(new BigInteger(quantum.ToString()));

        var keccackHash = Sha3Keccack.Current.CalculateHashFromHex(assetInfo.ToString(16));
        var keccackHashAsBigInteger = new BigInteger(keccackHash.RemoveHexPrefix(), 16);
        keccackHashAsBigInteger = keccackHashAsBigInteger.And(BitMask);

        return $"0x{keccackHashAsBigInteger.ToString(16)}";
    }

    /// <summary>
    /// Gets the asset info for the specified asset type and address.
    /// </summary>
    /// <param name="assetType">The type of the asset.</param>
    /// <param name="address">The address of the contract holding the asset. This parameter should
    /// be specified only for ERC-20, ERC-721, and ERC-1155 assets.</param>
    /// <returns>The asset info for the specified asset type and address.</returns>
    public static BigInteger GetAssetInfo(AssetType assetType, string address = null)
    {
        return assetType switch
        {
            AssetType.Eth => new BigInteger(EthSelector.RemoveHexPrefix(), 16),
            AssetType.Erc20 => GetErcAssetInfo(Erc20Selector, address),
            AssetType.Erc721 => GetErcAssetInfo(Erc721Selector, address),
            AssetType.Erc1155 => GetErcAssetInfo(Erc1155Selector, address),
            AssetType.MintableErc721 => GetErcAssetInfo(MintableErc721Selector, address),
            AssetType.MintableErc20 => GetErcAssetInfo(MintableErc20Selector, address),
            _ => throw new ArgumentOutOfRangeException(nameof(assetType), assetType, "AssetType isn't valid"),
        };
    }

    private static BigInteger GetErcAssetInfo(string selector, string address)
    {
        Guards.NotNullOrEmptyOrWhitespace(address);
        Guards.NotInvalidHex(address, nameof(address));

        return new BigInteger(selector.RemoveHexPrefix(), 16)
            .ShiftLeft(256)
            .Add(new BigInteger(address.RemoveHexPrefix(), 16));
    }

    private static string GetEthAssetId(BigInteger quantum)
    {
        Guards.NotNull(quantum);

        return GetAssetType(AssetType.Eth, quantum);
    }

    private static string GetErc20AssetId(BigInteger quantum, string address)
    {
        Guards.NotNull(quantum);
        Guards.NotNullOrEmptyOrWhitespace(address);
        Guards.NotInvalidHex(address, nameof(address));

        return GetAssetType(AssetType.Erc20, quantum, address);
    }

    private static string GetErc721AssetId(string tokenId, string address)
    {
        Guards.NotNullOrEmptyOrWhitespace(address);
        Guards.NotNullOrEmptyOrWhitespace(tokenId);
        Guards.NotInvalidHex(address, nameof(address));

        var assetType = GetAssetType(AssetType.Erc721, BigInteger.One, address);
        var assetId = new BigInteger(Encoding.ASCII.GetBytes("NFT:"));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(assetType.RemoveHexPrefix(), 16));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(tokenId.RemoveHexPrefix(), 16));

        var keccackHash = Sha3Keccack.Current.CalculateHashFromHex(assetId.ToString(16));
        var keccackHashAsBigInteger = new BigInteger(keccackHash.RemoveHexPrefix(), 16);
        keccackHashAsBigInteger = keccackHashAsBigInteger.And(BitMask);

        return $"0x{keccackHashAsBigInteger.ToString(16)}";
    }

    private static string GetErc1155AssetId(string tokenId, string address)
    {
        Guards.NotNullOrEmptyOrWhitespace(address);
        Guards.NotNullOrEmptyOrWhitespace(tokenId);
        Guards.NotInvalidHex(address, nameof(address));

        var assetType = GetAssetType(AssetType.Erc1155, BigInteger.One, address);
        var assetId = new BigInteger(Encoding.ASCII.GetBytes("NON_MINTABLE:"));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(assetType.RemoveHexPrefix(), 16));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(tokenId.RemoveHexPrefix(), 16));

        var keccackHash = Sha3Keccack.Current.CalculateHashFromHex(assetId.ToString(16));
        var keccackHashAsBigInteger = new BigInteger(keccackHash.RemoveHexPrefix(), 16);
        keccackHashAsBigInteger = keccackHashAsBigInteger.And(BitMask);

        return $"0x{keccackHashAsBigInteger.ToString(16)}";
    }

    private static string GetMintableErc721AssetId(string mintingBlob, string address)
    {
        Guards.NotNullOrEmptyOrWhitespace(address);
        Guards.NotNullOrEmptyOrWhitespace(mintingBlob);
        Guards.NotInvalidHex(address, nameof(address));

        var assetType = GetAssetType(AssetType.MintableErc721, BigInteger.One, address);
        var blobHash = Sha3Keccack.Current.CalculateHashFromHex(mintingBlob);
        var assetId = new BigInteger(Encoding.ASCII.GetBytes("MINTABLE:"));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(assetType.RemoveHexPrefix(), 16));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(blobHash.RemoveHexPrefix(), 16));

        var keccackHash = Sha3Keccack.Current.CalculateHashFromHex(assetId.ToString(16));
        var keccackHashAsBigInteger = new BigInteger(keccackHash.RemoveHexPrefix(), 16);
        keccackHashAsBigInteger = keccackHashAsBigInteger
            .And(MintableAndBitMask)
            .Or(MintableOrBitMask);

        return $"0x{keccackHashAsBigInteger.ToString(16)}";
    }

    private static string GetMintableErc20AssetId(string mintingBlob, string address, BigInteger quantum)
    {
        Guards.NotNull(quantum);
        Guards.NotNullOrEmptyOrWhitespace(address);
        Guards.NotInvalidHex(address, nameof(address));
        Guards.NotNullOrEmptyOrWhitespace(mintingBlob);
        Guards.NotInvalidHex(mintingBlob, nameof(mintingBlob));

        var assetType = GetAssetType(AssetType.MintableErc20, quantum, address);
        var blobHash = Sha3Keccack.Current.CalculateHashFromHex(mintingBlob);
        var assetId = new BigInteger(Encoding.ASCII.GetBytes("MINTABLE:"));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(assetType.RemoveHexPrefix(), 16));
        assetId = assetId.ShiftLeft(256).Add(new BigInteger(blobHash.RemoveHexPrefix(), 16));

        var keccackHash = Sha3Keccack.Current.CalculateHashFromHex(assetId.ToString(16));
        var keccackHashAsBigInteger = new BigInteger(keccackHash.RemoveHexPrefix(), 16);
        keccackHashAsBigInteger = keccackHashAsBigInteger
            .And(MintableAndBitMask)
            .Or(MintableOrBitMask);

        return $"0x{keccackHashAsBigInteger.ToString(16)}";
    }
}