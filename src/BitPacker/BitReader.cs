using System;

namespace Serializers
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

		public ulong ReadULong(ulong min, ulong max) => ReadULong(BitCommon.GetNumBits(min, max)) + min;

		public uint ReadUInt(uint min, uint max) => ReadUint(BitCommon.GetNumBits(min, max)) + min;

		public double ReadDouble(double min, double max, double stepSize) => (ReadULong(BitCommon.GetNumBits(min, max, stepSize)) * stepSize) + min;

		public float ReadFloat(float min, float max, float stepSize) => (ReadULong(BitCommon.GetNumBits(min, max, stepSize)) * stepSize) + min;

		public long ReadLong(long min, long max) => (long)ReadULong(BitCommon.GetNumBits(min, max)) + min;

		public int ReadInt(int min, int max) => (int)((long)ReadUint(BitCommon.GetNumBits(min, max)) + min);

		public byte[] ReadByteArray(int size)
		{
			var value = new byte[size];
			for (var i = 0; i < size; i++)
			{
				value[i] = ReadByte();
			}
			return value;
		}

		public byte ReadByte()
		{
			var value = (byte)(_scratch & GetMask(8));
			Flush(8);
			return value;
		}

		public ulong ReadULong(int bits)
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

		public uint ReadUint(int bits)
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
			_scratch |= (ulong)_buffer[_bufferIndex] << _scratch_bits;
			_bufferIndex++;
			_scratch_bits += 32;
		}

		private static ulong GetMask(int numBits) => (uint)(((ulong)1 << numBits) - 1);
	}
}
