﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.ViewModel
{
    public class GeoLocationErrorViewModel : BaseErrorView
    {
        public GeoLocationErrorViewModel()
        {

        }

        public override void Navigate(Action onNavigationAction)
        {
            onNavigationAction();
        }
    }
}
