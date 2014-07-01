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

        public TypesController(string language)
        {
            this.language = language;
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

        public void GetTypes()
        {
            switch(language)
            {
                case Language.ENGLISH :
                    EnglishTypesCreator englishTypesCreator = new EnglishTypesCreator();
                    types = englishTypesCreator.Create();
                    break;
                case Language.RUSSIAN :
                    RussiaTypesCreator russianTypesCreator = new RussiaTypesCreator();
                    types = russianTypesCreator.Create();
                    break;
                default:
                    EnglishTypesCreator defaultTypesCreator = new EnglishTypesCreator();
                    types = defaultTypesCreator.Create();
                    break;
            }
        }
    }
}
