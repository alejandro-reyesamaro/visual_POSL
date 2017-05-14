using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/**
 * POSL
 *
 * \brief Interface to represent the a class that can projec the cost of a variable
 * \author Alejandro Reyes
 * \date 2017-05-13
 */
namespace POSL.Tools
{
	public class PoslTools
	{
		public static string int2str(int c)
		{
			return c.ToString();
		}

		public static string float2str(float f)
		{
			return f.ToString();
		}

		public static int str2int(string str)
		{
			return int.Parse(str);
		}

		public static float str2float(string str)
		{
			return float.Parse(str);
		}

		public static bool isANumber(string str)
		{
			int n;
			return int.TryParse(str, out n);
		}

		public static string configurationToString(int [] config)
		{
			if (config == null || config.Length == 0)
				return "[]";
			string txt = "[ " + config[0];
			for (int i = 1; i < config.Length; i++) 
				txt += ", " + config[i];
			return txt + " ]";
		}

		public static int segmentIntersection(int a1, int b1, int a2, int b2)
		{
			int A = Math.Max(a1, a2);
			int b = Math.Min(b1, b2);
			return Math.Max(0, b - A);
		}

		public static int mismatches(int[] vector_1, int[] vector_2)
		{
			int c = 0;
			for(int i = 0; i < vector_1.Length; i++)
				if(vector_1[i] != vector_2[i])
					c++;
			return c;
		}

		public static int[] generateMonotony(int N)
		{
			if (N <= 0)
				return null;
    		int[] v = new int[N];
			for (int i = 0; i < N; i++)
				v [i] = i;
    		return v;
		}

		public static int[] generateMonotony(int a, int b)
		{
			if (a > b)
				return null;
			int[] v = new int[b - a + 1];
			for (int i = a; i <=b; i++)
				v [i] = i;
			return v;
		}

		public static void sortAscendent(int[] v)
		{
			Array.Sort(v);
		}

		public static T_Changes getChanges(int[] config_before, int[] config_after)
		{
			if (config_after.Length != config_before.Length)
				throw new InvalidOperationException ("(POSL_Exception) sizes mismatches (PoslTools.getChanges)");
			List<int> l_new_values = new List<int> (config_after.Length);
			List<int> l_new_positions = new List<int> (config_after.Length);

			for (int i = 0; i < config_before.Length; i++) {
				if (config_before [i] != config_after [i]){
					l_new_values.Add (config_after [i]);
					l_new_positions.Add (i);
				}
			}

			return new T_Changes (l_new_positions.ToArray (), l_new_values.ToArray());
		}

		public static float norm1(int[] v1, int[] v2)
		{
			if(v1.Length != v2.Length)
				throw new InvalidOperationException("(PSOL Exception) vectors sizes mismatch (PoslTools.norm1)");
			int sum = 0;
			for (int i = 0; i < v1.Length; i++)
				sum += Math.Abs(v1[i] - v2[i]);
			return sum;
		}

		public static float norm2(int[] v1, int[] v2)
		{
			if(v1.Length != v2.Length)
				throw new InvalidOperationException("(PSOL Exception) vectors sizes mismatch (PoslTools.norm2)");
			int sum = 0;
			for (int i = 0; i < v1.Length; i++)
				sum += (v1[i] - v2[i]) * (v1[i] - v2[i]);
			return (float)Math.Sqrt(sum);
		}

		public static float norm8(int[] v1, int[] v2)
		{
			if(v1.Length != v2.Length)
				throw new InvalidOperationException("(PSOL Exception) vectors sizes mismatch (PoslTools.norm8)");
			int max = Math.Abs(v1[0] - v2[0]);
			int diff;
			for (int i = 1; i < v1.Length; i++)
			{
				diff = Math.Abs(v1[i] - v2[i]);
				if (diff > max) max = diff;
			}
			return max;
		}

		public static int element_mismatches(int[] v1, int[] v2, int distance)
		{
			if(v1.Length != v2.Length)
				throw new InvalidOperationException("(PSOL Exception) vectors sizes mismatch (PoslTools.element_mismatches)");
			int count = 0;
			for (int i = 0; i < v1.Length; i++)
			{
				if (Math.Abs(v1[i] - v2[i]) >= distance) count++;
			}
			return count;
		}

		public static int element_mismatches(int[] v1, int[] v2, int end, int distance)
		{
			if(v1.Length != v2.Length)
				throw new InvalidOperationException("(PSOL Exception) vectors sizes mismatch (PoslTools.element_mismatches)");
			if(end >= (int)v2.Length)
				end = (int)v2.Length - 1;
			int count = 0;
			for (int i = 0; i < end; ++i)
				if (Math.Abs(v1[i] - v2[i]) >= distance) count++;
			return count;
		}

		public static int max(int[] v)
		{
			return v.Max();
		}

		public static int min(int[] v)
		{
			return v.Min();
		}

		public static int sum(int[] v)
		{
			return v.Sum();
		}

		public static int sum(int[] v, int first_k_elements)
		{
			if(v.Length < first_k_elements)
				throw new InvalidOperationException("(PSOL Exception) vectors size mismatch (PoslTools.sum)");
			int sum = 0;
			for (int i = 0; i < first_k_elements; i++) {
				sum += v [i];
			}
			return sum;
		}

		public static int zero_bounded_decrease(int x)
		{
			return (x > 0) ? x - 1 : 0;
		}

		public static int identity(int x, int _base)
		{
			return (x > _base) ? x : 0;
		}

		public static int identity(int x)
		{
			return identity(x, 1);
		}

		public static int sqr(int b)
		{
			return b * b;
		}

		public static int sign(int x)
		{
			if (x == 0) return 0;
			return (x > 0) ? 1 : -1;
		}

		public static bool equals_vectors(int[] v1, int[] v2)
		{
			return (v1.Length == v2.Length && v1.Intersect(v2).Count() == v1.Length);
			/*
			if (v1.Length != v2.Length)
				return false;
			for(int i = 0; i < v1.size(); i++)
				if (v1[i] != v2[i])
					return false;
			return true;
			*/
		}

		public static void activateBit(ref int integer, int bit)
		{
			if (bit >= 32) 
				throw new InvalidOperationException("(POSL Exception) Activation is not possible (Tools::activateBit)");
			integer = integer | (int)Math.Pow(2,bit);
		}

		public static int bitsCount(int integer)
		{
			int count;
			integer = integer - ((integer >> 1) & 0x55555555);
			integer = (integer & 0x33333333) + ((integer >> 2) & 0x33333333);
			count = (((integer + (integer >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
			return count;
		}

		public static void fill(int[] arr, int value)
		{
			for (int i = 0; i < arr.Length; i++)
				arr [i] = value;
		}

		public static void copy(int[] arr_source, int src_start, int src_end_out, int[] destination, int dest_start)
		{
			for (int i = src_start; i < src_end_out; i++)
				destination [dest_start++] = arr_source [i];
		}
	}
}

