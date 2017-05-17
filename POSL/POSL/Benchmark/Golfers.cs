using System;
using POSL.Data;
using POSL.Tools;

namespace POSL.Benchmarks
{
	/*!
	 * \class Golfers
	 * \brief Class to represent an instance of a Golfers Problems
	 * \author Alejandro Reyes
 	 * \date 2017-05-14
	 */
	public class Golfers : Benchmark
	{
		private int groups; /*!< number of groups */
		private int players; /*!< number of player */
		private int weeks; /*!< number of weeks */

		//! Main constructor.
		/*!
            \param g Number of groups.
            \param p Number of players per gruop (total of players = g * p).
            \param w Number of weeks.
         */
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

		//! From <Benchmark>
		public override string showInstance()
		{
			string str =  "Golfers: players-" + players;
			str += ", groups-" + groups;
			str += ", weeks-" + weeks + "\n";
			return str;
		}
	}
}

