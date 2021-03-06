using System;

namespace POSL_Test
{
	public static class ConfigurationProvider
	{
		public static int[] Golfers_332_c6
		{
			get {
				return new int[]
				{
					1, 2, 3,
					4, 5, 6,
					7, 8, 9,

					3, 4, 5,
					6, 7, 8,
					9, 1, 2
				};
			}
		}

		public static int[] Golfers_333_c
		{
			get {
				return new int[] {
					1, 2, 3,
					4, 5, 6,
					7, 8, 9,

					3, 4, 5,
					6, 7, 8,
					9, 1, 2,

					1, 4, 7,
					2, 5, 8,
					3, 6, 9,
				};
			}
		}

		public static int[] Golfers_442_c0
		{
			get {
				return new int[]
				{
					1,  2,   3,  4,
					5,  6,   7,  8,
					9,  10, 11, 12,
					13, 14, 15, 16,

					13, 10,  7,  4,
					14, 11,  8,  1,
					15, 12,  2,  5,
					16,  3,  6,  9
				};
			}
		}

		public static int[] Golfers_442_c14
		{
			get {
				return new int[]
				{
					1,  2,   3,  4,
					5,  6,   7,  8,
					9,  10, 11, 12,
					13, 14, 15, 16,

					1,  5,   7,  9,
					2, 11,  10,  13,
					15, 12,  16,  14,
					4,  3,   6,  8
				};
			}
		}

		public static int[] Golfers_442_repeted
		{
			get {
				return new int[] {
					1, 2, 3, 4,
					5, 6, 7, 8,
					9, 10, 11, 12,
					13, 14, 15, 16,

					1, 2, 3, 4,
					5, 6, 7, 8,
					9, 10, 11, 12,
					13, 14, 15, 16,
				};
			}
		}

		public static int[] Golfers_444_c
		{
			get {
				return new int[] {
					1, 2, 3, 4,
					5, 6, 7, 8,
					9, 10, 11, 12,
					13, 14, 15, 16,

					13, 10, 7, 4,
					14, 11, 8, 1,
					15, 12, 2, 5,
					16, 3, 6, 9,

					1, 5, 9, 13,
					2, 6, 10, 14,
					3, 7, 11, 15,
					4, 8, 12, 16,

					1, 6, 11, 13,
					2, 5, 10, 15,
					3, 8, 9, 14,
					4, 7, 12, 16
				};
			}	
		}

		public static int[] Golfers_442_c4
		{
			get {
				return new int[] {
					1, 2, 3, 4,
					5, 6, 7, 8,
					9, 10, 11, 12,
					13, 14, 15, 16,

					13, 10, 7, 8,
					14, 11, 4, 1,
					15, 12, 2, 5,
					16, 3, 6, 9
				};
			}
		}

		public static int[] Golfers_442_mal
		{
			get{
				int[] config = Golfers_442_c4;
				config [4] = 4;
				config [5] = 4;
				return config;
			}
		}

		public static int[] Golfers_442_1s
		{
			get {
				return new int[] {
					1, 1, 1, 1,
					1, 1, 1, 1,
					1, 1, 1, 1,
					1, 1, 1, 1,

					1, 1, 1, 1,
					1, 1, 1, 1,
					1, 1, 1, 1,
					1, 1, 1, 1,
				};
			}
		}

		public static int[] Golfers_442_0s
		{
			get {
				return new int[]
				{
					0,  0,  0,  0,
					0,  0,  0,  0,
					0,  0,  0,  0,
					0,  0,  0,  0,

					0,  0,  0,  0,
					0,  0,  0,  0,
					0,  0,  0,  0,
					0,  0,  0,  0
				};
			}
		}

		public static int[] Golfers_553_c0
		{
			get {
				return new int[] {
					1, 2, 3, 4, 5,
					6, 7, 8, 9, 10,
					11, 12, 13, 14, 15,
					16, 17, 18, 19, 20,
					21, 22, 23, 24, 25,

					1, 6, 11, 16, 21,
					2, 7, 12, 17, 22,
					3, 8, 13, 18, 23,
					4, 9, 14, 19, 24,
					5, 10, 15, 20, 25,

					5, 9, 13, 17, 21,
					10, 14, 18, 22, 1,
					15, 19, 23, 6, 2,
					20, 24, 11, 7, 3,
					25, 4, 8, 12, 16
				};
			}
		}

		public static int[] Golfers_554_c0
		{
			get {
				return new int[] {
					1, 2, 3, 4, 5,
					6, 7, 8, 9, 10,
					11, 12, 13, 14, 15,
					16, 17, 18, 19, 20,
					21, 22, 23, 24, 25,

					1, 6, 11, 16, 21,
					2, 7, 12, 17, 22,
					3, 8, 13, 18, 23,
					4, 9, 14, 19, 24,
					5, 10, 15, 20, 25,

					5, 9, 13, 17, 21,
					10, 14, 18, 22, 1,
					15, 19, 23, 6, 2,
					20, 24, 11, 7, 3,
					25, 4, 8, 12, 16,

					1, 7, 13, 19, 25,
					6, 12, 18, 24, 5,
					11, 17, 23, 4, 10,
					16, 22, 3, 9, 15,
					2, 8, 14, 20, 21
				};
			}
		}

		public static int[] Golfers_553_c1
		{
			get {
				return new int[] {
					1, 2, 3, 4, 5,
					6, 7, 8, 9, 10,
					11, 12, 13, 14, 15,
					16, 17, 18, 19, 20,
					21, 22, 23, 24, 25,

					1, 6, 11, 16, 21,
					2, 7, 12, 17, 22,
					3, 8, 13, 18, 23,
					4, 9, 14, 19, 24,
					5, 10, 15, 20, 25,

					5, 9, 12, 17, 21,
					10, 14, 18, 22, 1,
					15, 19, 23, 6, 2,
					20, 24, 11, 7, 3,
					25, 4, 8, 13, 16
				};
			}
		}

		public static int[] Golfers_662_c0
		{
			get {
				return new int[] {
					1, 2, 3, 4, 5, 6,
					7, 8, 9, 10, 11, 12,
					13, 14, 15, 16, 17, 18,
					19, 20, 21, 22, 23, 24,
					25, 26, 27, 28, 29, 30,
					31, 32, 33, 34, 35, 36,

					1, 7, 13, 19, 25, 31,
					2, 8, 14, 20, 26, 32,
					3, 9, 15, 21, 27, 33,
					4, 10, 16, 22, 28, 34,
					5, 11, 17, 23, 29, 35,
					6, 12, 18, 24, 30, 36
				};
			}
		}
	}
}

