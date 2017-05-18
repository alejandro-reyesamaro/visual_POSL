using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace POSL.Tools
{
	/*!
	 * \class PoslTools 
	 * \brief Static class containing auxiliar methods
	 * \author Alejandro Reyes
 	 * \date 2017-05-17
	 */
	public class PoslTools
	{
		//! Verifies whether a string str is a number
		public static bool isANumber(string str)
		{
			int n;
			return int.TryParse(str, out n);
		}
		//! Configuration into a string 
		public static string configurationToString(int [] config)
		{
			if (config == null || config.Length == 0)
				return "[]";
			string txt = "[ " + config[0];
			for (int i = 1; i < config.Length; i++) 
				txt += ", " + config[i];
			return txt + " ]";
		}
		//! Width of an intersection between two segments
		public static int segmentIntersection(int a1, int b1, int a2, int b2)
		{
			if (a1 > b1 || a2 > b2)
				p_throw("invalid segment definition", "PoslTools", "segmentIntersection");
			int A = Math.Max(a1, a2);
			int b = Math.Min(b1, b2);
			return Math.Max(0, b - A);
		}
		//! Generates a vector 0...N-1
		public static int[] generateMonotony(int N)
		{
			if (N <= 0)
				return null;
    		int[] v = new int[N];
			for (int i = 0; i < N; i++)
				v [i] = i;
    		return v;
		}
		//! Generates a vector a...b
		public static int[] generateMonotony(int a, int b)
		{
			if (a > b)
				return null;
			int N = b - a + 1;
			int[] v = new int[N];
			for (int i = 0; i < N; i++)
				v [i] = a++;
			return v;
		}
		//! Sort a vector in ascendent way
		public static void sortAscendent(int[] v)
		{
			Array.Sort(v);
		}
		//! Difference between two vector w.r.t Norm 1
		public static float norm1(int[] v1, int[] v2)
		{
			if(v1.Length != v2.Length)
				p_throw("vectors sizes mismatch", "PoslTools", "norm1");
			int sum = 0;
			for (int i = 0; i < v1.Length; i++)
				sum += Math.Abs(v1[i] - v2[i]);
			return sum;
		}
		//! Difference between two vector w.r.t Norm 2
		public static float norm2(int[] v1, int[] v2)
		{
			if(v1.Length != v2.Length)
				p_throw("vectors sizes mismatch", "PoslTools", "norm2");
			int sum = 0;
			for (int i = 0; i < v1.Length; i++)
				sum += (v1[i] - v2[i]) * (v1[i] - v2[i]);
			return (float)Math.Sqrt(sum);
		}
		//! Difference between two vector w.r.t Norm Inf
		public static float norm8(int[] v1, int[] v2)
		{
			if(v1.Length != v2.Length)
				p_throw("vectors sizes mismatch", "PoslTools", "norm8");
			int max = Math.Abs(v1[0] - v2[0]);
			int diff;
			for (int i = 1; i < v1.Length; i++)
			{
				diff = Math.Abs(v1[i] - v2[i]);
				if (diff > max) max = diff;
			}
			return max;
		}
		//! How many index have different values
		public static int mismatches(int[] v1, int[] v2)
		{
			if (v1.Length != v2.Length)
				p_throw("invalid vectors definitions", "PoslTools", "mismatches");
			int c = 0;
			for(int i = 0; i < v1.Length; i++)
				if(v1[i] != v2[i])
					c++;
			return c;
		}
		//! How many index have different values w.r.t. a distance (epsilon)
		public static int mismatches(int[] v1, int[] v2, int distance)
		{
			if(v1.Length != v2.Length)
				p_throw("vectors sizes mismatch", "PoslTools", "mismatches");
			int count = 0;
			for (int i = 0; i < v1.Length; i++)
			{
				if (Math.Abs(v1[i] - v2[i]) > distance) count++;
			}
			return count;
		}
		//! How many index of the first "end" elements have different values w.r.t. a distance (epsilon) 
		public static int mismatches(int[] v1, int[] v2, int end, int distance)
		{
			if(v1.Length != v2.Length || end > v2.Length)
				p_throw("vectors sizes mismatch or end to long", "PoslTools", "mismatches");
			if(end >= (int)v2.Length)
				end = (int)v2.Length - 1;
			int count = 0;
			for (int i = 0; i < end; ++i)
				if (Math.Abs(v1[i] - v2[i]) > distance) count++;
			return count;
		}
		//!  Sum the first K elemnts of the vector v
		public static int sum(int[] v, int first_k_elements)
		{
			if(v.Length < first_k_elements)
				p_throw("K too long", "PoslTools", "sum");
			int sum = 0;
			for (int i = 0; i < first_k_elements; i++) {
				sum += v [i];
			}
			return sum;
		}
		//! Returns whether vectors are equals
		public static bool equals_vectors(int[] v1, int[] v2)
		{
			if (v1.Length == v2.Length)
				return false;
			for(int i = 0; i < v1.Length; i++)
				if (v1[i] != v2[i])
					return false;
			return true;
		}
		//! Activates the bit-th bit on an integer
		public static void activateBit(ref int integer, int bit)
		{
			if (bit >= 32 || bit < 0) 
				p_throw("activation is not possible", "PoslTools", "activateBit");
			integer = integer | 1 << bit; //(int)Math.Pow(2,bit);
		}
		//! Counts all activated bits
		public static int bitsCount(int integer)
		{
			int count;
			integer = integer - ((integer >> 1) & 0x55555555);
			integer = (integer & 0x33333333) + ((integer >> 2) & 0x33333333);
			count = (((integer + (integer >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
			return count;
		}
		//! Fill all the cells of arr with the integer value
		public static void fill(int[] arr, int value)
		{
			if(arr != null)
				for (int i = 0; i < arr.Length; i++)
					arr [i] = value;
		}
		//! Copy some portion of the source array to the destination array
		/*!
			\param source The source array.
			\param src_start The startin index of the source
			\param src_end_out The ending index + 1
			\param destination The destination array
			\param dest_start The starting index of the destination
		*/
		public static void copy(int[] source, int src_start, int src_end_out, int[] destination, int dest_start)
		{
			if (source == null || destination == null || src_start < 0 || 
				src_start > src_end_out || src_end_out > source.Length || 
			    dest_start < 0 || dest_start > destination.Length)
				p_throw ("invalid index configuration or null arrays", "PoslTools", "copy");
			int sub_array_length = src_end_out - src_start;
			if(destination.Length - dest_start < sub_array_length)
				p_throw ("no enough space to copy", "PoslTools", "copy");
			for (int i = src_start; i < src_end_out; i++)
				destination [dest_start++] = source [i];
		}

		// NO TEST
		public static void p_throw(string message, string class_name, string method_name)
		{
			throw new InvalidOperationException ("(PSOL Exception) " + message + " (" + class_name + "." + method_name + ")");
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
		public static int sqr(int b)
		{
			return b * b;
		}
		public static int sign(int x)
		{
			if (x == 0) return 0;
			return (x > 0) ? 1 : -1;
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
		//--
	}
}

