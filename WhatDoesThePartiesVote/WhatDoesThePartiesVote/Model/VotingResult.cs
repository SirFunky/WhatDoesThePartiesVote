using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WhatDoesThePartiesVote
{
    public class VotingResult
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Betänkande { get; set; }
        public string Punkt { get; set; }
        public string parti { get; set; }
        public string Ja { get; set; }
        public string Nej { get; set; }
        public string Frånvarande { get; set; }
        public string Avstår { get; set; }
    }

    public class Votering
    {
        public string parti { get; set; }
        public string Ja { get; set; }
        public string Nej { get; set; }
        public string Frånvarande { get; set; }
        public string Avstår { get; set; }
    }

    public class Voteringlista
    {
        [JsonProperty("@grupp8")]
        public string Grupp8 { get; set; }

        [JsonProperty("@grupp7")]
        public string Grupp7 { get; set; }

        [JsonProperty("@grupp6")]
        public string Grupp6 { get; set; }

        [JsonProperty("@grupp5")]
        public string Grupp5 { get; set; }

        [JsonProperty("@grupp4")]
        public string Grupp4 { get; set; }

        [JsonProperty("@grupp3")]
        public string Grupp3 { get; set; }

        [JsonProperty("@grupp1")]
        public string Grupp1 { get; set; }

        [JsonProperty("@grupp2")]
        public string Grupp2 { get; set; }

        [JsonProperty("@gruppering")]
        public string Gruppering { get; set; }

        [JsonProperty("@villkor")]
        public string Villkor { get; set; }

        [JsonProperty("@antal")]
        public string Antal { get; set; }
        public ObservableCollection<Votering> votering { get; set; }
    }

    public class Root
    {
        public Voteringlista voteringlista { get; set; }
    }
}
