using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class ApiErrorViewModel : BaseErrorView
    {
        public ApiErrorViewModel()
        {

        }

        public override void Navigate(Action onNavigationAction)
        {
            onNavigationAction();
        }
    }
}