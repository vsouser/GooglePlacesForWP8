﻿#pragma checksum "C:\Users\Tokarew\Documents\GitHub\GooglePlacesForWP8\Places\Pages\ResultPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "32CC574A23BEEC8DF8818DEEEA5B5CBF"
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
using Microsoft.Phone.Maps.Controls;
using SlideView.Library;
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
    
    
    public partial class ResultPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal SlideView.Library.SlideView LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Controls.LongListSelector Places;
        
        internal Microsoft.Phone.Maps.Controls.Map map;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Places;component/Pages/ResultPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((SlideView.Library.SlideView)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Places = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("Places")));
            this.map = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("map")));
        }
    }
}

