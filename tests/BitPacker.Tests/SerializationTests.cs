using FluentAssertions;
using Xunit;

namespace BitPacker.Tests;

public class UnitTest1
{
	[Fact]
	public void SerializeToArray()
	{
		var writer = new BitWriter();
		writer.WriteInteger(1, 0, 1);
		writer.WriteInteger(1, 0, 1);
		writer.WriteInteger(1, 0, 1);
		writer.WriteInteger(1, 0, 1);

		writer.WriteInteger(1, 0, 1);
		writer.WriteInteger(1, 0, 1);
		writer.WriteInteger(1, 0, 1);
		writer.WriteInteger(1, 0, 1);

		var arr = writer.ToBytes();

		arr.Should().BeEquivalentTo(new[] { 0b11111111 });
	}

	[Theory]
	[InlineData(10, 0, 100)]
	[InlineData(4900000000, 0, 5000000000)]
	public void ReadLong(long value, long min, long max)
	{
		var writer = new BitWriter();
		writer.WriteInteger(value, min, max);
		var arr = writer.ToBytes();
		var reader = new BitReader(arr);

		var actual = reader.ReadInteger(min, max);

		actual.Should().Be(value);
	}

	[Theory]
	[InlineData(10, 0, 7.35, 0.01)]
	public void ReadDouble(
		double value,
		double min,
		double max,
		double stepSize
	)
	{
		var writer = new BitWriter();
		writer.WriteDecimal(value, min, max, stepSize);
		var arr = writer.ToBytes();
		var reader = new BitReader(arr);

		var actual = reader.ReadDecimal(min, max, stepSize);

		actual.Should().Be(value);
	}
}
