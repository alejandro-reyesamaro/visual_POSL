using System;

namespace POSL.Data
{
	public interface IPOSL_Iterator
	{
		int[] GetNext();
		bool SomeNext();
		void Reset();
	}
}

