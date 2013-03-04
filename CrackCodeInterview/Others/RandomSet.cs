using System;
using System.Collections.Generic;

namespace CrackCodeInterview
{
	//	How would you define a data structure that stores a set of values 
	//	(i.e. a value cannot appear more than one time), 
	//	and implements the following functions:
	//	add(p)--adds the value p to the set
	//	delete(p)--removes the value p from the set
	//	getrandom()--returns a random value from the set 
	//	(all items should be  equally likely, Assume you have access to some nice random() function.)
	//	All operations should be O(1) time complexity.

	//	Same as 
	//	Given a set, and functions insert(i), delete(i), count(i), size(), random. 
	//	Design a data structure and implement PopRandom() to pop a random element 
	//	from the set and return it.

	public class RandomSet<T>
	{
		List<T> list = new List<T>();
		Dictionary<T, int> dict = new Dictionary<T, int>();
		Random r = new Random ();
		public RandomSet ()
		{
		}

		public void Insert(T value){
			if (!dict.ContainsKey (value)) {
				list.Add (value);
				dict.Add (value, list.Count - 1);
			}
		}

		public void Delete(T value){
			if (dict.ContainsKey (value)) {
				int valueIndex = -1;
				dict.TryGetValue(value, out valueIndex);
				if(valueIndex<list.Count-1){
					list[valueIndex] = list[list.Count-1];
					list[list.Count-1] = value;
					dict.Remove(list[valueIndex]);
					dict.Add(list[valueIndex], valueIndex);
				}
				list.RemoveAt(list.Count-1);
				dict.Remove(value);
			}
		}

		public T GetRandomValue(){
			if (list.Count == 0) {
				return default(T);
			}
			int randomIndex = r.Next (list.Count);
			return list [randomIndex];
		}

		/// <summary>
		/// Check if Random set contains the value
		/// </summary>
		/// <param name="value">Value.</param>
		public bool Contains(T value){
			int index = -1;
			dict.TryGetValue (value, out index);
			if (index >= 0 && index < list.Count - 1) {
				if (list [index].ToString() == value.ToString()) {
					return true;
				} else {
					dict.Remove (value);
				}
			}
			return false;
		}
	}
}

