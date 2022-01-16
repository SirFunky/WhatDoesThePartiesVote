using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WhatDoesThePartiesVote
{
    public static class VoteringsService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MySavedData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<VotingResult>();
        }

        public static async Task AddVotingResult(string betänkande, string punkt, string Parti, string ja, string nej, string avstår, string frånvarande)
        {
            await Init();
            VotingResult votingResult = new VotingResult
            {

                Betänkande = betänkande,
                Punkt = punkt,
                parti = Parti,
                Ja = ja,
                Nej = nej,
                Avstår = avstår,
                Frånvarande = frånvarande
            };
            try
            {
                var id = await db.InsertAsync(votingResult);
            }
            
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        public static async Task RemoveVotingResult(int id)
        {
            await Init();

            try
            {
                await db.DeleteAsync<VotingResult>(id);
            }            
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        public static async Task<IEnumerable<VotingResult>> GetVotingResult()
        {
            await Init();
            try
            {
                var votingResult = await db.Table<VotingResult>().ToListAsync();
                return votingResult;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                var votingResult = new List<VotingResult>();
                return votingResult;
            }
            
        }
    }
}
