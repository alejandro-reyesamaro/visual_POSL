using System;
using POSL.Tools;
using POSL.Data;

/**
 * POSL
 *
 * \brief Class to represent the absolute cost stratategy of Social Golgers Problem
 * \author Alejandro Reyes
 * \date 2017-05-14
 */
namespace POSL.Benchmarks
{
	/*!
	 * \class GolfersLongIntCostStrategy
	 * \brief Class to represent the absolute cost stratategy of Social Golgers Problem
	 */
	public class GolfersLongIntCostStrategy : ICostStrategy
	{
		private int groups; /*!< number of groups */
		private int players; /*!< players per group */
		private int weeks; /*!< weeks to play */
		private LongInt alldiff; /*!< Variable to store whether a player is playing more than once ina week */
		//private LongInt new_partner; /*!< Auxiliar variable to store a new partner */
		private LongInt global_partnership; /*!< Auxiliar variable to store a global partnership of a player */
		private LongInt[] global_partners; /*!< Variable to store the partners of each player (globally) */
		private LongInt[] group_partners; /*!< Variable to store the partners of each player (in a group) */

		/*! total players */
		private int TP { get{ return players * groups; } } 
		/*! total groups  */
		private int TG { get{ return groups * weeks; } }     
		//! how long must be the LongInt
		private int TL { get{ return players * groups / 32 + 1; } } 

		//! Initialize the LongInt field.
		/*!
            \param data A reference to the LongInt to initialize.
            \param bytes Number of bytes to initialize
            \param value The value of the LongInt
         */
		private void init(LongInt[] data, int bytes, int value)
		{
			for (int i = 0; i < data.Length; i++)
				data [i] = new LongInt (bytes, value);
		}

		//! Default constructor.
		/*!
            \param _groups Number of groups.
            \param _players Number of players per gruop (total of players = _groups * _players).
            \param _weeks Number of weeks.
         */
		public GolfersLongIntCostStrategy(int _groups, int _players, int _weeks)
		{
			groups = _groups;
			players = _players;
			weeks = _weeks;
			alldiff = new LongInt (TL, 0);
			//new_partner = new LongInt(TL, 0);
			global_partnership = new LongInt (TL, 0);
			global_partners = new LongInt[TP + 1];
			init (global_partners, TL, 0);
			group_partners = new LongInt[TP + 1]; 
			init (group_partners, TL, 0);
		}

		public int solutionCost(Solution solution)
		{
			int golfers = TP; //players * groups;
			int table_length = TL; //golfers / 32 + 1; // how long must be the LongInt
			init(global_partners, table_length, 0);
			init(group_partners, table_length, 0);

			alldiff.deactivateAll();

			int cost = 0;

			for(int w = 0; w < weeks; w++)
			{
				for(int g = 0; g < groups; g++)
				{
					int start_tournament = (w * TP) + (g * players);
					int end_tournament   = start_tournament + players;

					for(int i = start_tournament; i < end_tournament; i++)
						for(int j = start_tournament; j < end_tournament; j++)
					{
						alldiff.activate(solution[i]-1); // 0-based
						if(i != j)
						{
							//new_partner.deactivateAll(); //new_partner.clearBits();// LongInt new_partner (table_length, 0);
							//new_partner.activate(configuration[j]);
							//group_partners[configuration[i]] = group_partners[configuration[i]] | new_partner;
							group_partners[solution[i]].activate(solution[j]-1);
						}
					}
				}
				for(int i = 0; i < global_partners.Length; i++)
				{
					global_partnership.deactivateAll();
					global_partnership = global_partners[i] & group_partners[i];
					cost += global_partnership.bitCount();
					global_partners[i] = global_partners[i] | group_partners[i];
				}
				init(group_partners, table_length, 0);
				//cout << alldiff.toString() << endl;
				// all differents cost
				//int bc = alldiff.bitCount();
				cost += (golfers - alldiff.bitCount()) * 10; // Penalization
				alldiff.deactivateAll();
			}// O ( p^2 * g * w ) = O ( p * n )
			return cost;
		}
	}
}

