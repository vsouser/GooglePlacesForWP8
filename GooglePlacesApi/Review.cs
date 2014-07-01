using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class Review
    {
        public List<Aspect> Aspects { get; set; }
        public string Author_name { get; set; }
        public string Author_url { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
    }
}
