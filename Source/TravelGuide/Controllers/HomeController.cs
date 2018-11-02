using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;


namespace TravelGuide.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Home
        public const int PAGE_SIZE = 4;
        public const int PAGE_NUMBER = 1;
        TravelGuideDBContext dbContext = new TravelGuideDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public PartialViewResult GetHotels()
        {
            var hotel = from t in dbContext.HOTELs
                        select t;
            hotel = hotel.Where(s => s.QUALITY_HOTEL >=8 && s.AVAILABLE == true);
            return PartialView(hotel.ToList().Take(10));
        }
        public PartialViewResult GetTravels()
        {
            var travel = from t in dbContext.TRAVELs
                             select t;
            travel = travel.Where(s => s.QUALITY_TRAVEL >= 8 && s.AVAILABLE == true);
            return PartialView(travel.ToList().Take(10));
        }
        public PartialViewResult GetRestaurants()
        {
            var restaurant = from t in dbContext.RESTAURANTs
                        select t;
            restaurant = restaurant.Where(s => s.QUALITY_RESTAURANT >= 8 && s.AVAILABLE == true);
            return PartialView(restaurant.ToList().Take(10));
        }
        public PartialViewResult GetTouristSpot()
        {
            var tour = from t in dbContext.TOURIST_SPOTS
                         select t;
            tour = tour.Where(s => s.QUALITY_TOURISTSPOT >= 8);
            return PartialView(tour.ToList().Take(10));
        }
        public PartialViewResult GetResort()
        {
            var resort = from t in dbContext.RESORTs
                        select t;
            resort = resort.Where(s => s.QUALITY_RESORT >= 8 && s.AVAILABLE == true);
            return PartialView(resort.ToList().Take(10));
        }

        public PartialViewResult ShowAllTouristSpot(string currentFilter, string searchString, int? page, 
            string city, int? quality)
        {
            if (searchString != null || city != null
                || quality != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentCity = city;
            ViewBag.CurrentQuality = quality;

            var tourSpot = from t in dbContext.TOURIST_SPOTS
                           select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tourSpot = tourSpot.Where(s => s.NAME_TOURISTSPOT.Contains(searchString)
                                || s.DES_TOURIST_SPOTS.Contains(searchString)
                                || s.INTRODUCE_TOURIST_SPOTS.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(city))
            {
                tourSpot = tourSpot.Where(s => s.ID_CITY == city);
            }
            if (quality != null)
            {
                tourSpot = tourSpot.Where(s => s.QUALITY_TOURISTSPOT == quality);
            }
            ViewData["Cities"] = getCities();
            int pageNumber = (page ?? PAGE_NUMBER);
            return PartialView(tourSpot.OrderBy(i => i.ID_TOURISTSPOT).ToPagedList(pageNumber, PAGE_SIZE));
        }


        public PartialViewResult ShowAllHotel(string currentFilter, string searchString, int? page,
            string city, bool? isAvailable, int? quality, int? minPrice, int? maxPrice, bool? isDiscount)
        {
            
            if (searchString != null || city !=null 
                || isAvailable != null || quality != null 
                || minPrice != null || maxPrice != null || isDiscount != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentCity = city;
            ViewBag.CurrentAvailable = isAvailable;
            ViewBag.CurrentQuality = quality;
            ViewBag.CurrentMinPrice = minPrice;
            ViewBag.CurrentMaxPrice = maxPrice;
            ViewBag.CurrentDiscount = isDiscount;

            var hotel = from t in dbContext.HOTELs
                           select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                hotel = hotel.Where(s => s.NAME_HOTEL.Contains(searchString)
                                || s.DES_HOTEL.Contains(searchString)
                                || s.INTRODUCE_HOTEL.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(city))
            {
                hotel = hotel.Where(s => s.ID_CITY == city);
            }
            if (isAvailable == true)
            {
                hotel = hotel.Where(s => s.AVAILABLE== isAvailable);
            }
            if (quality != null)
            {
                hotel = hotel.Where(s => s.QUALITY_HOTEL== quality);
            }
            if (minPrice != null && maxPrice != null)
            {
                hotel = hotel.Where(s => s.PRICE_HOTEL <= maxPrice && s.PRICE_HOTEL >= minPrice);
            }
            if (isDiscount == true)
            {
                hotel = hotel.Where(s => s.ISDISCOUNT_HOTEL== isDiscount);
            }

            ViewData["Cities"] = getCities();

            int pageNumber = (page ?? PAGE_NUMBER);
            return PartialView(hotel.OrderBy(i => i.ID_HOTEL).ToPagedList(pageNumber, PAGE_SIZE));
        }
        public PartialViewResult ShowAllRestaurant(string currentFilter, string searchString, int? page,
                    string city, bool? isAvailable, int? quality, int? minPrice, int? maxPrice, bool? isDiscount)
        {
            if (searchString != null || city != null
                || isAvailable != null || quality != null
                || minPrice != null || maxPrice != null || isDiscount != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentCity = city;
            ViewBag.CurrentAvailable = isAvailable;
            ViewBag.CurrentQuality = quality;
            ViewBag.CurrentMinPrice = minPrice;
            ViewBag.CurrentMaxPrice = maxPrice;
            ViewBag.CurrentDiscount = isDiscount;

            var restaurant = from t in dbContext.RESTAURANTs
                             select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                restaurant = restaurant.Where(s => s.NAME_RESTAURANT.Contains(searchString)
                                || s.DES_RESTAURANT.Contains(searchString)
                                || s.INTRODUCE_RESTAURANT.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(city))
            {
                restaurant = restaurant.Where(s => s.ID_CITY == city);
            }
            if (isAvailable == true)
            {
                restaurant = restaurant.Where(s => s.AVAILABLE == isAvailable);
            }
            if (quality != null)
            {
                restaurant = restaurant.Where(s => s.QUALITY_RESTAURANT == quality);
            }
            if (minPrice != null && maxPrice != null)
            {
                restaurant = restaurant.Where(s => s.PRICE_RESTAURANT <= maxPrice && s.PRICE_RESTAURANT >= minPrice);
            }
            if (isDiscount == true)
            {
                restaurant = restaurant.Where(s => s.ISDISCOUNT_RES == isDiscount);
            }

            ViewData["Cities"] = getCities();

            int pageNumber = (page ?? PAGE_NUMBER);
            return PartialView(restaurant.OrderBy(i => i.ID_RESTAURANT).ToPagedList(pageNumber, PAGE_SIZE));
        }
        public PartialViewResult ShowAllResort(string currentFilter, string searchString, int? page,
            string city, bool? isAvailable, int? quality, int? minPrice, int? maxPrice, bool? isDiscount)
        {
            if (searchString != null || city != null
                || isAvailable != null || quality != null
                || minPrice != null || maxPrice != null || isDiscount != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentCity = city;
            ViewBag.CurrentAvailable = isAvailable;
            ViewBag.CurrentQuality = quality;
            ViewBag.CurrentMinPrice = minPrice;
            ViewBag.CurrentMaxPrice = maxPrice;
            ViewBag.CurrentDiscount = isDiscount;

            var resort = from t in dbContext.RESORTs
                         select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                resort = resort.Where(s => s.NAME_RESORT.Contains(searchString)
                                || s.DES_RESORT.Contains(searchString)
                                || s.INTRODUCE_RESORT.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(city))
            {
                resort = resort.Where(s => s.ID_CITY == city);
            }
            if (isAvailable == true)
            {
                resort = resort.Where(s => s.AVAILABLE == isAvailable);
            }
            if (quality != null)
            {
                resort = resort.Where(s => s.QUALITY_RESORT == quality);
            }
            if (minPrice != null && maxPrice != null)
            {
                resort = resort.Where(s => s.PRICE_RESORT <= maxPrice && s.PRICE_RESORT >= minPrice);
            }
            if (isDiscount == true)
            {
                resort = resort.Where(s => s.ISDISCOUNT_RESORT == isDiscount);
            }

            ViewData["Cities"] = getCities();

            int pageNumber = (page ?? PAGE_NUMBER);
            return PartialView(resort.OrderBy(i => i.ID_RESORT).ToPagedList(pageNumber, PAGE_SIZE));
        }


        public PartialViewResult ShowAllTravel(string currentFilter, string searchString, int? page,
            string city, bool? isAvailable, int? quality, int? minPrice, int? maxPrice, bool? isDiscount)
        {
            if (searchString != null || city != null
                || isAvailable != null || quality != null
                || minPrice != null || maxPrice != null || isDiscount != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentCity = city;
            ViewBag.CurrentAvailable = isAvailable;
            ViewBag.CurrentQuality = quality;
            ViewBag.CurrentMinPrice = minPrice;
            ViewBag.CurrentMaxPrice = maxPrice;
            ViewBag.CurrentDiscount = isDiscount;

            var restaurant = from t in dbContext.TRAVELs
                             select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                restaurant = restaurant.Where(s => s.NAME_TRAVEL.Contains(searchString)
                                || s.DES_TRAVEL.Contains(searchString)
                                || s.INTRODUCE_TRAVEL.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(city))
            {
                restaurant = restaurant.Where(s => s.ID_CITY == city);
            }
            if (isAvailable == true)
            {
                restaurant = restaurant.Where(s => s.AVAILABLE == isAvailable);
            }
            if (quality != null)
            {
                restaurant = restaurant.Where(s => s.QUALITY_TRAVEL == quality);
            }
            if (minPrice != null && maxPrice != null)
            {
                restaurant = restaurant.Where(s => s.DISCOUNT_TRAVEL <= maxPrice && s.DISCOUNT_TRAVEL >= minPrice);
            }
            if (isDiscount == true)
            {
                restaurant = restaurant.Where(s => s.ISDISCOUNT_TRAVEL == isDiscount);
            }

            ViewData["Cities"] = getCities();

            int pageNumber = (page ?? PAGE_NUMBER);
            return PartialView(restaurant.OrderBy(i => i.ID_TRAVEL).ToPagedList(pageNumber, PAGE_SIZE));
        }

        public PartialViewResult DetailTouristSpot(int id)
        {
            var t = dbContext.TOURIST_SPOTS.Where(x => x.ID_TOURISTSPOT == id).FirstOrDefault();
            return PartialView(t);
        }

        public PartialViewResult DetailHotel(int id)
        {
            var t = dbContext.HOTELs.Where(x => x.ID_HOTEL == id).FirstOrDefault();
            return PartialView(t);
        }

        public PartialViewResult DetailRestaurant(int id)
        {
            var t = dbContext.RESTAURANTs.Where(x => x.ID_RESTAURANT == id).FirstOrDefault();
            return PartialView(t);
        }

        public PartialViewResult DetailResort(int id)
        {
            var t = dbContext.RESORTs.Where(x => x.ID_RESORT == id).FirstOrDefault();
            return PartialView(t);
        }

        public PartialViewResult DetailTravel(int id)
        {
            var t = dbContext.TRAVELs.Where(x => x.ID_TRAVEL == id).FirstOrDefault();
            return PartialView(t);
        }

        public List<CITY> getCities()
        {
            return dbContext.CITies.ToList();
        }


        public PartialViewResult test()
        {
            return PartialView();
        }
        
    }
}