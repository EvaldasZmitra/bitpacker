using System;
using System.Collections.Generic;

namespace Serializers
{
	public sealed class BitWriter
	{
		private ulong _scratch;
		private int _scratchBits;
		private readonly List<uint> _buffer = new List<uint>();

		public void Write(byte[] bytes)
		{
			for (var i = 0; i < bytes.Length; i++)
			{
				Write(bytes[i]);
			}
		}

		public void Write(long value, long min, long max)
		{
			var numBits = BitCommon.GetNumBits((ulong)(max - min));
			Write((ulong)(value - min), numBits);
		}

		public void Write(ulong value, ulong min, ulong max)
		{
			var numBits = BitCommon.GetNumBits(max - min);
			Write(value, numBits);
		}

		public void Write(double value, double min, double max, double stepSize)
		{
			var numBitsRequired = BitCommon.GetNumBits((ulong)(Math.Ceiling(max - min) / stepSize));
			var unsignedValue = value - min;
			var quantizedValue = (ulong)(unsignedValue / stepSize);
			Write(quantizedValue, numBitsRequired);
		}

		public void Write(float value, float min, float max, float stepSize)
		{
			var numBitsRequired = BitCommon.GetNumBits((ulong)(Math.Ceiling(max - min) / stepSize));
			var unsignedValue = value - min;
			var quantizedValue = (ulong)(unsignedValue / stepSize);
			Write(quantizedValue, numBitsRequired);
		}

		public void Write(uint value, uint min, uint max)
		{
			var numBitsRequired = GetNumBits(min, max);
			var unsignedValue = value - min;
			Write(unsignedValue, numBitsRequired);
		}

		public void Write(int value, int min, int max)
		{
			var numBitsRequired = GetNumBits(min, max);
			var unsignedValue = (ulong)((long)value - min);
			Write(unsignedValue, numBitsRequired);
		}

		public void Write(ulong value, int bitsRequired)
		{
			if (bitsRequired <= 32)
			{
				var int1 = (uint)(value & 0x00000000ffffffff);
				Write(int1, bitsRequired);
			}
			else
			{
				var int1 = (uint)(value & 0x00000000ffffffff);
				Write(int1, bitsRequired);
				var int2 = (uint)(value & 0xffffffff00000000);
				Write(int2, bitsRequired - 32);
			}
		}

		public void Write(uint value, int bitsRequired)
		{
			_scratch |= ((ulong)value) << _scratchBits;
			_scratchBits += bitsRequired;
			if (_scratchBits >= 32)
			{
				Flush();
			}
		}

		public void Write(byte value)
		{
			_scratch |= ((ulong)value) << _scratchBits;
			_scratchBits += 8;
			if (_scratchBits >= 32)
			{
				Flush();
			}
		}

		public void Write(bool value) => Write(value ? 1u : 0u, 1);

		public byte[] Finalize()
		{
			if (_scratchBits > 0)
			{
				Flush();
			}
			var result = new byte[_buffer.Count * sizeof(uint)];
			Buffer.BlockCopy(_buffer.ToArray(), 0, result, 0, result.Length);
			return result;
		}

		private void Flush()
		{
			_buffer.Add((uint)_scratch);
			_scratch = (_scratch & 0xffffffff00000000) >> 32;
			_scratchBits -= 32;
		}

		private static int GetNumBits(long min, long max)
		{
			var range = (ulong)(max - min);
			return BitCommon.GetNumBits(range);
		}
	}
}
