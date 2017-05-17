using System;

namespace POSL.Tools
{
	/*!
	 * \class RandomGenerator 
	 * \brief Class to represent a randome generator engine
	 * \author Alejandro Reyes
 	 * \date 2017-05-17
	 */
	public class RandomGenerator
	{
		private Random rand;
		public Random Generator { get{ return rand; } }

		RandomGenerator()
		{
			rand = new Random (System.Environment.TickCount);
		}

		public RandomGenerator(int base_seed)
		{
			rand = new Random (base_seed);
		}

		public int next_int(int min, int max)
		{
			return rand.Next (min, max);
		}
	}
}

