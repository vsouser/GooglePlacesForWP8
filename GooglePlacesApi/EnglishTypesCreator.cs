using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class EnglishTypesCreator
    {
        public List<Type> Create()
        {
            var list = new List<Type>();
            list.Add(CreateType(Types.ACCOUNTING, "Accounting"));
            list.Add(CreateType(Types.AIRPORT, "Airport"));
            list.Add(CreateType(Types.AMUSEMENT_PARK, "Amusement park"));
            list.Add(CreateType(Types.AQUARIUM, "Aquarium"));
            list.Add(CreateType(Types.ART_GALLERY, "Art gallery"));
            list.Add(CreateType(Types.ATM, "Atm"));
            list.Add(CreateType(Types.BAKERY, "Bakery"));
            list.Add(CreateType(Types.BANK, "Bank"));
            list.Add(CreateType(Types.BAR, "Bar"));
            list.Add(CreateType(Types.BEAUTY_SALON, "Beauty salon"));
            list.Add(CreateType(Types.BICYCLE_STORE, "Bicycle store"));
            list.Add(CreateType(Types.BOOK_STORE, "Book store"));
            list.Add(CreateType(Types.BOWLING_ALLEY, "Bowling alley"));
            list.Add(CreateType(Types.BUS_STATION, "Bus station"));
            list.Add(CreateType(Types.CAFE, "Cafe"));
            list.Add(CreateType(Types.CAMPGROUND, "Campground"));
            list.Add(CreateType(Types.CAR_DEALER, "Car dealer"));
            list.Add(CreateType(Types.CAR_RENTAL, "Car rental"));
            list.Add(CreateType(Types.CAR_REPAIR, "Car repair"));
            list.Add(CreateType(Types.CAR_WASH, "Сar wash"));
            list.Add(CreateType(Types.CASINO, "Сasino"));
            list.Add(CreateType(Types.CEMETERY, "Сemetery"));
            list.Add(CreateType(Types.CHURCH, "Сhurch"));
            list.Add(CreateType(Types.CITY_HALL, "Сity hall"));
            list.Add(CreateType(Types.CLOTHING_STORE, "Сlothing store"));
            list.Add(CreateType(Types.CONVENIENCE_STORE, "Сonvenience store"));
            list.Add(CreateType(Types.COURTHOUSE, "Сourthouse"));
            list.Add(CreateType(Types.DENTIST, "Dentist"));
            list.Add(CreateType(Types.DEPARTMENT_STORE, "Department store"));
            list.Add(CreateType(Types.DOCTOR, "Doctor"));
            list.Add(CreateType(Types.ELECTRICIAN, "Electrician"));
            list.Add(CreateType(Types.ELECTRONICS_STORE, "Electronics store"));
            list.Add(CreateType(Types.EMBASSY, "Embassy"));
            list.Add(CreateType(Types.ESTABLISHMENT, "Establishment"));
            list.Add(CreateType(Types.FINANCE, "Finance"));
            list.Add(CreateType(Types.FIRE_STATION, "Fire stationо"));
            list.Add(CreateType(Types.FLORIST, "Florist"));
            list.Add(CreateType(Types.FOOD, "Food"));
            list.Add(CreateType(Types.FUNERAL_HOME, "Funeral home"));
            list.Add(CreateType(Types.FURNITURE_STORE, "Furniture store"));
            list.Add(CreateType(Types.GAS_STATION, "Gas station"));
            list.Add(CreateType(Types.GENERAL_CONTRACTOR, "General contractor"));
            list.Add(CreateType(Types.GROCERY_OR_SUPERMARKET, "Grocery or supermarket"));
            list.Add(CreateType(Types.GYM, "Gym"));
            list.Add(CreateType(Types.HAIR_CARE, "Hair care"));
            list.Add(CreateType(Types.HARDWARE_STORE, "Hardware store"));
            list.Add(CreateType(Types.HEALTH, "Health"));
            list.Add(CreateType(Types.HINDU_TEMPLE, "Hindu temple"));
            list.Add(CreateType(Types.HOME_GOODS_STORE, "Home goods store"));
            list.Add(CreateType(Types.HOSPITAL, "Hospital"));
            list.Add(CreateType(Types.INSURANCE_AGENCY, "Insurance agency"));
            list.Add(CreateType(Types.JEWELRY_STORE, "Jewelry store"));
            list.Add(CreateType(Types.LAUNDRY, "Laundry"));
            list.Add(CreateType(Types.LAWYER, "Lawyer"));
            list.Add(CreateType(Types.LIBRARY, "Library"));
            list.Add(CreateType(Types.LIQUOR_STORE, "Liquor store"));
            list.Add(CreateType(Types.LOCAL_GOVERNMENT_OFFICE, "Local government office"));
            list.Add(CreateType(Types.LOCKSMITH, "Locksmith"));
            list.Add(CreateType(Types.LODGING, "Lodging"));
            list.Add(CreateType(Types.MEAL_DELIVERY, "Meal delivery"));
            list.Add(CreateType(Types.MEAL_TAKEAWAY, "Meal takeaway"));
            list.Add(CreateType(Types.MOSQUE, "Mosque"));
            list.Add(CreateType(Types.MOVIE_RENTAL, "Movie rental"));
            list.Add(CreateType(Types.MOVIE_THEATER, "Movie theater"));
            list.Add(CreateType(Types.MOVING_COMPANY, "Moving company"));
            list.Add(CreateType(Types.MUSEUM, "Museum"));
            list.Add(CreateType(Types.NIGHT_CLUB, "Night club"));
            list.Add(CreateType(Types.PAINTER, "Painter"));
            list.Add(CreateType(Types.PARK, "Park"));
            list.Add(CreateType(Types.PARKING, "Parking"));
            list.Add(CreateType(Types.PET_STORE, "Pet store"));
            list.Add(CreateType(Types.PHARMACY, "Pharmacy"));
            list.Add(CreateType(Types.PHYSIOTHERAPIST, "Physiotherapist"));
            list.Add(CreateType(Types.PLACE_OF_WORSHIP, "Place of worship"));
            list.Add(CreateType(Types.PLUMBER, "Plumber"));
            list.Add(CreateType(Types.POLICE, "Police"));
            list.Add(CreateType(Types.POST_OFFICE, "Post office"));
            list.Add(CreateType(Types.REAL_ESTATE_AGENCY, "Real estate agency"));
            list.Add(CreateType(Types.RESTAURANT, "Restaurant"));
            list.Add(CreateType(Types.ROOFING_CONTRACTOR, "Roofing contractor"));
            list.Add(CreateType(Types.RV_PARK, "Rv park"));
            list.Add(CreateType(Types.SCHOOL, "School"));
            list.Add(CreateType(Types.SHOE_STORE, "Shoe store"));
            list.Add(CreateType(Types.SHOPPING_MALL, "Shopping mall"));
            list.Add(CreateType(Types.SPA, "Spa"));
            list.Add(CreateType(Types.STADIUM, "Stadium"));
            list.Add(CreateType(Types.STORAGE, "Storage"));
            list.Add(CreateType(Types.STORE, "Store"));
            list.Add(CreateType(Types.SUBWAY_STATION, "Subway stationо"));
            list.Add(CreateType(Types.SYNAGOGUE, "Synagogue"));
            list.Add(CreateType(Types.TAXI_STAND, "Taxi stand"));
            list.Add(CreateType(Types.TRAIN_STATION, "Train station"));
            list.Add(CreateType(Types.TRAVEL_AGENCY, "Travel agency"));
            list.Add(CreateType(Types.UNIVERSITY, "University"));
            list.Add(CreateType(Types.VETERINARY_CARE, "Veterinary care"));
            list.Add(CreateType(Types.ZOO, "Zoo"));
            return list;
        }


        protected Type CreateType(string key, string name)
        {
            return new Type() { Key = key, Name = name };
        }

    }
}
