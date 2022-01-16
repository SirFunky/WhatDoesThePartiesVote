using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatDoesThePartiesVote
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private Voting _Votemodell = new Voting();
        public DetailsPage()
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

        //private async void AddButton_Clicked(object sender, EventArgs e)
        //{
            
        //    var betänkande = "AU1";
        //    var punkt = "1";
        //    var parti = "TestParti";
        //    var Ja = "TestJa";
        //    var Nej = "TestNej";
        //    var Avstår = "TestAvstår";
        //    var Frånvarande = "TestFrånvarande";
        //    await VoteringsService.AddVotingResult(betänkande, punkt, parti, Ja, Nej, Avstår, Frånvarande);

        //}
    }
}