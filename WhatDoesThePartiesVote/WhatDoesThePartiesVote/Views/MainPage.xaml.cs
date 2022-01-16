using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatDoesThePartiesVote;
using Xamarin.Forms;

namespace WhatDoesThePartiesVote
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        private async void Saved_Clicked(object sender, EventArgs e)
        {
            try
            {
                await this.Navigation.PushAsync(new SavedPage());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
