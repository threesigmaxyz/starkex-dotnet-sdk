# StarkEX C# SDK

## What is StarkEX C# Crypto SDK?
StarkEX C# Crypto SDK is a .Net library for signatures, key generation and hashing on a STARK friendly elliptic curve.

## What is StarkEX C# Client SDK?
StarkEX C# SDK is the .Net integration library to interact with the StarkEX [Spot API](https://starkware.co/starkex-restapi-v4/gateway.html) and [Perpetual API](https://starkware.co/starkex-perpetual-api-v2/gateway.html).

## StarkEX Crypto SDK Features
This SDK provides the following cryptographic operations over the STARK curve described [here](https://docs.starkware.co/starkex-v4/crypto/stark-curve):
- ECDSA Signatures.
- Pederson Hashing.
- STARK key generation and derivation.

Additionally, it also contains utilities for the following StarkEx specific operations:
- StarkEx Spot/Perpetual [message encoding](https://docs.starkware.co/starkex-v4/starkex-deep-dive/message-encodings).
- Computation of StarkEx [asset identifiers](https://docs.starkware.co/starkex-v4/starkex-deep-dive/starkex-specific-concepts#assetinfo-assettype-and-assetid).

## StarkEX Client SDK Features

- StarkEx [Spot API](https://starkware.co/starkex-restapi-v4/gateway.html) client.
- StarkEx [Perpetual API](https://starkware.co/starkex-perpetual-api-v2/gateway.html) client.

## Installation
Currently the package is inside a private repository, so organization outsiders will not be able to install it.
After it has been made publicly available you can install it with the following command:

```bash
dotnet add PROJECT package StarkEx.Crypto.SDK --version 1.0.2
dotnet add PROJECT package StarkEx.Client.SDK --version 1.5.2
```

## Testing
We provide a full testing suit for the SDK that can be run via:

```bash
dotnet test StarkEx.Crypto.SDK.Tests
dotnet test StarkEx.Client.SDK.Tests
```

## StarkEX Crypto SDK Code samples
In this section we present some short examples illustrating how to utilize some core features of the crypto SDK. More examples are available in the `StarkEx.Crypto.SDK.Tests` package.

### ECDSA Signatures
Calculate signature:
```csharp
// initialize ECDSA signer
var signer = CreateStarkExSigner();

// compute signature
var signature = signer.SignMessage(
    messageHash: "0xc465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
    privateKey: "0x2dccce1da22003777062ee0870e9881b460a8b7eca276870f57c601f182136c");

// output R "0x5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2"
Console.Out.WriteLine(signature.R);
// output S "0x4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3"
Console.Out.WriteLine(signature.S);
```
Verify signature:
```csharp
// initialize ECDSA signer
var signer = CreateStarkExSigner();

// the signatue to verify
var signature = new SignatureModel{
    R = "0x5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2",
    S = "0x4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3",
};

// verify the signature
var verified = signer.VerifySignature(
    messageHash: "0xc465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
    publicKey: "0400499f65ae2f71d5298d2d88823b2e5e19596a71aac1984710479e406a00243904745865467631492cf6ecc433a3cf4ecc580d698097d6b738ad8f3da7c4d66c",
    signature: signature);
    
// output "true"
Console.Out.WriteLine(verified);
```

### Message Encoding
Compute the message encoding for a StarkEx TransferWithFees operation.
```csharp
// initialize message encoder
var encoder = CreateSpotTradingEncoder();

// encode TransferWithFees message
var encoded = target.EncodeTransferWithFees(
    assetIdSold: "0x3003a65651d3b9fb2eff934a4416db301afd112a8492aaf8d7297fc87dcd9f4",
    assetIdUsedForFees: "0x70bf591713d7cb7150523cf64add8d49fa6b61036bba9f596bd2af8e3bb86f9",
    receiverStarkKey: "0x5fa3383597691ea9d827a79e1a4f0f7949435ced18ca9619de8ab97e661020",
    vaultIdFromSender: 34,
    vaultIdFromReceiver: 21,
    vaultIdUsedForFees: 593128169,
    nonce: 1,
    quantizedAmountToTransfer: 2154549703648910716,
    quantizedAmountToLimitMaxFee: 7,
    expirationTimestamp: 1580230800);

// output "0x5359c71cf08f394b7eb713532f1a0fcf1dccdf1836b10db2813e6ff6b6548db"
Console.Out.WriteLine(encoded);
```

### AssetId Calculation
Calculate the assetId for as ERC1155 asset:
```csharp
// calculate assetId for ERC1155
var result = AssetEncoder.GetAssetId(
    assetType: AssetType.Erc1155,
    quantum: 1,
    address: "0x22c36BfdCef207F9c0CC941936eff94D4246d14A",
    tokenId: "1337");

// output "0x3bac60418017ad6c32f23980201722fbe672d9bd108765469484347b00afda"
Console.Out.WriteLine(encoded);
```
Calculate the assetId for a MintableERC20 asset with minting blob:
```csharp
// calculate assetId for MintableERC20
var result = AssetEncoder.GetAssetId(
    assetType: AssetType.MintableERC20,
    quantum: 1000000000,
    address: "0x5da41d8b03b656ac0daac9f27b98feba461dfbad",
    mintingBlob: "0xdeadbeef");

// output "0x400f163c4d559288a2edbb10162eed11f4de87c56875b970fee1534da69cc80"
Console.Out.WriteLine(encoded);
```

## StarkEX Client SDK Code samples

The code sample above describes the project Settings.

![](./src/images/settings.png)

You can inject the dependencies with the following code

```
services.AddStarkEx();
```