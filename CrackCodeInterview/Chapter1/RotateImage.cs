using System;

namespace CrackCodeInterview
{
	/// <summary>
	/// Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, 
	/// write a method to rotate the image by 90 degrees. Can you do this in place?
	/// </summary>
	public class RotateImage:IRun
	{
		int N;
		int[,] image;
		public RotateImage (int[,] imageMap)
		{
			if (imageMap == null) {
				throw new ArgumentNullException ("image Map can not be null");
			}
			image = imageMap;
			int row = image.GetLength (0);
			int column = image.GetLength (1);
			if (row != column) {
				throw new ArgumentException("Image map needs to be square. For example: N * N");
			}
			N = row;
		}

		public bool Run ()
		{
			//before Rotation
			Console.WriteLine("Before rotation:");
			for (int i = 0; i< N; i++) {
				for (int j=0; j< N; j++) {
					Console.Write(image[i,j]);
					Console.Write(" ");
				}
				Console.WriteLine("");
			}
			for (int i = 0; i< N / 2; i++) {
				for (int j=i; j < N - 1 - i; j++) {
					//Save top value
					int temp = image [i, j];

					//Left -> Top
					image [i, j] = image [N - 1 - j, i];

					//Bottom to Left
					image [N - 1 - j, i] = image [N - 1 - i, N - 1 - j];

					//Right to Bottom
					image [N - 1 - i, N - 1 - j] = image [j, N - 1 - i];

					//Top to Right
					image [j, N - 1 - i] = temp;
				}
			}

			//Output
			Console.WriteLine("Result after rotation:");
			for (int i = 0; i< N; i++) {
				for (int j=0; j< N; j++) {
					Console.Write(image[i,j]);
					Console.Write(" ");
				}
				Console.WriteLine("");
			}
			return true;
		}
	}
}

