using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class LanguageController
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public LanguageController()
        {
            dictionary.Add("Arabic", Language.ARABIC);
            dictionary.Add("Basque", Language.BASQUE);
            dictionary.Add("Bulgarian", Language.BULGARIAN);
            dictionary.Add("Danish", Language.DANISH);
            dictionary.Add("Finnish", Language.FINNISH);
            dictionary.Add("Filipino", Language.FILIPINO);
            dictionary.Add("French", Language.FRENCH);
            dictionary.Add("Russian", Language.RUSSIAN);
            dictionary.Add("Romanian", Language.ROMANIAN);
            dictionary.Add("Portuguese", Language.PORTUGUESE);
            dictionary.Add("Polish", Language.POLISH);
            dictionary.Add("English", Language.ENGLISH);
            dictionary.Add("Galician", Language.GALICIAN);
            dictionary.Add("German", Language.GERMAN);
            dictionary.Add("Greek", Language.GREEK);
            dictionary.Add("Hindi", Language.HINDI);
            dictionary.Add("Hungarian", Language.HUNGARIAN);
            dictionary.Add("Indonesian", Language.INDONESIAN);
            dictionary.Add("Italian", Language.ITALIAN);
            dictionary.Add("Japanese", Language.JAPANESE);
            dictionary.Add("Korean", Language.KOREAN);
            dictionary.Add("Latvian", Language.LATVIAN);
            dictionary.Add("Lithuanian", Language.LITHUANIAN);
            dictionary.Add("Serbian", Language.SERBIAN);
            dictionary.Add("Thai", Language.THAI);
            dictionary.Add("Turkish", Language.TURKISH);
            dictionary.Add("Swedish", Language.SWEDISH);
            dictionary.Add("Vietnamese", Language.VIETNAMESE);
            dictionary.Add("Ukrainian", Language.UKRAINIAN);
            dictionary.Add("Vietnamese", Language.VIETNAMESE);

        }

        public string GetGooglePlacesLanguage()
        {
            try
            {
                var cultures = CultureInfo.CurrentCulture.EnglishName.Split(' ');
                return dictionary[cultures[0]];
            }
            catch
            {
                return Language.ENGLISH;
            }
        }
    }
}
