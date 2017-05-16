using System;
using POSL.Solver;

namespace POSL.Data
{
	public interface IDynamicNeighborhood
	{
		void init(PSP psp, int[] _configuration);
	}
}

