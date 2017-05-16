using System;
using POSL.Benchmarks;
using POSL.Data;
using POSL.Tools;

namespace POSL.Solver
{
	public class PSP
	{
		private Benchmark bench;
		public Benchmark GetBenchmark { get { return bench; } }

		private int best_found_cost;

		private Solution best_found_solution;
		public Solution GetBestSolutionSoFar{ get{ return best_found_solution; } }

		private int iterations;
		public int Iterations { get { return iterations; } }
		public void CountIteration(){ iterations ++; }

		private int milisecs;
		public int Time
		{ 
			get{ return milisecs; } 
			set{ milisecs = value; } 
		}

		private int restarts;
		public int Restarts { get { return restarts; } }
		public void StartSearch(){ restarts ++; }

		public Solution GetCurrentSolution{ get { return bench.GetSolution; } }

		public int CurrentCost { get{ return bench.CurrentCost; } }
		public int GetBestCostSoFar { get { return best_found_cost; } }

		//private RandomGenerator rand;
		//public RandomGenerator GetRandomizer { get { return rand; } }

		public PSP(Benchmark _bench)
		{
			this.bench = _bench;
			iterations = 0;
			milisecs = 0;
			best_found_solution = new Solution(_bench.Variable_Domain, _bench.Dimension);
			best_found_cost = int.MaxValue;
			restarts = -1;
		}

		public void clear_information()
		{
			iterations = 0;
			milisecs = 0;
			//fill(best_found_configuration.begin(), best_found_configuration.end(),1);
			best_found_cost = int.MaxValue;
			//outer_information = false;
			//found_thanks_outer_information = false;
			restarts = -1;
		}

		public void UpdateSolution(Solution s)
		{
			bench.UpdateSolution(s);
			int cost = bench.CurrentCost;
			int best_cost = best_found_cost;
			if(cost < best_cost)
			{
				best_found_solution = s.clone();
				best_found_cost = cost;
				//found_thanks_outer_information = outer_information;
			}
		}

		public void start(Solution config)
		{
			bench. InitializeCostData(config);
			if(iterations <= 0)
			{
				//copy(config.begin(), config.end(), best_found_configuration.begin());
				best_found_cost = bench.CurrentCost;
			}
		}

		//void PSP::log(std::string text){ plog.log(text); }
	}
}

