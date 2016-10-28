using System;
using System.Collections.Generic;

namespace NWRestaurantGuide.Core
{
	public class Restaurant
	{
		public Restaurant()
		{
		}
		public int RestaurantId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string ShortDescription
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public string Telephone
		{
			get;
			set;
		}
		public string Website
		{
			get;
			set;
		}

		public List<string> PopMenuItems
		{
			get;
			set;
		}

		public string GroupName
		{
			get;
			set;
		}
	}
}
