using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class Photo
    {
        public string Photo_reference { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string[] Html_attributions { get; set; }
    }
}
