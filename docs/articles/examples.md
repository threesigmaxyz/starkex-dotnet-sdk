## API Client SDK
In this section we present some short examples illustrating how to utilize some core features of the `StarkEx.Client.SDK` library.
More examples are available in the `StarkEx.Client.SDK.Tests` package.

#### Connect to the StarkEx Spot Gateway API:
```csharp
var settings = new StarkExApiSettings
{
    BaseAddress = new Uri("https://gw.playground-v2.starkex.co"),
    Version = "v2",
};

var spotGatewayClient = new SpotGatewayClient(httpClientFactory, settings)
```

#### Get the StarkEx contract address:
```csharp
// returns "0x5731aEa1809BE0454907423083fb879079FB69dF"
spotGatewayClient.GetStarkDexAddress(CancellationToken.None)
```

#### Submit deposit transaction:
```csharp
var depositRequestModel = new DepositRequestModel
{
    TransactionId = 1234,
    Transaction = new DepositModel
    {
        Amount = 4029557120079369747,
        StarkKey = "0x7c65c1e82e2e662f728b4fa42485e3a0a5d2f346baa9455e3e70682c2094cac",
        TokenId = "0x2dd48fd7a024204f7c1bd874da5e709d4713d60c8a70639eb1167b367a9c378",
        VaultId = 1654615998,
    },
};

// returns {"code": "TRANSACTION_PENDING"}
var response = await spotGatewayClient.AddTransactionAsync(depositRequestModel, CancellationToken.None);

// returns SpotApiCodes.TransactionPending
response.Code
```

## Crypto SDK
In this section we present some short examples illustrating how to utilize some core features of the `StarkEx.Crypto.SDK` library.
More examples are available in the `StarkEx.Crypto.SDK.Tests` package.

#### Calculate STARK signature:
```csharp
// initialize ECDSA signer
var signer = new StarkExSigner(new StarkCurve())

// compute signature
var signature = signer.SignMessage(
    messageHash: "0xc465dd6b1bbffdb05442eb17f5ca38ad1aa78a6f56bf4415bdee219114a47",
    privateKey: "2dccce1da22003777062ee0870e9881b460a8b7eca276870f57c601f182136c");

// output R "0x5f496f6f210b5810b2711c74c15c05244dad43d18ecbbdbe6ed55584bc3b0a2"
Console.Out.WriteLine(signature.R);
// output S "0x4e8657b153787f741a67c0666bad6426c3741b478c8eaa3155196fc571416f3"
Console.Out.WriteLine(signature.S);
```
#### Verify STARK signature:
```csharp
// initialize ECDSA signer
var signer = new StarkExSigner(new StarkCurve())

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

#### Compute the message encoding for a StarkEx transfer with fees:
```csharp
// initialize message encoder
var encoder = new SpotTradingMessageHasher(new PedersenHash(new StarkCurve()))

// encode TransferWithFees message
var encoded = encoder.EncodeTransferWithFees(
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

#### Calculate the assetId for as ERC-1155 asset:
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
#### Calculate the assetId for a mintable ERC-20 asset:
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