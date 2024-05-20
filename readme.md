# WCharT.Net
[![Build Status](https://img.shields.io/github/actions/workflow/status/badcel/WCharT.Net/ci.yml?branch=main)](https://github.com/badcel/WCharT.Net/actions/workflows/ci.yml)[![NuGet](https://img.shields.io/nuget/v/WCharT.Net)](https://www.nuget.org/packages/WCharT.Net/)[![License (MIT)](https://img.shields.io/github/license/badcel/WCharT.Net)](https://github.com/badcel/WCharT.Net/blob/main/license.txt)

Welcome to WCharT.Net a modern cross platform package to interop with WCharT data.

## Use
To work with WCharT data create a new instance of `WCharTString`:

```csharp
//Read data from a byte*
byte* pointer = NativeCal();
var data = new WCharTString(pointer).GetString();

//Create a buffer for a native library and read the data after it was filled
ReadOnlySpan<byte> data = new WCharTString(int bufferCharSize);
NativeCall(data);
var str = data.GetString();

//Pass a string to a native library
ReadOnlySpan<byte> data = new WCharTString(string str);
NativeCall(data);
```

## Build
To build the solution locally execute the following commands:

```sh
$ git clone https://github.com/badcel/WCharT.Net.git
$ cd WCharT.Net/src
$ dotnet fsi build.fsx
```

## Native AOT
If the application targets at least .NET 8 the nuget package allows applications to be published as _Native AOT_ as itself is AOT compatible.

## Licensing terms
HidApi.Net is licensed under the terms of the MIT-License. Please see the [license file][license] for further information.

[license]:https://github.com/badcel/WCharT.Net/blob/main/license.txt