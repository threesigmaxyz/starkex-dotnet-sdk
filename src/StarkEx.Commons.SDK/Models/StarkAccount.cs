namespace StarkEx.Commons.SDK.Models;

/// <summary>
///     Keys for a Stark Account.
/// </summary>
public class StarkAccount
{
    /// <summary>
    ///     Gets or sets the public key for the Stark Account.
    /// </summary>
    public string PublicKey { get; set; }
    
    /// <summary>
    ///     Gets or sets the private key for the Stark Account.
    /// </summary>
    public string PrivateKey { get; set; }
}