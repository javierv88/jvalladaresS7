﻿using jvalladaresS7.Services;
using jvalladaresS7.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace jvalladaresS7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.Login());
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
