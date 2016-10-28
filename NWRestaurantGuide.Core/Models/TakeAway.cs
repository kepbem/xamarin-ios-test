using System;
using System.Collections.Generic;

namespace NWRestaurantGuide.Core
{
	public class TakeAway
	{
		public TakeAway()
		{
		}
		public int TakeAwayId
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

		public int Telephone
		{
			get;
			set;
		}

		//public bool Available
		//{
		//	get;
		//	set;
		//}

		//public int PrepTime
		//{
		//	get;
		//	set;
		//}

		public List<string> PopMenuItems
		{
			get;
			set;
		}

		//public bool IsFavorite
		//{
		//	get;
		//	set;
		//}

		public string GroupName
		{
			get;
			set;
		}
	}
}
