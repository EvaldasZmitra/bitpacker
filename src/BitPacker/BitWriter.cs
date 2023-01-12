using System;
using System.Collections.Generic;

namespace BitPacker
{
	public sealed class BitWriter
	{
		private ulong _scratch;
		private int _scratchBits;
		private readonly List<uint> _buffer = new List<uint>();

		public byte[] ToBytes()
		{
			if (_scratchBits > 0)
			{
				Flush();
			}
			var result = new byte[_buffer.Count * sizeof(uint)];
			Buffer.BlockCopy(_buffer.ToArray(), 0, result, 0, result.Length);
			return result;
		}

		public void WriteInteger(long value, long min, long max)
		{
			var numBits = BitCommon.GetNumBits((ulong)(max - min));
			Write((ulong)(value - min), numBits);
		}

		public void WriteDecimal(double value, double min, double max, double stepSize)
		{
			var numBitsRequired = BitCommon.GetNumBits((ulong)(Math.Ceiling(max - min) / stepSize));
			var unsignedValue = value - min;
			var quantizedValue = (ulong)(unsignedValue / stepSize);
			Write(quantizedValue, numBitsRequired);
		}

		private void Write(ulong value, int bitsRequired)
		{
			if (bitsRequired <= 32)
			{
				var int1 = (uint)(value & 0x00000000ffffffff);
				Write(int1, bitsRequired);
			}
			else
			{
				var int1 = value & 0x00000000ffffffff;
				Write(int1, 32);
				var int2 = (value & 0xffffffff00000000) >> 32;
				Write(int2, bitsRequired - 32);
			}
		}

		private void Write(uint value, int bitsRequired)
		{
			_scratch |= (ulong)value << _scratchBits;
			_scratchBits += bitsRequired;
			if (_scratchBits >= 32)
			{
				Flush();
			}
		}

		private void Flush()
		{
			_buffer.Add((uint)_scratch);
			_scratch = (_scratch & 0xffffffff00000000) >> 32;
			_scratchBits -= 32;
		}
	}
}
