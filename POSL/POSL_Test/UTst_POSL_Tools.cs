using NUnit.Framework;
using System;
using POSL.Tools;

namespace POSL_Test
{
	[TestFixture()]
	public class UTst_POSL_Tools
	{
		[Test()]
		public void Test_isANumber ()
		{
			var crs = new CaseResultSet<string, bool> ();
			crs.addTest ("123", true);
			crs.addTest ("12e4", false);
			crs.addTest ("123456789012345678901234567890123", false);
			for(int i = 0; i < crs.Count; i++)
				Assert.That(PoslTools.isANumber(crs.GetCase(i)), Is.EqualTo(crs.GetResult(i)));
		}
		[Test()]
		public void Test_configurationToString ()
		{
			var crs = new CaseResultSet<int[], string> ();
			crs.addTest (new int[0], "[]");
			crs.addTest (new int[]{1}, "[ 1 ]");
			crs.addTest (new int[]{1, 2, 3}, "[ 1, 2, 3 ]");
			for(int i = 0; i < crs.Count; i++)
				Assert.That(PoslTools.configurationToString(crs.GetCase(i)), Is.EqualTo(crs.GetResult(i)));
		}
		[Test()]
		public void Test_segmentIntersection ()
		{
			int[] a1 = new int[] { -1, 0, 0, 1, 4};
			int[] b1 = new int[] { 4, 2, 3, 2, 5};
			int[] a2 = new int[] { 0, 1, 2, 3, 4};
			int[] b2 = new int[] { 3, 3, 2, 4, 5};
			int[] rs = new int[] { 3, 1, 0, 0, 1};
			for(int i = 0; i < a1.Length; i++)
				Assert.That(PoslTools.segmentIntersection(a1[i], b1[i], a2[i], b2[i]), Is.EqualTo(rs[i]));
		}
		[Test()]
		public void Test_mismatches ()
		{
			int[] v123 = new int[] { 1, 2, 3};
			int[] v113 = new int[] { 1, 1, 3};
			int[] v456 = new int[] { 4, 5, 6};
			int[] v458 = new int[] { 4, 5, 8};
			int[] v124 = new int[] { 1, 2, 4};
			int[] v1 = new int[] { 1 };

			Assert.That(PoslTools.mismatches(v123, v113), Is.EqualTo(1));
			Assert.That(PoslTools.mismatches(v123, v123), Is.EqualTo(0));
			Assert.That(PoslTools.mismatches(v123, v456), Is.EqualTo(3));
			bool exception = false;
			try {
				PoslTools.mismatches(v123, v1);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));

			Assert.That(PoslTools.mismatches(v123, v113, 0), Is.EqualTo(1));
			Assert.That(PoslTools.mismatches(v123, v458, 4), Is.EqualTo(1));
			Assert.That(PoslTools.mismatches(v123, v124, 0), Is.EqualTo(1));
			exception = false;
			try {
				PoslTools.mismatches(v123, v1, 1);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));

