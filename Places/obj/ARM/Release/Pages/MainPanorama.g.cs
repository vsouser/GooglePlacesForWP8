﻿#pragma checksum "C:\Users\Tokarew\Documents\GitHub\GooglePlacesForWP8\Places\Pages\MainPanorama.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B5C66445292E91891CF1C408B7603603"
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
using Places.Helpers.Collections;
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
    
    
    public partial class MainPanorama : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.Panorama MainContainer;
        
        internal Microsoft.Phone.Controls.LongListSelector NerbyTile;
        
        internal System.Windows.Controls.TextBox Query;
        
        internal Microsoft.Phone.Controls.ListPicker Radius;
        
        internal Places.Helpers.Collections.LongListSelector Items;
        
        internal System.Windows.Controls.Button Search;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Places;component/Pages/MainPanorama.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.MainContainer = ((Microsoft.Phone.Controls.Panorama)(this.FindName("MainContainer")));
            this.NerbyTile = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("NerbyTile")));
            this.Query = ((System.Windows.Controls.TextBox)(this.FindName("Query")));
            this.Radius = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("Radius")));
            this.Items = ((Places.Helpers.Collections.LongListSelector)(this.FindName("Items")));
            this.Search = ((System.Windows.Controls.Button)(this.FindName("Search")));
        }
    }
}

