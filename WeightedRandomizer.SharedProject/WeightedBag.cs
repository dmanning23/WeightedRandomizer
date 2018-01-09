using RandomExtensions;
using System;
using System.Collections.Generic;

namespace WeightedRandomizer
{
	public class WeightedBag<T>
	{
		#region Properties

		private static Random _random = new Random();

		private List<BagItem<T>> Items { get; set; }

		#endregion //Properties

		#region Methods

		public WeightedBag()
		{
			Items = new List<BagItem<T>>();
		}

		public void Clear()
		{
			Items.Clear();
		}

		public void AddItem(T item, float weight)
		{
			if (0f > weight)
			{
				throw new Exception("Weight must be >= 0");
			}

			Items.Add(new BagItem<T>(item, weight));
		}

		private float TotalWeight()
		{
			float total = 0f;
			for (int i = 0; i < Items.Count; i++)
			{
				total += Items[i].Weight;
			}

			return total;
		}

		public T NextItem()
		{
			if (0 == Items.Count)
			{
				throw new Exception("No items in the WeightedBag");
			}

			//get a random number between 0-total weight
			var rand = _random.NextFloat(TotalWeight());

			//start checking 
			for (int i = 0; i < Items.Count; i++)
			{
				rand -= Items[i].Weight;
				if (rand <= 0f)
				{
					return Items[i].Item;
				}
			}

			throw new Exception("Something went wrong with the WeightedBag randomizer: No result found for NextItem()");
		}

		#endregion //Methods
	}
}
