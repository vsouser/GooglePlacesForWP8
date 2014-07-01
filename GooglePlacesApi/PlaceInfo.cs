using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class PlaceInfo
    {
        public List<AddressComponents> Address_components { get; set; }
        public List<Event> Events { get; set; }
        public string Formatted_address { get; set; }
        public string Formatted_phone_number { get; set; }
        public Geometry Geometry { get; set; }
        public string Icon { get; set; }
        public string Id { get; set; }
        public string International_phone_number { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Reference { get; set; }
        public List<Review> Reviews { get; set; }
        public List<string> Types { get; set; }
        public string Url { get; set; }
        public string Vicinity { get; set; }
        public string Website { get; set; }
    }

    class PlaceInfoConverter : CustomCreationConverter<PlaceInfo>
    {
        public override PlaceInfo Create(System.Type objectType)
        {
            return new PlaceInfo();
        }
    }
}
