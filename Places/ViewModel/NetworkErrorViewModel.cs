using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class NetworkErrorViewModel
    {

        public NetworkErrorViewModel()
        {
           
        }

        public void Navigate(Action onNavigationAction)
        {
            onNavigationAction();
        }
    }
}
