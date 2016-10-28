using System;
using System.Collections.Generic;

namespace NWRestaurantGuide.Core
{
	public class RestaurantGroup
	{
		public RestaurantGroup()
		{
		}
		public int RestaurantGroupId
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

		public List<Restaurant> Restaurants
		{
			get;
			set;
		}
	}
}
