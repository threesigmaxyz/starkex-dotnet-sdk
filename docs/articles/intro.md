# StarkEX .NET SDK

The StarkEx .NET SDK project provides two separate SDKs for working with the StarkEx platform:

1. The `StarkEx.Client.SDK` is an integration library for interacting with the StarkEx [Spot](https://starkware.co/starkex-restapi-v4/gateway.html) and [Perpetual](https://starkware.co/starkex-perpetual-api-v2/gateway.html) APIs.
   This SDK provides clients for making calls to the StarkEx API.

2. The `StarkEx.Crypto.SDK` is a .Net library that provides a set of cryptographic operations and utilities specifically designed for the StarkEx platform.
   This library includes support for signatures, key generation and hashing on the STARK friendly elliptic curve, as well as utilities for working with StarkEx message encodings and asset identifiers.

Together, these two SDKs provide a comprehensive set of tools for working with the StarkEx platform using the .Net framework.

**Disclaimer:** The `StarkEx.Client.SDK` clients for the StarkEx Perpetual API have not yet been tested against a real implementation of the API.
In a future version they will be tested again the perpetual playground [API](https://perpetual-playground-v2.starkex.co).
As a result, these clients may not function as expected when used in a real-world setting.
We encourage contributions in this field.

## Libraries
| Source                                                                                                     | Package                                                                                                          | Description                                                                                                                                                                                                                    |
|------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [StarkEx.Client.SDK](https://github.com/threesigmaxyz/starkex-dotnet-sdk/tree/main/src/StarkEx.Client.SDK) | [![NuGet version](https://badge.fury.io/nu/starkex.client.sdk.svg)](https://github.com/threesigmaxyz/starkex-dotnet-sdk/pkgs/nuget/StarkEx.Client.SDK) | The StarkEX Client SDK is a .Net provides a client to interact with the StarkEX [Spot](https://starkware.co/starkex-restapi-v4/gateway.html) and [Perpetual](https://starkware.co/starkex-perpetual-api-v2/gateway.html) APIs. |
| [StarkEx.Crypto.SDK](https://github.com/threesigmaxyz/starkex-dotnet-sdk/tree/main/src/StarkEx.Crypto.SDK) | [![NuGet version](https://badge.fury.io/nu/starkex.crypto.sdk.svg)](https://github.com/threesigmaxyz/starkex-dotnet-sdk/pkgs/nuget/StarkEx.Crypto.SDK) | The StarkEX Crypto SDK is a .Net library for signatures, key generation and hashing on a STARK friendly elliptic curve.                                                                                                        |

## About Us
[Three Sigma](https://threesigma.xyz/) is a venture builder firm focused on blockchain engineering, research, and investment. Our mission is to advance the adoption of blockchain technology and contribute towards the healthy development of the Web3 space.

If you are interested in joining our team, please contact us [here](mailto:info@threesigma.xyz).

---

<p align="center">
  <img src="https://threesigma.xyz/_next/image?url=%2F_next%2Fstatic%2Fmedia%2Fthree-sigma-labs-research-capital-white.0f8e8f50.png&w=2048&q=75" width="50%" />
</p>