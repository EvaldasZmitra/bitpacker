namespace Serializers
{
	public static class BitCommon
	{
		public static int GetNumBits(float min, float max, float increment) => GetNumBits(
			(ulong)((max - min + 1) / increment)
		);
		public static int GetNumBits(double min, double max, double increment) => GetNumBits(
			(ulong)((max - min + 1) / increment)
		);
		public static int GetNumBits(int min, int max) => GetNumBits((ulong)(max - min));
		public static int GetNumBits(uint min, uint max) => GetNumBits(max - min);
		public static int GetNumBits(long min, long max) => GetNumBits((ulong)(max - min));
		public static int GetNumBits(ulong min, ulong max) => GetNumBits(max - min);
		public static int GetNumBits(ulong range)
		{
			if (range < 0b0000000000000000000000000000000000000000000000000000000000000010)
			{
				return 1;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000000000000100)
			{
				return 2;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000000000001000)
			{
				return 3;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000000000010000)
			{
				return 4;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000000000100000)
			{
				return 5;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000000001000000)
			{
				return 6;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000000010000000)
			{
				return 7;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000000100000000)
			{
				return 8;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000001000000000)
			{
				return 9;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000010000000000)
			{
				return 10;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000000100000000000)
			{
				return 11;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000001000000000000)
			{
				return 12;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000010000000000000)
			{
				return 13;
			}
			if (range < 0b0000000000000000000000000000000000000000000000000100000000000000)
			{
				return 14;
			}
			if (range < 0b0000000000000000000000000000000000000000000000001000000000000000)
			{
				return 15;
			}
			if (range < 0b0000000000000000000000000000000000000000000000010000000000000000)
			{
				return 16;
			}
			if (range < 0b0000000000000000000000000000000000000000000000100000000000000000)
			{
				return 17;
			}
			if (range < 0b0000000000000000000000000000000000000000000001000000000000000000)
			{
				return 18;
			}
			if (range < 0b0000000000000000000000000000000000000000000010000000000000000000)
			{
				return 19;
			}
			if (range < 0b0000000000000000000000000000000000000000000100000000000000000000)
			{
				return 20;
			}
			if (range < 0b0000000000000000000000000000000000000000001000000000000000000000)
			{
				return 21;
			}
			if (range < 0b0000000000000000000000000000000000000000010000000000000000000000)
			{
				return 22;
			}
			if (range < 0b0000000000000000000000000000000000000000100000000000000000000000)
			{
				return 23;
			}
			if (range < 0b0000000000000000000000000000000000000001000000000000000000000000)
			{
				return 24;
			}
			if (range < 0b0000000000000000000000000000000000000010000000000000000000000000)
			{
				return 25;
			}
			if (range < 0b0000000000000000000000000000000000000100000000000000000000000000)
			{
				return 26;
			}
			if (range < 0b0000000000000000000000000000000000001000000000000000000000000000)
			{
				return 27;
			}
			if (range < 0b0000000000000000000000000000000000010000000000000000000000000000)
			{
				return 28;
			}
			if (range < 0b0000000000000000000000000000000000100000000000000000000000000000)
			{
				return 29;
			}
			if (range < 0b0000000000000000000000000000000001000000000000000000000000000000)
			{
				return 30;
			}
			if (range < 0b0000000000000000000000000000000010000000000000000000000000000000)
			{
				return 31;
			}
			if (range < 0b0000000000000000000000000000000100000000000000000000000000000000)
			{
				return 32;
			}
			if (range < 0b0000000000000000000000000000001000000000000000000000000000000000)
			{
				return 33;
			}
			if (range < 0b0000000000000000000000000000010000000000000000000000000000000000)
			{
				return 34;
			}
			if (range < 0b0000000000000000000000000000100000000000000000000000000000000000)
			{
				return 35;
			}
			if (range < 0b0000000000000000000000000001000000000000000000000000000000000000)
			{
				return 36;
			}
			if (range < 0b0000000000000000000000000010000000000000000000000000000000000000)
			{
				return 37;
			}
			if (range < 0b0000000000000000000000000100000000000000000000000000000000000000)
			{
				return 38;
			}
			if (range < 0b0000000000000000000000001000000000000000000000000000000000000000)
			{
				return 39;
			}
			if (range < 0b0000000000000000000000010000000000000000000000000000000000000000)
			{
				return 40;
			}
			if (range < 0b0000000000000000000000100000000000000000000000000000000000000000)
			{
				return 41;
			}
			if (range < 0b0000000000000000000001000000000000000000000000000000000000000000)
			{
				return 42;
			}
			if (range < 0b0000000000000000000010000000000000000000000000000000000000000000)
			{
				return 43;
			}
			if (range < 0b0000000000000000000100000000000000000000000000000000000000000000)
			{
				return 44;
			}
			if (range < 0b0000000000000000001000000000000000000000000000000000000000000000)
			{
				return 45;
			}
			if (range < 0b0000000000000000010000000000000000000000000000000000000000000000)
			{
				return 46;
			}
			if (range < 0b0000000000000000100000000000000000000000000000000000000000000000)
			{
				return 47;
			}
			if (range < 0b0000000000000001000000000000000000000000000000000000000000000000)
			{
				return 48;
			}
			if (range < 0b0000000000000010000000000000000000000000000000000000000000000000)
			{
				return 49;
			}
			if (range < 0b0000000000000100000000000000000000000000000000000000000000000000)
			{
				return 50;
			}
			if (range < 0b0000000000001000000000000000000000000000000000000000000000000000)
			{
				return 51;
			}
			if (range < 0b0000000000010000000000000000000000000000000000000000000000000000)
			{
				return 52;
			}
			if (range < 0b0000000000100000000000000000000000000000000000000000000000000000)
			{
				return 53;
			}
			if (range < 0b0000000001000000000000000000000000000000000000000000000000000000)
			{
				return 54;
			}
			if (range < 0b0000000010000000000000000000000000000000000000000000000000000000)
			{
				return 55;
			}
			if (range < 0b0000000100000000000000000000000000000000000000000000000000000000)
			{
				return 56;
			}
			if (range < 0b0000001000000000000000000000000000000000000000000000000000000000)
			{
				return 57;
			}
			if (range < 0b0000010000000000000000000000000000000000000000000000000000000000)
			{
				return 58;
			}
			if (range < 0b0000100000000000000000000000000000000000000000000000000000000000)
			{
				return 59;
			}
			if (range < 0b0001000000000000000000000000000000000000000000000000000000000000)
			{
				return 60;
			}
			if (range < 0b0010000000000000000000000000000000000000000000000000000000000000)
			{
				return 61;
			}
			if (range < 0b0100000000000000000000000000000000000000000000000000000000000000)
			{
				return 62;
			}
			if (range < 0b1000000000000000000000000000000000000000000000000000000000000000)
			{
				return 63;
			}
			return 64;
		}

	}
}
