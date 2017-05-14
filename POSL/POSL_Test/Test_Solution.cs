using NUnit.Framework;
using System;
using POSL.Data;

namespace POSL_Test
{
	[TestFixture()]
	public class Test_Solution
	{
		[Test()]
		public void Test_GetConfiguration()
		{
			Solution sol1 = new Solution(new UniformDomain(1, 16), ConfigurationProvider.Golfers_442_c0);
			int[] conf_copy = sol1.GetConfByCopy;
			conf_copy [0] = 4;
			Solution sol2 = new Solution(new UniformDomain(1, 16), conf_copy);
			Assert.That(sol1.Equals(sol2), Is.EqualTo(false));
		}
	}
}

