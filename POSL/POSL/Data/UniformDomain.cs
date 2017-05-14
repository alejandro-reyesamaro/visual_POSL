using System;
using POSL.Tools;

namespace POSL.Data
{
	public class UniformDomain : Domain
	{
		private int min_value; 
		private int max_value;

		public UniformDomain(int _min_value, int _max_value)
		{
			min_value = _min_value;
			max_value = _max_value;
		}

		public override int[] GetValues(int variable)
		{
			return PoslTools.generateMonotony(min_value, max_value);
		}

		public override int minimum(int variable)
		{
			return min_value;
		}

		public override int maximum(int variable)
		{
			return max_value;
		}
	}
}

