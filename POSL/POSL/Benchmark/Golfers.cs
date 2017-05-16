using System;
using POSL.Data;
using POSL.Tools;

/**
 * POSL
 *
 * \brief Class to represent an instance of a Golfers Problems
 * \author Alejandro Reyes
 * \date 2017-05-14
 */
namespace POSL.Benchmarks
{
	/*!
	 * \class Golfers
	 * \brief Class to represent an instance of a Golfers Problems
	 */
	public class Golfers : Benchmark
	{
		//! [number of groups],[players per group],[weeks to play]
		private int groups;
		private int players;
		private int weeks;

		public Golfers(int g, int p, int w)
			: base(g * p * w,
			       new UniformDomain(1, p * g),
			       new GolfersLongIntCostStrategy(g,p,w),
			       new GolfersRelativeCostStrategy(g,p,w),
			       new GolfersDefaultShowStrategy(g,p,w))
		{
			groups = g;
			players = p;
			weeks = w;
		}

		public override string showInstance()
		{
			string str =  "Golfers: players-" + PoslTools.int2str(players);
			str += ", groups-" + PoslTools.int2str(groups);
			str += ", weeks-" + PoslTools.int2str(weeks) + "\n";
			return str;
		}
	}
}

