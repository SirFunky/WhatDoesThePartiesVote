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
    public partial class SearchPage : ContentPage
    {
        private Voting _Votemodell = new Voting();
        public SearchPage()
        {
            InitializeComponent();
            _Votemodell.WebQuestion();
            lstVotes.ItemsSource = _Votemodell.LstVotering; //hardbind context to LstVotering ( ToDo! might have to change to make the add button work)             
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

        private async void lstVotes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            Votering selectedParty = (Votering)e.Item;
            var detailsPage = new DetailsPage();
            try
            {
                detailsPage.BindingContext = _Votemodell.LstVotering.FirstOrDefault(d => d.parti == selectedParty.parti.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            await this.Navigation.PushAsync(detailsPage);
        }
    }

}