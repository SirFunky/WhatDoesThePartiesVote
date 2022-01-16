using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatDoesThePartiesVote
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

        }

        public static Voting VoteModel { get; set; } = new Voting();

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
