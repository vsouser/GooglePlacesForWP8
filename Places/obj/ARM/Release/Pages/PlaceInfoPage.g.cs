﻿#pragma checksum "C:\Users\andre_000\Documents\GitHub\GooglePlacesForWP8\Places\Pages\PlaceInfoPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "494788AF7975F9D56D96E984C20BE3BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34014
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Places.Pages {
    
    
    public partial class PlaceInfoPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Pivot Pivots;
        
        internal System.Windows.Controls.Button FormatNumber;
        
        internal System.Windows.Controls.Button InternationalNumber;
        
        internal Microsoft.Phone.Controls.PivotItem Reviews;
        
        internal Microsoft.Phone.Controls.PivotItem Events;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Places;component/Pages/PlaceInfoPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Pivots = ((Microsoft.Phone.Controls.Pivot)(this.FindName("Pivots")));
            this.FormatNumber = ((System.Windows.Controls.Button)(this.FindName("FormatNumber")));
            this.InternationalNumber = ((System.Windows.Controls.Button)(this.FindName("InternationalNumber")));
            this.Reviews = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Reviews")));
            this.Events = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("Events")));
        }
    }
}
