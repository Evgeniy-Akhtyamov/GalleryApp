﻿using GalleryApp.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalleryApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PinPage()); 
        }

        protected override void OnStart()
        {                   
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {            
        }
    }
}
