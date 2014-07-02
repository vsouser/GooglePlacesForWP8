using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class TypesController : NotifyPropertyBase
    {
        private string language;
        private List<Type> types;
        private List<Type> require;

        public TypesController(string language)
        {
            this.language = language;
            types = new List<Type>();
            require = new List<Type>();
        }

        public List<Type> Types
        {
            get
            {
                return types;
            }
            set
            {
                SetProperty<List<Type>>(ref types, value);
            }
        }

        public List<Type> Require
        {
            get
            {
                return require;
            }
            set
            {
                SetProperty<List<Type>>(ref require, value);
            }
        }

        private Type GetType(string key)
        {
            return Types.Find(pr => pr.Key == key);
        }

        private void GetRequired()
        {
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.PHARMACY).CreateType(), Name = GetType(GooglePlacesApi.Types.PHARMACY).Name, Image = "/Assets/Tiles/Icon/Health.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.GAS_STATION).CreateType(), Name = GetType(GooglePlacesApi.Types.GAS_STATION).Name, Image = "/Assets/Tiles/Icon/Station.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.CAR_REPAIR).CreateType(), Name = GetType(GooglePlacesApi.Types.CAR_REPAIR).Name, Image = "/Assets/Tiles/Icon/CarService.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.ATM).CreateType(), Name = GetType(GooglePlacesApi.Types.ATM).Name, Image = "/Assets/Tiles/Icon/ATM.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.BAR).CreateType(), Name = GetType(GooglePlacesApi.Types.BAR).Name, Image = "/Assets/Tiles/Icon/Bar.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.BANK).CreateType(), Name = GetType(GooglePlacesApi.Types.BANK).Name, Image = "/Assets/Tiles/Icon/Bank.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.HOSPITAL, GooglePlacesApi.Types.DOCTOR).CreateType(), Name = GetType(GooglePlacesApi.Types.HOSPITAL).Name, Image = "/Assets/Tiles/Icon/Hospital.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.LODGING).CreateType(), Name = GetType(GooglePlacesApi.Types.LODGING).Name, Image = "/Assets/Tiles/Icon/Hotel.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.MOVIE_THEATER).CreateType(), Name = GetType(GooglePlacesApi.Types.MOVIE_THEATER).Name, Image = "/Assets/Tiles/Icon/Movie.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.MEAL_DELIVERY, GooglePlacesApi.Types.MEAL_TAKEAWAY, GooglePlacesApi.Types.FOOD, GooglePlacesApi.Types.RESTAURANT, GooglePlacesApi.Types.GROCERY_OR_SUPERMARKET, GooglePlacesApi.Types.CAFE, GooglePlacesApi.Types.DEPARTMENT_STORE).CreateType(), Name = GetType(GooglePlacesApi.Types.FOOD).Name, Image = "/Assets/Tiles/Icon/Restaurant.png" });
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.POLICE).CreateType(), Name = GetType(GooglePlacesApi.Types.POLICE).Name, Image = "/Assets/Tiles/Icon/Police.png" }); 
            Require.Add(new Type() { Key = new TypesFactory(GooglePlacesApi.Types.OTHER).CreateType(), Name = GetType(GooglePlacesApi.Types.OTHER).Name, Image = "/Assets/Tiles/Icon/FindOther.png" });
        }

        public void Instance()
        {
            switch(language)
            {
                case Language.ENGLISH :
                    EnglishTypesCreator englishTypesCreator = new EnglishTypesCreator();
                    Types = englishTypesCreator.Create();
                    break;
                case Language.RUSSIAN :
                    RussiaTypesCreator russianTypesCreator = new RussiaTypesCreator();
                    Types = russianTypesCreator.Create();
                    break;
                default:
                    EnglishTypesCreator defaultTypesCreator = new EnglishTypesCreator();
                    Types = defaultTypesCreator.Create();
                    break;
            }

            GetRequired();
        }
    }
}
