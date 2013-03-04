using System;

namespace CrackCodeInterview
{
	public static class Pow
	{
		public static double PowByMultiple(double a, int b)
		{
			double result = 1.0;
			int i = 1; 
			if (b < 0) {
				b=0-b;
				a = 1.0/a;
			}
			while (i<=b) {
				result *= a;
				i++;
			}
			return result;
		}

		public static double PowByRecursive(double a, int b)
		{
			//Can optimize by using cache
			if (a == 0) {
				return 0;
			}
			if (b < 0) {
				b=0-b;
				a = 1.0/a;
			}
			if (b == 0) {
				return 1;
			}
			if (b == 1) {
				return a;
			}
			double half = PowByRecursive (a, b / 2);
			if (b % 2 == 1) {
				return half * half * a;
			} else {
				return half * half;
			}
		}

		public static double PowByIteration(double a, int b)
		{
			//Can optimize by using cache
			if (a == 0) {
				return 0;
			}
			if (b < 0) {
				b=0-b;
				a = 1.0/a;
			}
			if (b == 0) {
				return 1;
			}
			if (b == 1) {
				return a;
			}
			int i = 1;
			double tempResult = a;
			while (i<=b/2) {
				tempResult = tempResult * tempResult;
				i = i * 2;
			}
			return tempResult * PowByIteration (a, b - i);
		}
	}
}

