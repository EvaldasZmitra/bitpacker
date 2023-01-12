# BitPacker

[![Nuget](https://img.shields.io/nuget/v/ez-bitpacker)](https://www.nuget.org/packages/ez-bitpacker/)
[![Build](https://github.com/EvaldasZmitra/bitpacker/actions/workflows/ci.yml/badge.svg)](https://github.com/EvaldasZmitra/bitpacker/actions/workflows/ci.yml)
[![codecov](https://codecov.io/gh/EvaldasZmitra/bitpacker/branch/master/graph/badge.svg?token=8JK9DEC8Q0)](https://codecov.io/gh/EvaldasZmitra/bitpacker)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/fae76e9f072d4f50a1d1c46ca3a7c85c)](https://www.codacy.com/gh/EvaldasZmitra/bitpacker/dashboard?utm_source=github.com&utm_medium=referral&utm_content=EvaldasZmitra/bitpacker&utm_campaign=Badge_Grade)

This package is still in development. I made it for personal use, but thought it
would be nice to share, if anyone needs a bitpacker in C#. The performance
matters, so I tried to optimize it as best as possible. Should be ok for values
that occupy up to 63 bits, more than that could result in overflow.

Currently working on fixing bugs, improving code quality and coverage.

## Usage

```cs
var writer = new BitWriter();
/*
    Write integer 5, min values 0, max value 10. I did not include int/short/uint.
    They are covered by the range of long.

    The case for writing ulong is probably very rare.
*/
writer.WriteInteger(5, 0, 10);
/*
    Write integer 0.5, min values -1, max value 1. I did not include float, it is
    covered by double.

    Since range is 20, should use 5 bits. But will always round up to closest
    byte, so it will be 1byte.
*/
writer.WriteDecimal(0.5, -1, 1, 0.1)
var bytes = writer.ToBytes();

var reader = new BitReader();
// Has to be same as when writing
var number = (int)reader.ReadInteger(0, 10); // Downcast to byte/short/int if needed
// Has to be same as when writing
var numberFraction = (float)reader.ReadDecimal(); // Downcast to float if needed
```
