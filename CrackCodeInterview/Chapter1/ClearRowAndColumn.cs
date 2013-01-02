using System;

namespace CrackCodeInterview
{
	/// <summary>
	/// Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column is set to 0.
	/// </summary>
	public class ClearRowAndColumn : IRun
	{
		int M, N;
		int [,] Matrix;
		public ClearRowAndColumn (int[,] matrix)
		{
			if (matrix == null) {
				throw new ArgumentNullException("Matrix can not be null");
			}
			Matrix = matrix;
			M = matrix.GetLength(0);
			N = matrix.GetLength(1);
		}

		public bool Run ()
		{
			Console.WriteLine("Original Matrix"); 
			for (int i = 0; i< M; i++) {
				for (int j=0; j<N; j++) {
					Console.Write(Matrix[i,j]);
					Console.Write(" ");
				}
				Console.Write('\n');
			}

			int[] rowWithZero = new int[M];
			int[] columnWithZero = new int[N];
			for (int i = 0; i< M; i++) {
				for (int j=0; j<N; j++) {
					if (Matrix [i, j] == 0) {
						rowWithZero [i] = 1;
						columnWithZero [j] = 1;
					}
				}
			}

			for (int i = 0; i< M; i++) {
				for (int j=0; j<N; j++) {
					if (rowWithZero [i] == 1 || columnWithZero[j] == 1 ) {
						Matrix[i,j] = 0;
					}
				}
			}

			//Output 
			Console.WriteLine("New Matrix"); 
			for (int i = 0; i< M; i++) {
				for (int j=0; j<N; j++) {
					Console.Write(Matrix[i,j]);
					Console.Write(" ");
				}
				Console.Write('\n');
			}
			return true;
		}
	}
}

