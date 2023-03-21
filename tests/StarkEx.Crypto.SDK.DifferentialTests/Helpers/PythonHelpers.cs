namespace StarkEx.Crypto.SDK.DifferentialTests.Helpers;

using System.Diagnostics;
using System.Text;
using Nethereum.Hex.HexConvertors.Extensions;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using StarkEx.Commons.SDK.Models;
using StarkEx.Crypto.SDK.Signing;

public static class PythonHelpers
{
    private const string PythonExecutable = "python";
    private const string Filepath = "Python/signature.py";

    public static BigInteger Hash(BigInteger leftField, BigInteger rightField)
    {
        var process = CreatePythonProcess("hash", leftField, rightField);

        using var reader = process!.StandardOutput;
        var result = reader.ReadToEnd().TrimEnd('\n');

        return new BigInteger(result);
    }

    public static SignatureModel Sign(string messageHash, string privateKey)
    {
        using var process = CreatePythonProcess("sign", messageHash, privateKey);

        using var reader = process!.StandardOutput;
        var controlResult = reader.ReadToEnd().TrimEnd('\n').Split('\n');

        return new SignatureModel
        {
            R = controlResult[0],
            S = controlResult[1],
        };
    }

    public static bool Verify(string messageHash, SignatureModel signature, string publicKey)
    {
        using var process = CreatePythonProcess(
                "verify",
                messageHash,
                signature.R,
                signature.S,
                publicKey);

        using var reader = process!.StandardOutput;
        var controlResult = reader.ReadToEnd().TrimEnd('\n');

        return controlResult.Equals("True");
    }

    public static ECPoint MimicEcMultiplicationAir(
        BigInteger value,
        ECPoint point,
        ECPoint shiftPoint)
    {
        using var process = CreatePythonProcess(
            "air-multiply",
            value,
            point.XCoord,
            point.YCoord,
            shiftPoint.XCoord,
            shiftPoint.YCoord);

        using var reader = process!.StandardOutput;
        var controlResult = reader.ReadToEnd().TrimEnd('\n').Split('\n');

        return new StarkCurve().CreatePoint(
            new BigInteger(controlResult[0].RemoveHexPrefix(), 16),
            new BigInteger(controlResult[1].RemoveHexPrefix(), 16));
    }

    private static Process? CreatePythonProcess(string command, params object[] args)
    {
        return Process.Start(new ProcessStartInfo
        {
            FileName = PythonExecutable,
            Arguments = args.Aggregate(
                new StringBuilder($"{Filepath} {command}"),
                (sb, arg) => sb.Append(' ').Append(arg)).ToString(),
            UseShellExecute = false,
            RedirectStandardOutput = true,
        });
    }
}
