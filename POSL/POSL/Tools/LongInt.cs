using System;

namespace POSL.Tools
{
	public class LongInt
	{
		private int bytes;
		public int Length { get{ return bytes; } }

		private int[] value;
		public int this[int index] { get{ return value [index]; } }

		public LongInt(int _bytes, int[] _value)
		{
			bytes = _bytes;
			value = _value;
		}

		public LongInt(int _bytes, int _value)
		{    
			bytes = _bytes;
			value = new int[_bytes];
			value[0] = _value;
		}

		public LongInt(int _bytes)
		{
			bytes = _bytes;
			value = new int[_bytes];
			activateAll();
		}

		public static LongInt operator |(LongInt a, LongInt b)
		{
			MergedLongInt m = new MergedLongInt(a, b);
			return m.long_or();
		}

		public static LongInt operator &(LongInt a, LongInt b)
		{
			MergedLongInt m  = new MergedLongInt(a, b);
			return m.long_and();
		}

		public bool activated()
		{
			bool act = false;
			for(int i = 0; i < Length; i++)
				act = act || (value[i] > 0);
			return act;
		}

		public bool activated(int bit)
		{
			//int act = max(0,int((bit % 32) - 1));
			//int act = (bit % 32) - 1;
			int act = (bit % 32);
			int b = bit / 32;
			int activated_bit = (int)Math.Pow(2,act);
			if (b < Length)
			{
				int is_activated = value[b] & activated_bit;
				return (is_activated != 0);
			}
			else return false;
		}

		public void activate(int bit)
		{
			//int act = max(0,int((bit % 32) - 1));
			//int act = (bit % 32) - 1;
			int act = (bit % 32);
			int b = bit / 32;
			if (b < Length)
				value[b] = value[b] | (int)Math.Pow(2,act);
		}

		public void activateAll()
		{
			for (int i = 0; i < value.Length; i++) {
				value [i] = int.MaxValue;
			}
		}
		public void deactivateAll()
		{
			Array.Clear (value, 0, value.Length);
		}

		public int bitCount()
		{
			int count = 0;
			for(int i = 0; i < Length; i++){
				int v = value[i];
				v = v - ((v >> 1) & 0x55555555);
				v = (v & 0x33333333) + ((v >> 2) & 0x33333333);
				count += (((v + (v >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
			}
			return count;
		}

		public bool Equal(LongInt other)
		{
			MergedLongInt m = new MergedLongInt (this, other);
			return m.equal();
		}

		public string binary(int val, int bit)
		{
			if(bit == 0)
				return "";
			string str_b = ((val & 1) == 1) ? "|" : ".";
			return binary(val >> 1, bit - 1) + str_b;
		}

		public string toString()
		{
			string bin = "";
			for (int i = 0; i < value.Length; i++) {
				bin = binary(value[i], 32) + bin;
			}
			return bin;
		}
	}
}

