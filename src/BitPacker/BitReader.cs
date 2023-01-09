using System;

namespace BitPacker
{
	public sealed class BitReader
	{
		private ulong _scratch;
		private int _scratch_bits;
		private readonly uint[] _buffer;
		private int _bufferIndex;

		public BitReader(byte[] buffer)
		{
			_buffer = new uint[(int)Math.Ceiling((float)buffer.Length / sizeof(int))];
			Buffer.BlockCopy(buffer, 0, _buffer, 0, buffer.Length);
			Flush();
		}

		public double ReadDecimal(double min, double max, double stepSize) => (ReadULong(BitCommon.GetNumBits(min, max, stepSize)) * stepSize) + min;

		public long ReadInteger(long min, long max) => (long)ReadULong(BitCommon.GetNumBits(min, max)) + min;

		private ulong ReadULong(int bits)
		{
			if (bits <= 32)
			{
				return ReadUint(bits);
			}
			else
			{
				var num1 = (ulong)ReadUint(32);
				var num2 = (ulong)ReadUint(bits - 32) << 32;
				var value = num1 & 0x00000000ffffffff;
				value &= num2 & 0xffffffff00000000;
				return value;
			}
		}

		private uint ReadUint(int bits)
		{
			var value = (uint)(_scratch & GetMask(bits));
			Flush(bits);
			return value;
		}

		private void Flush(int bits)
		{
			_scratch >>= bits;
			_scratch_bits -= bits;
			if (_scratch_bits < 32)
			{
				Flush();
			}
		}

		private void Flush()
		{
			if (_bufferIndex < _buffer.Length)
			{
				_scratch |= (ulong)_buffer[_bufferIndex] << _scratch_bits;
				_bufferIndex++;
				_scratch_bits += 32;
			}
		}

		private static ulong GetMask(int numBits) => (uint)(((ulong)1 << numBits) - 1);
	}
}
