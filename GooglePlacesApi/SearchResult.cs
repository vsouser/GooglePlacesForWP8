using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class SearchResult
    {
        public string Format { get; set; }
        public string[] Html_attributions { get; set; }
        public string Next_page_token { get; set; }
        public string[] Results { get; set; }
        public string Status { get; set; }
    }
}
