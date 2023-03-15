# StarkEX .NET SDK [![Github Actions][gha-badge]][gha] [![Docs][docs-badge]][docs] [![License: MIT][license-badge]][license]

[gha]: https://github.com/threesigmaxyz/starkex-dotnet-sdk/actions
[gha-badge]: https://github.com/threesigmaxyz/starkex-dotnet-sdk/actions/workflows/main.yml/badge.svg
[docs]: https://threesigmaxyz.github.io/starkex-dotnet-sdk/articles/intro.html
[docs-badge]: https://img.shields.io/badge/Docs-DocFx-orange
[license]: https://opensource.org/licenses/MIT
[license-badge]: https://img.shields.io/badge/License-MIT-blue.svg

## Introduction
The StarkEx .NET SDK project provides two separate SDKs for working with the StarkEx platform:

1. The `StarkEx.Client.SDK` is a .Net library that provides a client to interact with the StarkEx [Spot](https://starkware.co/starkex-restapi-v4/gateway.html) and [Perpetual](https://starkware.co/starkex-perpetual-api-v2/gateway.html) APIs.
   This SDK provides clients for making calls to the StarkEx API.

2. The `StarkEx.Crypto.SDK` is a .Net library that provides a set of cryptographic operations and utilities specifically designed for the StarkEx platform.
This library includes support for signatures, key generation and hashing on the STARK friendly elliptic curve, as well as utilities for working with StarkEx message encodings and asset identifiers.

Together, these two SDKs provide a comprehensive set of tools for working with the StarkEx platform using the .Net framework.

**Disclaimer:** The `StarkEx.Client.SDK` clients for the StarkEx Perpetual API have not yet been tested against a real implementation of the API.
In a future version they will be tested against the perpetual playground [API](https://perpetual-playground-v2.starkex.co).
As a result, these clients may not function as expected when used in a real-world setting.
We encourage contributions in this field.

## Libraries
| Source                                                                                                     | Package                                                                                                                                                | Description                                                                                                                                                                                                                    |
|------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [StarkEx.Client.SDK](https://github.com/threesigmaxyz/starkex-dotnet-sdk/tree/main/src/StarkEx.Client.SDK) | [v0.1.0](https://github.com/threesigmaxyz/starkex-dotnet-sdk/pkgs/nuget/StarkEx.Client.SDK) | The StarkEX Client SDK is a .Net library that provides a client to interact with the StarkEX [Spot](https://starkware.co/starkex-restapi-v4/gateway.html) and [Perpetual](https://starkware.co/starkex-perpetual-api-v2/gateway.html) APIs. |
| [StarkEx.Crypto.SDK](https://github.com/threesigmaxyz/starkex-dotnet-sdk/tree/main/src/StarkEx.Crypto.SDK) | [v0.1.0](https://github.com/threesigmaxyz/starkex-dotnet-sdk/pkgs/nuget/StarkEx.Crypto.SDK) | The StarkEX Crypto SDK is a .Net library for signatures, key generation and hashing on a STARK friendly elliptic curve.                                                                                                                     |

## Documentation
The documentation for the StarkEx SDKs has been generated using [DocFx](https://dotnet.github.io/docfx/).
You can consult the documentation page [here](https://threesigmaxyz.github.io/starkex-dotnet-sdk/articles/intro.html).
We encourage all users to read through the documentation to gain a better understanding of the SDKs and how to use them.
Additionally, we welcome any contributions to the documentation.

## Installation
You can install the publicly available nugget packages via:

```bash
dotnet add PROJECT package StarkEx.Crypto.SDK --version 0.1.0
dotnet add PROJECT package StarkEx.Client.SDK --version 0.1.0
```

## Testing
We provide a full testing suit for the SDKs that can be run via:

```bash
dotnet test tests/StarkEx.Crypto.SDK.Tests
dotnet test tests/StarkEx.Client.SDK.Tests
```

## Differential Testing
Additionaly, we provide a differential testing campaign for the `StarkEx.Crypto.SDK` against Starkware's reference [Python implementation](https://github.com/starkware-libs/starkex-resources/blob/master/crypto/starkware/crypto/signature/signature.py).

### Setup
Before running the tests you must install the following dependencies:
- [Python](https://www.python.org/)
- [Pip](https://pip.pypa.io/en/stable/)

Afterwards install the required Python libraries via:
```bash
pip install -r tests/StarkEx.Crypto.SDK.DifferentialTests/Python/requirements.txt
```

### Run
You can execute the differential tests using:
```bash
dotnet test tests/StarkEx.Crypto.SDK.DifferentialTests
```

## Contribute
We welcome and encourage contributions to the StarkEx .NET SDK project.
If you have found a bug or have an idea for a new feature, please open an issue in the project's issue tracker. This will allow the community to discuss and review your suggestion before any work is done.
If you are interested in contributing code to the project, we encourage you to fork the repository and submit a pull request with your changes.
We look forward to seeing your contributions and working with you to improve the project.

# About Us
[Three Sigma](https://threesigma.xyz/) is a venture builder firm focused on blockchain engineering, research, and investment. Our mission is to advance the adoption of blockchain technology and contribute towards the healthy development of the Web3 space.

If you are interested in joining our team, please contact us [here](mailto:info@threesigma.xyz).

---

<p align="center">
    <a href="https://threesigma.xyz" target="_blank">
        <img src="https://threesigma.xyz/_next/image?url=%2F_next%2Fstatic%2Fmedia%2Fthree-sigma-labs-research-capital-white.0f8e8f50.png&w=2048&q=75" width="75%" />
    </a>
</p>
