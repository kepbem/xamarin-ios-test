using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NWRestaurantGuide.Core
{
	public class DerryRestaurantRepository
	{
		string url = "http://creativedevelopmentni.com/testvoucher/DerryRestaurants.json";

		public DerryRestaurantRepository()
		{
			Task.Run(() => this.LoadDataAsync(url)).Wait();
		}
		public List<Restaurant> GetAllRestaurants()
		{
			IEnumerable<Restaurant> restaurants =
				from restaurantGroup in restaurantGroups
				from restaurant in restaurantGroup.Restaurants

				select restaurant;
			return restaurants.ToList<Restaurant>();
		}
		public List<RestaurantGroup> GetGroupedRestaurants()
		{
			return restaurantGroups;
		}

		public List<Restaurant> GetRestaurantsForGroup(int restaurantGroupId)
		{
			var group = restaurantGroups.Where(h => h.RestaurantGroupId == restaurantGroupId).FirstOrDefault();

			if (group != null)
			{
				return group.Restaurants;
			}
			return null;
		}
		public Restaurant GetRestaurantById(int restaurantId)
		{
			IEnumerable<Restaurant> restaurants =
				from restaurantGroup in restaurantGroups
				from restaurant in restaurantGroup.Restaurants
				where restaurant.RestaurantId == restaurantId
				select restaurant;

			return restaurants.FirstOrDefault();
		}


		private static List<RestaurantGroup> restaurantGroups = new List<RestaurantGroup>();

		private async Task LoadDataAsync(string uri)
		{
			if (restaurantGroups != null)
			{
				string responseJsonString = null;

				using (var httpClient = new HttpClient())
				{
					try
					{
						Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

						HttpResponseMessage response = await getResponse;

						responseJsonString = await response.Content.ReadAsStringAsync();
					}
					catch (Exception ex)
					{
						//handle any errors here, not part of the sample app
						string message = ex.Message;
					}
				}

				restaurantGroups = JsonConvert.DeserializeObject<List<RestaurantGroup>>(responseJsonString);
			}
		}
	}
}






