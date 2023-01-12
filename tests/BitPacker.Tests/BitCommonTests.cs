using FluentAssertions;
using Xunit;

namespace BitPacker.Tests;

public class BitCommonTests
{
	[Fact]
	public void GetNumBitsInteger()
	{
		for (var i = 1; i <= 64; i++)
		{
			BitCommon.GetNumBits(
				(ulong)Math.Pow(2, i) - 1
			).
			Should()
			.Be(i);
		}
	}

	[Theory]
	[InlineData(0, 8, 1, 4)]
	public void GetNumBitsDouble(
		double min,
		double max,
		double increment,
		int expected
	)
	{
		BitCommon.GetNumBits(min, max, increment).Should().Be(expected);
	}
}