			Assert.That(PoslTools.mismatches(v123, v113, 2, 0), Is.EqualTo(1));
			Assert.That(PoslTools.mismatches(v123, v458, 2, 4), Is.EqualTo(0));
			Assert.That(PoslTools.mismatches(v123, v124, 2, 0), Is.EqualTo(0));
			exception = false;
			try {
				PoslTools.mismatches(v123, v1, 1, 0);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));
			exception = false;
			try {
				PoslTools.mismatches(v123, v123, 4, 0);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));
		}
		[Test()]
		public void Test_generateMonotonyN ()
		{
			var crs = new CaseResultSet<int, int[]> ();
			crs.addTest (0, null);
			crs.addTest (1, new int[]{0});
			crs.addTest (3, new int[]{0, 1, 2});
			for(int i = 0; i < crs.Count; i++)
				Assert.That(PoslTools.generateMonotony(crs.GetCase(i)), Is.EqualTo(crs.GetResult(i)));
		}
		[Test()]
		public void Test_generateMonotonyAB ()
		{
			Assert.That(PoslTools.generateMonotony(1, 0), Is.EqualTo(null));
			Assert.That(PoslTools.generateMonotony(1, 1), Is.EqualTo(new int[]{1}));
			Assert.That(PoslTools.generateMonotony(1, 3), Is.EqualTo(new int[]{1, 2, 3}));
		}
		[Test()]
		public void Test_sortAsc ()
		{
			int[] arr = new [] { 5, 7, 3};
			PoslTools.sortAscendent (arr);
			Assert.That(arr, Is.EqualTo(new int[]{3, 5, 7}));
		}
		[Test()]
		public void Test_norm ()
		{
			int[] v123 = new int[] { 1, 2, 3};
			int[] v111 = new int[] { 1, 1, 1};
			int[] v235 = new int[] { 2, 3, 5};
			int[] v12 = new int[] { 1, 2};
			// Norm 1
			Assert.That(PoslTools.norm1(v123, v123), Is.EqualTo(0));
			Assert.That(PoslTools.norm1(v235, v111), Is.EqualTo(7));
			bool exception = false;
			try {
				PoslTools.norm1(v123, v12);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));
			// Norm 2
			Assert.That(PoslTools.norm2(v123, v123), Is.EqualTo(0));
			Assert.That(PoslTools.norm2(v235, v111), Is.EqualTo((float)Math.Sqrt(21)));
			exception = false;
			try {
				PoslTools.norm2(v123, v12);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));
			// Norm Inf
			Assert.That(PoslTools.norm8(v123, v123), Is.EqualTo(0));
			Assert.That(PoslTools.norm8(v235, v111), Is.EqualTo(4));
			exception = false;
			try {
				PoslTools.norm8(v123, v12);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));
		}
		[Test()]
		public void Test_sum ()
		{
			int[] v123 = new int[] { 1, 2, 3, 4};
			Assert.That(PoslTools.sum(v123, 3), Is.EqualTo(6));
			bool exception = false;
			try {
				PoslTools.sum(v123, 5);
			} catch (InvalidOperationException) {
				exception = true;
			}
			Assert.That(exception, Is.EqualTo(true));
		}
		[Test()]
		public void Test_eq ()
		{
			int[] v123 = new int[] { 1, 2, 3};
			int[] v111 = new int[] { 1, 1, 1};
			int[] v213 = new int[] { 2, 1, 3};
			Assert.That(PoslTools.equals_vectors(v123, v111), Is.EqualTo(false));
			Assert.That(PoslTools.equals_vectors(v123, v213), Is.EqualTo(false));
		}
		[Test()]
		public void Test_Bits ()
		{
			int int_ = 8;
			PoslTools.activateBit (ref int_, 1); Assert.That(int_, Is.EqualTo(10));
			PoslTools.activateBit (ref int_, 1); Assert.That(int_, Is.EqualTo(10));
			int pot = 16 - 1;
			Assert.That(PoslTools.bitsCount(pot), Is.EqualTo(4));
			Assert.That(PoslTools.bitsCount(pot+1), Is.EqualTo(1));
			Assert.That(PoslTools.bitsCount(int_), Is.EqualTo(2));
		}
		[Test()]
		public void Test_fillArray ()
		{
			int[] arr = new int[3];
			PoslTools.fill (arr, 3);
			int[] v = new int[0];
			PoslTools.fill (v, 3);
			Assert.That(v, Is.EqualTo(new int[]{}));
		}
		[Test()]
		public void Test_copy ()
		{
			int[] source = new int[] { 1, 2, 3, 4, 5, 6, 7 };
			int[] destination = new int[] { 8, 9, 10, 11, 12, 13, 14, 15 };
			PoslTools.copy (source, 0, 7, destination, 1);
			Assert.That(destination, Is.EqualTo(new int[]{8, 1, 2, 3, 4, 5, 6, 7}));
		}
	}
}
























