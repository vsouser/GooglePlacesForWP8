using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class Place
    {
        public List<Event> Events { get; set; }
        public string Icon { get; set; }
        public string Id { get; set; }
        public string Place_id { get; set; }
        public Geometry Geometry { get; set; }
        public string Name { get; set; }
        public OpenNow Opening_hours { get; set; }
        public List<Photo> Photos { get; set; }
        public string Price_level { get; set; }
        public string Rating { get; set; }
        public string Reference { get; set;}
        public string[] Types { get; set; }
        public string Vicinity { get; set; }
        public string Formatted_address { get; set; }
    }

    class PlaceConverter : CustomCreationConverter<Place>
    {
        public override Place Create(System.Type objectType)
        {
            return new Place();
        }
    }
}
