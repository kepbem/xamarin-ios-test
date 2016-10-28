using System;
using System.Collections.Generic;
using System.Linq;

namespace NWRestaurantGuide.Core
{
	public class RestaurantRepository
	{
		public RestaurantRepository()
		{
		}
		public List<Restaurant> GetAllRestaurants()
		{
			IEnumerable <Restaurant> restaurants =
				from restaurantGroup in restaurantGroups
				from restaurant in restaurantGroup.Restaurants

				select restaurant;
			return restaurants.ToList<Restaurant>();
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

		private static List<RestaurantGroup> restaurantGroups = new List<RestaurantGroup>()
		{
			new RestaurantGroup()
			{
				RestaurantGroupId = 1, Title = "Modern Irish", ImagePath = "", Restaurants = new List<Restaurant>()
				{
					new Restaurant()
					{
						RestaurantId = 1,
						Name = "Custom House",
						ShortDescription = "The magnificent views of the river Foyle and the Peace Bridge are equalled with ...",
						Description = "The Custom House is one of the iconic listed buildings on the banks of the Foyle, situated in the heart of the historic City. The building was bought by a local family in 2008 and converted into a three storey high – class restaurant. The stone arched entrance leads into a majestically decorated interior, chandeliers, artwork and sumptuous furnishings. The magnificent views of the river Foyle and the Peace Bridge are equalled with a high standard of food, with dishes such as salt and chilli squid or the ever popular crispy pork belly – the dauphinoise potatoes are a must. The building is as gracious now as when it was built and is a must on any tourists agenda.",
						ImagePath = "Restaurant1",
						PopMenuItems = new List<string>(){"Crispy Pork Belly", "Daube of beef", "Pan Fried Donegal Salmon"},
						Telephone = "+442871373366",
						Website = "https://www.google.com"
					},
					new Restaurant()
					{
						RestaurantId = 2,
						Name = "Da Vinci's Grill Room",
						ShortDescription = "Located within the stylish Da Vinci's Hotel, The Grillroom has established itsel",
						Description = "Located within the stylish Da Vinci's Hotel, The Grillroom has established itself as one of the city's most popular eateries. Since it opened its doors in 1992, this award-winning venue has continued to grow, not just in size, but also in popularity, with a discerning clientele who know just what they want in a good restaurant. Good taste combined with creative flavours set this menu apart. Dishes are served with enthusiasm and flair, and the efficient service team is always on hand to answer any questions you may have about the products. Feel free to walk around the wine-room where you'll find a choice unrivalled anywhere else, for those who want to indulge in the flavours of the world. The Grillroom does not disappoint – changing menus and wine lists ensure there is always a wide range of quality cuisine to suit every palate. And the night doesn't have to end when you've finished your meal. Next door to The Grillroom is a lively bar, with plenty of cosy nooks and crannies to enjoy a nightcap. ",
						ImagePath = "Restaurant2",
						PopMenuItems = new List<string>(){"Fishermans Pie", "Vegetable Lasagne", "Ground Chilli Beef Tacos"},
						Telephone = "+442871279111",
						Website = "www.google.com"
						//IsFavorite = false
					},
					new Restaurant()
					{
						RestaurantId = 3,
						Name = "Encore Brasserie",
						ShortDescription = "Encore Brasserie offers a unique in-theatre dining experience in the heart of the city.",
						Description = "Encore Brasserie offers a unique in-theatre dining experience in the heart of the Millennium Forum, and has already proven to be a class act for both local foodies and theatre-goers. As for location, this restaurant couldn't be any more convenient, situated smack bang in the shopping hub of the city, surrounded by local shops, businesses and handy parking. Encore is ideal for leisurely business lunches or a quick shopping break as well as pre-theatre meals. But its the quality of food that has already notched up a number of prestigious awards for the brasserie. The menu features classic dishes made up of the very best locally sourced products, such as Caesar Salad, and Seabass Santa Cruz. Any director knows setting the scene is key, and at Encore rich dark wood furnishings create a warm and intimate atmosphere, making it the perfect place to relax before curtain-up. ",
						ImagePath = "Restaurant3",
						PopMenuItems = new List<string>(){"Tempura of Hake", "Char Griled Rib Eye", "Italian style Sea bass"},
						Telephone = "+442871372492",
						Website = "www.google.com"
					}
				}
			},
			new RestaurantGroup()
			{
				RestaurantGroupId = 2, Title = "Asian Cuisine", ImagePath = "", Restaurants = new List<Restaurant>()
				{
					new Restaurant()
					{
						RestaurantId = 4,
						Name = "Mandarin Palace",
						ShortDescription = "The Mandarin Palace has long been a favourite eatery for Chinese food lovers",
						Description = "The Mandarin Palace has long been a favourite eatery for Chinese food lovers in the city, since it first opened its doors in 1989. The menu here is extensive with a wide range of appetising Asian cuisine on offer, as well as more familiar European fare for the slightly less adventurous. Start with aromatic crispy duck, savour the spice of the Singapore noodles and then soothe the tastebuds with a glass of wine from their world wine menu. Or why not try the popular banquets which provide authentic Chinese dishes with a wide spectrum of flavours.",
						ImagePath = "Restaurant1",
						PopMenuItems = new List<string>(){"Cantonese Sweet & Sour", "Special Chow Mein", "Kung po Chicken"},
						Telephone = "+442871373656",
						Website = "www.google.com"
					},
					new Restaurant()
					{
						RestaurantId = 5,
						Name = "Water Fortune",
						ShortDescription = "Based in the Waterside area of Derry, the Water Fortune has been satisfying Derry's growing appetite",
						Description = "Based in the Waterside area of Derry, the Water Fortune has been satisfying Derry's growing appetite for Asian cuisine for years, its popularity based on the sheer quality of food on offer. From the moment diners enter the premises they are enveloped in the atmosphere and warm hospitality of the Orient. Décor is traditional, with candles, flowers and water features, and service is friendly and efficient. There is always an understated buzz of conversation, and the clink of cutlery as diners make the most of the excellent menu selection and share from a range of dishes. Flavours are authentic and varied, with traditional food expertly prepared, and a whole host of more exotic flavours on offer. There is also a wide range of European style dishes to appeal to all palates.",
						ImagePath = "Restaurant1",
						PopMenuItems = new List<string>(){"Chicken Foo Yung", "Deep fried Chilli Chicken", "Singapore Beef or Chicken"},
						Telephone = "+442871341100",
						Website = "www.google.com"
					}
				
				}
			},
			new RestaurantGroup()
			{
				RestaurantGroupId = 3, Title = "Coffee Shops", ImagePath = "", Restaurants = new List<Restaurant>()
				{
					new Restaurant()
					{
						RestaurantId = 6,
						Name = "Mandarin Palace",
						ShortDescription = "The Mandarin Palace has long been a favourite eatery for Chinese food lovers",
						Description = "The Mandarin Palace has long been a favourite eatery for Chinese food lovers in the city, since it first opened its doors in 1989. The menu here is extensive with a wide range of appetising Asian cuisine on offer, as well as more familiar European fare for the slightly less adventurous. Start with aromatic crispy duck, savour the spice of the Singapore noodles and then soothe the tastebuds with a glass of wine from their world wine menu. Or why not try the popular banquets which provide authentic Chinese dishes with a wide spectrum of flavours.",
						ImagePath = "Restaurant1",
						PopMenuItems = new List<string>(){"Cantonese Sweet & Sour", "Special Chow Mein", "Kung po Chicken"},
						Telephone = "+442871373656",
						Website = "www.google.com"
					},
					new Restaurant()
					{
						RestaurantId = 7,
						Name = "Water Fortune",
						ShortDescription = "Based in the Waterside area of Derry, the Water Fortune has been satisfying Derry's growing appetite",
						Description = "Based in the Waterside area of Derry, the Water Fortune has been satisfying Derry's growing appetite for Asian cuisine for years, its popularity based on the sheer quality of food on offer. From the moment diners enter the premises they are enveloped in the atmosphere and warm hospitality of the Orient. Décor is traditional, with candles, flowers and water features, and service is friendly and efficient. There is always an understated buzz of conversation, and the clink of cutlery as diners make the most of the excellent menu selection and share from a range of dishes. Flavours are authentic and varied, with traditional food expertly prepared, and a whole host of more exotic flavours on offer. There is also a wide range of European style dishes to appeal to all palates.",
						ImagePath = "Restaurant1",
						PopMenuItems = new List<string>(){"Chicken Foo Yung", "Deep fried Chilli Chicken", "Singapore Beef or Chicken"},
						Telephone = "+442871341100",
						Website = "www.google.com"
					}

				}
			},
			new RestaurantGroup()
			{
				RestaurantGroupId = 4, Title = "Gastro Pubs", ImagePath = "", Restaurants = new List<Restaurant>()
				{
					new Restaurant()
					{
						RestaurantId = 8,
						Name = "Mandarin Palace",
						ShortDescription = "The Mandarin Palace has long been a favourite eatery for Chinese food lovers",
						Description = "The Mandarin Palace has long been a favourite eatery for Chinese food lovers in the city, since it first opened its doors in 1989. The menu here is extensive with a wide range of appetising Asian cuisine on offer, as well as more familiar European fare for the slightly less adventurous. Start with aromatic crispy duck, savour the spice of the Singapore noodles and then soothe the tastebuds with a glass of wine from their world wine menu. Or why not try the popular banquets which provide authentic Chinese dishes with a wide spectrum of flavours.",
						ImagePath = "Restaurant1",
						PopMenuItems = new List<string>(){"Cantonese Sweet & Sour", "Special Chow Mein", "Kung po Chicken"},
						Telephone = "+442871373656",
						Website = "www.google.com"
					},
					new Restaurant()
					{
						RestaurantId = 9,
						Name = "Water Fortune",
						ShortDescription = "Based in the Waterside area of Derry, the Water Fortune has been satisfying Derry's growing appetite",
						Description = "Based in the Waterside area of Derry, the Water Fortune has been satisfying Derry's growing appetite for Asian cuisine for years, its popularity based on the sheer quality of food on offer. From the moment diners enter the premises they are enveloped in the atmosphere and warm hospitality of the Orient. Décor is traditional, with candles, flowers and water features, and service is friendly and efficient. There is always an understated buzz of conversation, and the clink of cutlery as diners make the most of the excellent menu selection and share from a range of dishes. Flavours are authentic and varied, with traditional food expertly prepared, and a whole host of more exotic flavours on offer. There is also a wide range of European style dishes to appeal to all palates.",
						ImagePath = "Restaurant1",
						PopMenuItems = new List<string>(){"Chicken Foo Yung", "Deep fried Chilli Chicken", "Singapore Beef or Chicken"},
						Telephone = "+442871341100",
						Website = "www.google.com"
					}

				}
			}
		};

	}
}
