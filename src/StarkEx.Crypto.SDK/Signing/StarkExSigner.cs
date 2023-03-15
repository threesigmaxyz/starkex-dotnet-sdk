namespace StarkEx.Crypto.SDK.Signing;

using System.Security.Cryptography;
using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using StarkEx.Commons.SDK.Models;
using StarkEx.Crypto.SDK.Utils;
using ECPoint = Org.BouncyCastle.Math.EC.ECPoint;

/// <summary>
/// An implementation of the <see cref="IStarkExSigner"/> interface that provides methods
/// for generating and verifying signatures on a STARK-friendly curve based on StarkWare's own implementation.
/// <para>
///     <a href="https://github.com/starkware-libs/starkware-crypto-utils/blob/dev/src/js/key_derivation.js" />
/// </para>
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
        // Convert hex string arguments to a BigInteger representation.
        var messageHashAsBigInteger = new BigInteger(messageHash.RemoveHexPrefix(), 16);
        var publicKeyAsBigInteger = new BigInteger(publicKey.RemoveHexPrefix(), 16);

        // Converts the public key to a STARK curve point.
        var publicKeyPoint = starkCurve.GetEcPoint(publicKeyAsBigInteger);

        // Validate signature for point Y.
        var resultA = VerifySignatureInternal(
            messageHash: messageHashAsBigInteger,
            publicKey: publicKeyPoint,
            signature: signature);

        // Validate signature for inverse point Y.
        var resultB = VerifySignatureInternal(
            messageHash: messageHashAsBigInteger,
            publicKey: starkCurve.CreatePoint(
                x: publicKeyPoint.XCoord.ToBigInteger(),
                y: publicKeyPoint.YCoord.ToBigInteger().Negate().Mod(StarkCurve.P)),
            signature: signature);

        return resultA || resultB;
    }

    /// <inheritdoc />
    public string GetPrivateStarkKeyFromEthSignature(SignatureModel ethSignature)
    {
        var r = ethSignature.R.RemoveHexPrefix();

        if (ethSignature.R.RemoveHexPrefix().Length != 64)
        {
            throw new ArgumentException("Invalid R in Eth signature");
        }

        return GrindKey(r, StarkCurve.GetCurveOrder());
    }

    /// <inheritdoc />
    public string GetPublicStarkKeyFromPrivateKey(string starkPrivateKey)
    {
        var privateKeyFixed = starkPrivateKey.RemoveHexPrefix();

        if (privateKeyFixed.Length > 63)
        {
            throw new ArgumentException("Invalid starkPrivateKey");
        }

        var starkAccount = starkCurve.GetStarkKeysFromPrivateStarkKey(new BigInteger(privateKeyFixed, 16));

        return starkAccount.PublicKey;
    }

    /// <inheritdoc />
    public StarkAccount GetStarkAccountFromEthSignature(SignatureModel ethSignature)
    {
        var privateKey = GetPrivateStarkKeyFromEthSignature(ethSignature);
        var publicKey = GetPublicStarkKeyFromPrivateKey(privateKey);

        return new StarkAccount
        {
            PublicKey = publicKey,
            PrivateKey = privateKey,
        };
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

    private static int CalculateByteLength(int length, int byteSize = 8)
    {
        var remainder = length % byteSize;
        return remainder > 0 ?
            (((length - remainder) / byteSize) * byteSize) + byteSize :
            length;
    }

    private static string GrindKey(string keySeed, BigInteger keyValLimit)
    {
        var sha256EcMaxDigest = new BigInteger("2").Pow(256);
        var maxAllowedVal = sha256EcMaxDigest.Subtract(sha256EcMaxDigest.Mod(keyValLimit));

        var i = 0;
        var key = HashKeyWithIndex(keySeed, i);
        i++;

        // Make sure the produced key is divided by the Stark EC order, and falls within the range
        // [0, maxAllowedVal).
        while (key.CompareTo(maxAllowedVal) != -1)
        {
            key = HashKeyWithIndex(keySeed, i);
            i++;
        }

        return key.Mod(keyValLimit).ToString(16);
    }

    private static BigInteger HashKeyWithIndex(string key, int index)
    {
        var sha256 = SHA256.Create();
        var hex = key.RemoveHexPrefix() + SanitizeBytes(index.ToString("X"), 2);
        var hexBuffer = hex.HexToByteArray();
        var hash = sha256.ComputeHash(hexBuffer);

        return new BigInteger(hash.ToHex(), 16);
    }

    private static string SanitizeBytes(string str, int byteSize = 8, char padding = '0')
    {
        return PadString(str, CalculateByteLength(str.Length, byteSize), true, padding);
    }

    private static string PadString(string str, int length, bool left, char padding = '0')
    {
        var diff = length - str.Length;
        var result = str;

        if (diff <= 0)
        {
            return result;
        }

        var pad = new string(padding, diff);
        result = left ? pad + str : str + pad;

        return result;
    }

    private bool VerifySignatureInternal(
        BigInteger messageHash,
        ECPoint publicKey,
        SignatureModel signature)
    {
        var signatureR = new BigInteger(signature.R.RemoveHexPrefix(), 16);
        var signatureS = new BigInteger(signature.S.RemoveHexPrefix(), 16);

        // Calculate w value.
        var (a, _, _) = MathUtils.Igcdex(signatureS, StarkCurve.GetCurveOrder());
        var w = BigInteger.One.Multiply(a).Mod(StarkCurve.GetCurveOrder());

        // Compute shift points.
        var shiftPoint = starkCurve.GetEcPoint(0);
        var minusShiftPoint = starkCurve.CreatePoint(
            x: shiftPoint.XCoord.ToBigInteger(),
            y: StarkCurve.P.Subtract(shiftPoint.YCoord.ToBigInteger()));

        // Signature validation.
        // DIFF: original formula is:
        // x = (w*msg_hash)*EC_GEN + (w*r)*public_key
        // While what we implement is:
        // x = w*(msg_hash*EC_GEN + r*public_key).
        // While both mathematically equivalent, one might error while the other doesn't,
        // given the current implementation.
        // This formula ensures that if the verification errors in our AIR, it errors here as well.
        var zG = MathUtils.MimicEcMultiplicationAir(messageHash, starkCurve.GetGenerator(), minusShiftPoint);
        var rQ = MathUtils.MimicEcMultiplicationAir(signatureR, publicKey, shiftPoint);
        var wB = MathUtils.MimicEcMultiplicationAir(w, zG.Add(rQ), shiftPoint);
        var x = wB.Add(minusShiftPoint);

        // Validate signature result.
        return signatureR.Equals(x.XCoord.ToBigInteger());
    }
}
