using NUnit.Framework;
using System;
using POSL.Benchmarks;
using POSL.Data;

namespace POSL_Test
{
	[TestFixture()]
	public class Test_Golfers
	{
		[Test()]
		public void Test_CostOfSolution ()
		{
			Golfers golfers = new Golfers (4, 4, 2);
			//shared_ptr<PSP> psp442(make_shared<PSP>(bench442));

			Solution sol442 = new Solution(golfers.Variable_Domain, ConfigurationProvider.Golfers_442_c0);
			Assert.That(golfers.solutionCost(sol442), Is.EqualTo(0));

			sol442 = new Solution(golfers.Variable_Domain, ConfigurationProvider.Golfers_442_c4);
			Assert.That(golfers.solutionCost(sol442), Is.EqualTo(4));

			Benchmark bench553 = new Golfers(5,5,4);
			Solution sol553 = new Solution(bench553.Variable_Domain, ConfigurationProvider.Golfers_554_c0);
			Assert.That(bench553.solutionCost(sol553), Is.EqualTo(0));

			Benchmark bench662 = new Golfers(6,6,2);
			Solution sol662 = new Solution(bench662.Variable_Domain, ConfigurationProvider.Golfers_662_c0);
			Assert.That(bench662.solutionCost(sol662), Is.EqualTo(0));
		}
	}
}

