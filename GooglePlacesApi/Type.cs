using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class Type : BaseMultiSelect, IComparable
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }


        public int CompareTo(object obj)
        {
            Type c = (Type)obj;
            return String.Compare(this.Name, c.Name);
        }
    }
}
