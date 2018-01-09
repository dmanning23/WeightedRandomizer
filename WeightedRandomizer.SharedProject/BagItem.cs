using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedRandomizer.SharedProject
{
    internal class BagItem<T>
    {
		#region Properties

		public T Item { get; set; }

		public float Weight { get; set; }

		#endregion //Properties

		#region Methods

		public BagItem(T item, float weight)
		{
			Item = item;
			Weight = weight;
		}

		#endregion //Methods
	}
}
