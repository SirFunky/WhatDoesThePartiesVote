using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhatDoesThePartiesVote
{
    public class Voting : BaseViewModel
    {
        private ObservableCollection<Votering> _votering = new ObservableCollection<Votering>();
        public ObservableRangeCollection<VotingResult> VotingResults { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<VotingResult> RemoveCommand { get; }
        public AsyncCommand<VotingResult> SelectedCommand { get; }

        public Voting()
        {
            VotingResults = new ObservableRangeCollection<VotingResult>();
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<VotingResult>(Remove);            
            SelectedCommand = new AsyncCommand<VotingResult>(Selected);
        }


        public ObservableCollection<Votering> LstVotering
        {

            get
            {
                return this._votering;
            }
        }

        public void testLoad()
        {
            _votering = new ObservableCollection<Votering>();
            _votering.Add(new Votering { parti = "PartiTest2" });
        }

        public async void WebQuestion()
        {
            try
            {
                string URL = @"https://data.riksdagen.se/voteringlista/?bet=AU1&punkt=1&valkrets=&rost=&iid=&sz=500&utformat=json&gruppering=parti";
                HttpClient httpClient = new HttpClient();
                
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(URL));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var voteList = JsonConvert.DeserializeObject<Root>(content);
                    //Databind the list
                    foreach (var item in voteList.voteringlista.votering)
                    {
                        _votering.Add(new Votering { parti = item.parti, Ja = item.Ja, Nej = item.Nej, Avstår = item.Avstår, Frånvarande = item.Frånvarande});
                    }

                    

                }
            }
            catch (Exception ex)
            {                
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        async Task Add()
        {
            var Betänkande = "AU1";
            var Punkt = "1";
            var parti = "Parti";
            var Ja = "ja";
            var Nej = "nej";
            var Avstår = "avstår";
            var Frånvarande = "frånvarande";
            await VoteringsService.AddVotingResult(Betänkande, Punkt, parti, Ja, Nej, Avstår, Frånvarande);
            await Refresh();
        }
        async Task Remove(VotingResult votingResult)
        {
            await VoteringsService.RemoveVotingResult(votingResult.id);
            await Refresh();
        }
        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            VotingResults.Clear();

            var votingResults = await VoteringsService.GetVotingResult();

            VotingResults.AddRange(votingResults);

            IsBusy = false;



        }

        async Task Selected(VotingResult votingResult)
        {
            if (votingResult == null)
                return;

            try
            {
                var route = $"{nameof(SavedPage)}?VotingResultId={votingResult.id}";
                await Shell.Current.GoToAsync(route);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

        }
    }
}
