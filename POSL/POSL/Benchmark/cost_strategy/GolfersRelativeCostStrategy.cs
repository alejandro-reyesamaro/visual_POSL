using System;
using POSL.Tools;
using POSL.Data;
using System.Collections.Generic;

namespace POSL.Benchmarks
{
	/*!
	 * \class GolfersRelativeCostStrategy
	 * \brief Class to represent the cost stratategy of Social Golgers Problem
	 * \author Alejandro Reyes
 	 * \date 2017-05-15
	 */
	public class GolfersRelativeCostStrategy : IRelativeCostStrategy
	{
		//! The current configuration.
		private int[] configuration;
		//! [number of groups],[players per group],[weeks to play]
		private int groups, players, weeks;
		//! Current configuration occurrences
		private ConnectionMatrix cc_occurrences;
		//! Current cost
		private int current_cost;
		//! A temporal vector to store the dab variables (same projected cost)
		private List<int> bad_variables;        
		//! Random generator to choose the <i>bad variable</i>
		private RandomGenerator r_gen;

		private int TP { get{ return players * groups; } }
		private int T { get{ return (groups * players * weeks); } }

		//! Default constructor.
		/*!
            \param g Number of groups.
            \param p Number of players per gruop (total of players = _groups * _players).
            \param w Number of weeks.
         */
		public GolfersRelativeCostStrategy(int g, int p, int w)
		{
			groups = g;
			players = p;
			weeks = w;
			configuration = new int[T];
			cc_occurrences = new ConnectionMatrix (g * p);
			current_cost = 0;
			bad_variables = new List<int>(TP);
		}

		//! (Property) From <RelativeCostStrategy>
		public int currentCost() { return current_cost; }

		//! Initialize the required information to compute the relative cost.
		/*!
            \param solution Solution (configuration)
            \param _initial_cost The initial cost of the configuration (to test)
         */
		public void initializeCostData(Solution solution, int _initial_cost)
		{
			configuration = solution.GetConfByCopy;
			int start_tournament, end_tournament;
			current_cost = 0;
			cc_occurrences.clear();
			for(int w = 0; w < weeks; w++)
			{
				for(int g = 0; g < groups; g++)
				{
					start_tournament = (w * TP) + (g * players);
					end_tournament   = start_tournament + players;

					for(int i = start_tournament; i < end_tournament - 1; i++)
						for(int j = i + 1; j < end_tournament; j++)
					{
						current_cost += cc_occurrences.add_connection(configuration[i], configuration[j], true);
						//current_cost += cc_occurrences.projected_cost(configuration[i], configuration[j]);
					}
				}
			}
			current_cost = _initial_cost;
		}

		//! Computes the cost of a solution relative to the current.
		/*!
            \param solution Solution (configuration)
            \param change Performed changes w.r.t. the current configuration
            \param updating Whether the internal information has to be updated
            \return The relative cost
         */
		public int relative_cost(Solution new_solution, T_Changes change, bool updating)
		{
			int cost = 0;
			int pos, new_value, w, g, j;
			int start_position_group_for_change, end_group_for_change;
			int current_player_at_pos, partner_current_group, partner_new_group;

			for(int i = 0; i < change.Dimension; i++)
			{
				pos = change.Positions[i];
				new_value = change.NewValues[i];

				w = pos / TP;
				g = (pos % TP) / players;
				start_position_group_for_change = w * TP + g * players;
				end_group_for_change = w * TP + (g + 1) * players;

				for(j = start_position_group_for_change; j < end_group_for_change; j++)
				{
					if(j != pos)
					{
						current_player_at_pos = configuration[pos];
						partner_current_group = configuration[j];
						partner_new_group = new_solution[j];

						cost += cc_occurrences.remove_connection(current_player_at_pos, partner_current_group, updating);
						cost += cc_occurrences.add_connection(new_value, partner_new_group, updating);
					}
				}
			}
			return cost;
		}

		//! Updates the current infoemation (configuration).
		/*!
            \param solution Solution (configuration)
         */
		public void updateConfiguration(Solution new_solution)
		{
			T_Changes changes = Solution.getChanges(configuration, new_solution);
			if(changes.Dimension > 0)
			{
				current_cost += relative_cost(new_solution, changes, true);
				configuration = new_solution.GetConfByCopy;
			}
		}

		//! Computes the cost of a solution relative to the current.
		/*!
            \param solution Solution (configuration)
            \return The relative cost
         */
		public int relativeSolutionCost(Solution new_solution)
		{
			T_Changes changes = Solution.getChanges(configuration, new_solution);
			return relativeSolutionCost(new_solution, changes);
		}

		//! Computes the cost of a solution relative to the current.
		/*!
            \param solution Solution (configuration)
            \param change Performed changes w.r.t. the current configuration
            \return The relative cost
         */
		public int relativeSolutionCost(Solution new_solution, T_Changes _changes)
		{
			return current_cost + relative_cost(new_solution, _changes, false);
		}

		//! Computes the projected cost of a variable
		/*!
            \param variable_index The index of the variable
            \return The projected cost
         */
		public int costOnVariable(int variable_index)
		{
			return cc_occurrences.ranking_cost_of_variable(variable_index);
		}

		//! Selects the worst variable w.r.t. the projected cost
		/*!
            \return Just the worst player (the index of the player)
         */
		public int sickestVariable()
		{
			bad_variables.Clear();
			int cov;
			int bcov = costOnVariable(0);
			bad_variables.Add(0);
			for(int i = 1; i < groups * players; i++)
			{
				cov = costOnVariable(i);
				if (cov == bcov)
					bad_variables.Add(i);
				else if(cov > bcov)
				{
					bcov = cov;
					bad_variables.Clear();
					bad_variables.Add(i);
				}
			}
			return bad_variables[r_gen.next_int(0, bad_variables.Count-1)];
		}
	}
}

