using System;

namespace POSL.Data
{
	public class ElementsChangeIterator : IPOSL_Iterator
	{
		private Neighborhood neighborhood;
		private int current;

		public ElementsChangeIterator(Neighborhood _n)
		{
			neighborhood = _n;
			current = 0;
		}

		public int[] GetNext()
		{
			return neighborhood[current ++];
		}

		public bool SomeNext()
		{
			return current < neighborhood.Size;
		}

		public void Reset()
		{
			current = 0;
		}
	}
}

