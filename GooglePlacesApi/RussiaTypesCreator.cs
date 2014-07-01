using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class RussiaTypesCreator
    {
        public List<Type> Create()
        {
            var list = new List<Type>();
            list.Add(CreateType(Types.ACCOUNTING, "Учет"));
            list.Add(CreateType(Types.AIRPORT, "Аэропорт"));
            list.Add(CreateType(Types.AMUSEMENT_PARK, "Парк с аттракционами"));
            list.Add(CreateType(Types.AQUARIUM, "Аквариум"));
            list.Add(CreateType(Types.ART_GALLERY, "Художественная галерея"));
            list.Add(CreateType(Types.ATM, "Банкомат"));
            list.Add(CreateType(Types.BAKERY, "Пекарня"));
            list.Add(CreateType(Types.BANK, "Банк"));
            list.Add(CreateType(Types.BAR, "Бар"));
            list.Add(CreateType(Types.BEAUTY_SALON, "Салон красоты"));
            list.Add(CreateType(Types.BICYCLE_STORE, "Велосипеды"));
            list.Add(CreateType(Types.BOOK_STORE, "Книжный магазин"));
            list.Add(CreateType(Types.BOWLING_ALLEY, "Боулинг"));
            list.Add(CreateType(Types.BUS_STATION, "Автовокзал "));
            list.Add(CreateType(Types.CAFE, "Кафе"));
            list.Add(CreateType(Types.CAMPGROUND, "Лагерь"));
            list.Add(CreateType(Types.CAR_DEALER, "Автодилер"));
            list.Add(CreateType(Types.CAR_RENTAL, "Прокат автомобилей"));
            list.Add(CreateType(Types.CAR_REPAIR, "Ремонт автомобилей"));
            list.Add(CreateType(Types.CAR_WASH, "Авто мойка"));
            list.Add(CreateType(Types.CASINO, "Казино"));
            list.Add(CreateType(Types.CEMETERY, "Кладбище"));
            list.Add(CreateType(Types.CHURCH, "Церковь"));
            list.Add(CreateType(Types.CITY_HALL, "Ратуша"));
            list.Add(CreateType(Types.CLOTHING_STORE, "Магазин одежды"));
            list.Add(CreateType(Types.CONVENIENCE_STORE, "Магазин"));
            list.Add(CreateType(Types.COURTHOUSE, "Здание суда"));
            list.Add(CreateType(Types.DENTIST, "Дантист"));
            list.Add(CreateType(Types.DEPARTMENT_STORE, "Универмаг"));
            list.Add(CreateType(Types.DOCTOR, "Врач"));
            list.Add(CreateType(Types.ELECTRICIAN, "Электрик"));
            list.Add(CreateType(Types.ELECTRONICS_STORE, "Магазин электроники"));
            list.Add(CreateType(Types.EMBASSY, "Посольство"));
            list.Add(CreateType(Types.ESTABLISHMENT, "Учреждение"));
            list.Add(CreateType(Types.FINANCE, "Финансы"));
            list.Add(CreateType(Types.FIRE_STATION, "Пожарное депо"));
            list.Add(CreateType(Types.FLORIST, "Флорист"));
            list.Add(CreateType(Types.FOOD, "Еда"));
            list.Add(CreateType(Types.FUNERAL_HOME, "Похоронного бюро"));
            list.Add(CreateType(Types.FURNITURE_STORE, "Мебельный магазин"));
            list.Add(CreateType(Types.GAS_STATION, "АЗС"));
            list.Add(CreateType(Types.GENERAL_CONTRACTOR, "Генеральный подрядчик"));
            list.Add(CreateType(Types.GROCERY_OR_SUPERMARKET, "Продуктовый или супермаркет"));
            list.Add(CreateType(Types.GYM, "Тренажерный зал"));
            list.Add(CreateType(Types.HAIR_CARE, "Парикмахерская"));
            list.Add(CreateType(Types.HARDWARE_STORE, "Магазин бытовой техники"));
            list.Add(CreateType(Types.HEALTH, "Здоровье"));
            list.Add(CreateType(Types.HINDU_TEMPLE, "Индуистский храм"));
            list.Add(CreateType(Types.HOME_GOODS_STORE, "Товары для дома"));
            list.Add(CreateType(Types.HOSPITAL, "Больница"));
            list.Add(CreateType(Types.INSURANCE_AGENCY, "Cтраховое агентство"));
            list.Add(CreateType(Types.JEWELRY_STORE, "Ювелирный магазин"));
            list.Add(CreateType(Types.LAUNDRY, "Прачечная"));
            list.Add(CreateType(Types.LAWYER, "Адвокат"));
            list.Add(CreateType(Types.LIBRARY, "Библиотека"));
            list.Add(CreateType(Types.LIQUOR_STORE, "Винный магазин"));
            list.Add(CreateType(Types.LOCAL_GOVERNMENT_OFFICE, "Местная администрация"));
            list.Add(CreateType(Types.LOCKSMITH, "Слесарь"));
            list.Add(CreateType(Types.LODGING, "Жилье"));
            list.Add(CreateType(Types.MEAL_DELIVERY, "Доставка еды"));
            list.Add(CreateType(Types.MEAL_TAKEAWAY, "Еда на вынос"));
            list.Add(CreateType(Types.MOSQUE, "Мечеть"));
            list.Add(CreateType(Types.MOVIE_RENTAL, "Аренда фильмов"));
            list.Add(CreateType(Types.MOVIE_THEATER, "Кинотеатр"));
            list.Add(CreateType(Types.MOVING_COMPANY, "Транспортная компания"));
            list.Add(CreateType(Types.MUSEUM, "Музей"));
            list.Add(CreateType(Types.NIGHT_CLUB, "Ночной клуб"));
            list.Add(CreateType(Types.PAINTER, "Художник"));
            list.Add(CreateType(Types.PARK, "Парк"));
            list.Add(CreateType(Types.PARKING, "Парковка"));
            list.Add(CreateType(Types.PET_STORE, "Зоомагазин"));
            list.Add(CreateType(Types.PHARMACY, "Аптека"));
            list.Add(CreateType(Types.PHYSIOTHERAPIST, "Физиотерапевт"));
            list.Add(CreateType(Types.PLACE_OF_WORSHIP, "Место поклонения"));
            list.Add(CreateType(Types.PLUMBER, "Водопроводчик"));
            list.Add(CreateType(Types.POLICE, "Полиция"));
            list.Add(CreateType(Types.POST_OFFICE, "Почта"));
            list.Add(CreateType(Types.REAL_ESTATE_AGENCY, "Агентство недвижимости"));
            list.Add(CreateType(Types.RESTAURANT, "Ресторан"));
            list.Add(CreateType(Types.ROOFING_CONTRACTOR, "Кровельный подрядчик"));
            list.Add(CreateType(Types.RV_PARK, "RV Park"));
            list.Add(CreateType(Types.SCHOOL, "Школа"));
            list.Add(CreateType(Types.SHOE_STORE, "Обувной магазин"));
            list.Add(CreateType(Types.SHOPPING_MALL, "Торговый центр"));
            list.Add(CreateType(Types.SPA, "Спа"));
            list.Add(CreateType(Types.STADIUM, "Стадион"));
            list.Add(CreateType(Types.STORAGE, "Склады и хранилища"));
            list.Add(CreateType(Types.STORE, "Магазин"));
            list.Add(CreateType(Types.SUBWAY_STATION, "Станция метро"));
            list.Add(CreateType(Types.SYNAGOGUE, "Синагога"));
            list.Add(CreateType(Types.TAXI_STAND, "Стоянка такси"));
            list.Add(CreateType(Types.TRAIN_STATION, "Железнодорожный вокзал и странции"));
            list.Add(CreateType(Types.TRAVEL_AGENCY, "Турагентство"));
            list.Add(CreateType(Types.UNIVERSITY, "Университет"));
            list.Add(CreateType(Types.VETERINARY_CARE, "Ветеринарная помощь"));
            list.Add(CreateType(Types.ZOO, "Зоопарк"));
            return list;
        }


        protected Type CreateType(string key, string name)
        {
            return new Type() { Key = key, Name = name };
        }
    }
}
