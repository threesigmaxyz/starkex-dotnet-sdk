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
}