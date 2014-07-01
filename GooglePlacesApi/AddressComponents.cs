using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class AddressComponents
    {
        public string Long_name { get; set;}
        public string Short_name { get; set;}
        public List<string> Types { get; set;}  
    }
}
