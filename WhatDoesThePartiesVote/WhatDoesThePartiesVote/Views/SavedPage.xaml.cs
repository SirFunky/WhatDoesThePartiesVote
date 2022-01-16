using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatDoesThePartiesVote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedPage : ContentPage
    {
        public SavedPage()
        {
            InitializeComponent();
        }
        private async void HomeBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await this.Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        private async void SearchBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await this.Navigation.PushAsync(new SearchPage());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}