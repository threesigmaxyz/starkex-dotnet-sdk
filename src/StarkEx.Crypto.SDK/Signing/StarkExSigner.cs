namespace StarkEx.Crypto.SDK.Signing;

using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using StarkEx.Commons.SDK.Models;

/// <summary>
/// An implementation of the <see cref="IStarkExSigner"/> interface that provides methods
/// for generating and verifying signatures on a STARK-friendly curve.
/// </summary>
public class StarkExSigner : IStarkExSigner
{
    private readonly StarkCurve starkCurve;

    /// <summary>
    /// Initializes a new instance of the <see cref="StarkExSigner"/> class.
    /// </summary>
    /// <param name="starkCurve">The STARK curve used by this instance.</param>
    public StarkExSigner(StarkCurve starkCurve)
    {
        this.starkCurve = starkCurve;
    }

    /// <inheritdoc />
    public SignatureModel SignMessage(string messageHash, string privateKey)
    {
        var messageHashAsBigInteger = new BigInteger(messageHash.RemoveHexPrefix(), 16);
        var privateKeyAsBigInteger = new BigInteger(privateKey.RemoveHexPrefix(), 16);

        var hMacDsaKCalculator = new HMacDsaKCalculator(new Sha256Digest());
        var signer = new ECDsaSigner(hMacDsaKCalculator);
        signer.Init(true, starkCurve.CreatePrivateKeyParams(privateKeyAsBigInteger));
        var signature = signer.GenerateSignature(ToByteArray(FixMessageLength(messageHashAsBigInteger)));

        return new SignatureModel
        {
            R = signature[0].ToString(16),
            S = signature[1].ToString(16),
        };
    }

    /// <inheritdoc />
    public bool VerifySignature(string messageHash, string publicKey, SignatureModel signature)
    {
        var messageHashAsBigInteger = new BigInteger(messageHash.RemoveHexPrefix(), 16);
        var publicKeyAsBigInteger = new BigInteger(publicKey.RemoveHexPrefix(), 16);

        var signer = new ECDsaSigner();
        var publicKeyParameters = starkCurve.CreatePublicKeyParams(publicKeyAsBigInteger);
        signer.Init(false, publicKeyParameters);

        return signer.VerifySignature(
            ToByteArray(FixMessageLength(messageHashAsBigInteger)),
            new BigInteger(signature.R.RemoveHexPrefix(), 16),
            new BigInteger(signature.S.RemoveHexPrefix(), 16));
    }

    /// <summary>
    /// Converts a BigInteger value to a byte array.
    /// </summary>
    /// <param name="value">The BigInteger value to convert.</param>
    /// <returns>A byte array representation of the given input value.</returns>
    private static byte[] ToByteArray(BigInteger value)
    {
        var signedValue = value.ToByteArray();

        return signedValue[0] != 0x00 ? signedValue : Arrays.CopyOfRange(signedValue, 1, signedValue.Length);
    }

    /// <summary>
    /// Fixes the length of the given message hash by performing a shift-left operation if necessary.
    /// </summary>
    /// <param name="messageHash">The message hash to fix.</param>
    /// <returns>The fixed message hash.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the length of the message hash is not valid.
    /// </exception>
    private static BigInteger FixMessageLength(BigInteger messageHash)
    {
        var hashHex = messageHash.ToString(16);

        return hashHex.Length switch
        {
            <= 62 => messageHash,

            // In this case delta will be 4, so we perform a shift-left of 4 bits.
            63 => messageHash.ShiftLeft(4),
            _ => throw new ArgumentException($"Invalid message hash with length {hashHex.Length}", nameof(messageHash)),
        };
    }
}
