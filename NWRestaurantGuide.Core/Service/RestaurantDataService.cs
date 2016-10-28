using System;
using System.Collections.Generic;
using System.Linq;

namespace NWRestaurantGuide.Core
{
	public class RestaurantDataService
	{
		//private static DerryRestaurantRepository restaurantRepository = new DerryRestaurantRepository();
		private static RestaurantRepository restaurantRepository = new RestaurantRepository();

		public RestaurantDataService()
		{
		}

		public List<Restaurant> GetAllRestaurants()
		{
			return restaurantRepository.GetAllRestaurants();
		}

		public List<RestaurantGroup> GetGroupedRestaurants()
		{
			return restaurantRepository.GetGroupedRestaurants();
		}

		public List<Restaurant> GetRestaurantsForGroup(int restaurantGroupId)
		{
			return restaurantRepository.GetRestaurantsForGroup(restaurantGroupId);
		}

		public Restaurant GetrestaurantById(int restaurantId)
		{
			return restaurantRepository.GetRestaurantById(restaurantId);
		}

	}
}

