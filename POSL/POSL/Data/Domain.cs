using System;

namespace POSL
{
	public abstract class Domain
	{
		public abstract int[] GetValues(int variable);
		public abstract int minimum(int variable);
		public abstract int maximum(int variable);
	}
}

