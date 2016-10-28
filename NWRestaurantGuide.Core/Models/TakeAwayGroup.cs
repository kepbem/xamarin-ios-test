using System;
using System.Collections.Generic;

namespace NWRestaurantGuide.Core
{
	public class TakeAwayGroup
	{
		public TakeAwayGroup()
		{
		}
		public int TakeAwayGroupId
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public List<TakeAway> TakeAways
		{
			get;
			set;
		}
	}
}
