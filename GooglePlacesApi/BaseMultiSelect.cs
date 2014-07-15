using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class BaseMultiSelect : GooglePlacesApi.NotifyPropertyBase, IMultiSelect
    {
        private bool select;

        public bool Select { get { return select; } set { SetProperty<bool>(ref select, value); } }
    }
}
