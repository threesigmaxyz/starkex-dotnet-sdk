namespace StarkEx.Crypto.SDK.Signing;

using StarkEx.Commons.SDK.Models;

/// <summary>
/// An interface for generating and verifying signatures on a STARK-friendly curve.
/// </summary>
public interface IStarkExSigner
{
    /// <summary>
    ///     Signs a StarkEx message.
    /// </summary>
    /// <param name="messageHash">Hash encoding of a StarkEx message.</param>
    /// <param name="privateKey">Private key used to sign the message hash.</param>
    /// <returns>
    ///     Signature Model with ECDSA coords.
    /// </returns>
    SignatureModel SignMessage(string messageHash, string privateKey);

    /// <summary>
    ///     Verifies a STARK signature.
    /// </summary>
    /// <param name="messageHash">Hash encoding of a StarkEx message.</param>
    /// <param name="publicKey">Public key derived from the private key used to sign the messageHash.</param>
    /// <param name="signature">Signature of the message.</param>
    /// <returns>
    ///     Signature Model with ECDSA coords.
    /// </returns>
    bool VerifySignature(string messageHash, string publicKey, SignatureModel signature);

    /// <summary>
    ///     Generates a private Stark Key from an Ethereum signature
    /// </summary>
    /// <param name="ethSignature">Computed signature from an Ethereum account.</param>
    /// <returns>
    ///     Private Stark key
    /// </returns>
    string GetPrivateStarkKeyFromEthSignature(SignatureModel ethSignature);

    /// <summary>
    ///     Generates a public Stark Key from a private Stark Key
    /// </summary>
    /// <param name="starkPrivateKey">Private Stark Key.</param>
    /// <returns>
    ///     Public Stark key
    /// </returns>
    string GetPublicStarkKeyFromPrivateKey(string starkPrivateKey);

    /// <summary>
    ///     Generates a Stark Account from an Ethereum signature
    /// </summary>
    /// <param name="ethSignature">Computed signature from an Ethereum account.</param>
    /// <returns>
    ///     Stark Account
    /// </returns>
    StarkAccount GetStarkAccountFromEthSignature(SignatureModel ethSignature);
}
