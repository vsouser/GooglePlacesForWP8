﻿#pragma checksum "C:\Users\andre_000\Documents\GitHub\GooglePlacesForWP8\Places\Pages\NetworkError.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0ED53355F60AEB8008184E0C4763A4A5"
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
using Microsoft.Phone.Shell;
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
    
    
    public partial class NetworkError : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton Repeat;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton WiFi;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton Cell;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton Airplane;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Places;component/Pages/NetworkError.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.Repeat = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("Repeat")));
            this.WiFi = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("WiFi")));
            this.Cell = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("Cell")));
            this.Airplane = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("Airplane")));
        }
    }
}

