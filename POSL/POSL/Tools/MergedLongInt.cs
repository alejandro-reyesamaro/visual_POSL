using System;

namespace POSL.Tools
{
	public class MergedLongInt
	{
		private int _max;
		private int _min;
		private LongInt _upper;
		private LongInt _lower;

		public MergedLongInt(LongInt a, LongInt b)
		{
			_max = Math.Max (a.Length, b.Length);
			_min = Math.Min (a.Length, b.Length);
			_upper = (a.Length > b.Length) ? a : b;
			_lower = (a.Length > b.Length) ? b : a;
		}

		public LongInt long_or()
		{
			int[] aux = new int[_max];

			int i;
			for(i = 0; i < _min; i++)
				aux[i] = _lower[i] | _upper[i];
			for(int j = i; j < _max; j++)
				aux[j] = _upper[j];
			return new LongInt(_max, aux);
		}

		public LongInt long_and()
		{
			int[] aux = new int[_max];
			for(int i = 0; i < _min; i++)
				aux[i] = _lower[i] & _upper[i];
			return new LongInt(_max, aux);
		}

		public bool equal()
		{
			if (_max != _min) return false;
			bool eq = true;
			for(int i = 0; i < _min; i++)
				eq = eq && _lower[i] == _upper[i];
			return eq;
		}
	}
}

