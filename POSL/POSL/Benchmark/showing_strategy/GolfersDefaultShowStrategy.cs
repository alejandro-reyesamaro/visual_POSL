using System;
using POSL.Data;
using POSL.Tools;

/**
 * POSL
 *
 * \brief Class to represent the way Social Golfers problem shows its result (solution)
 * \author Alejandro Reyes
 * \date 2017-05-14
 */
namespace POSL.Benchmarks
{
	/*!
	 * \class GolfersDefaultShowStrategy
	 * \brief Class to represent the way Social Golfers problem shows its result (solution)
	 */
	public class GolfersDefaultShowStrategy : IShowStrategy
	{
		//! [number of groups],[players per group],[weeks to play]
		private int groups; 
		private int players;
		private int weeks;

		//! Default constructor.
		/*!
            \param _groups Number of groups.
            \param _players Number of players per gruop (total of players = _groups * _players).
            \param _weeks Number of weeks.
         */
		public GolfersDefaultShowStrategy (int _groups, int _players, int _weeks)
		{
			groups = _groups;
			players = _players;
			weeks = _weeks;
		}

		//! From <IShowStrategy>
		public string showSolution(Solution solution)
		{
			string str =  "Golfers: players-" + PoslTools.int2str(players);
			str += ", groups-" + PoslTools.int2str(groups);
			str += ", weeks-" + PoslTools.int2str(weeks) + "\n";
			int[] config = solution.GetConfByCopy;
			//vector<int>::iterator it = config.begin();
			int it = 0;
			int value;
			for(int w = 0; w < weeks; w ++)
			{
				for(int g = 0; g < groups; g ++)
				{
					for(int p = 0; p < players; p ++)
					{
						value = config[it++];
						str += PoslTools.int2str(value) + "\t";
						it ++;
					}
					str += "\n";
				}
				str += "--\n";
			}
			return str;
		}
	}
}
