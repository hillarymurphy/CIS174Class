using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Areas.OlympicGames.Models
{
    [Area("OlymicGames")]
    public class CountrySession
    {
        private const string CountrysKey = "mycountrys";
        private const string CountKey = "countrycount";
        private const string SportTypeKey = "sporttype";
        private const string CatKey = "cat";

        private ISession session { get; set; }
        public CountrySession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountrys(List<Country> countrys)
        {
            session.SetObject(CountrysKey, countrys);
            session.SetInt32(CountKey, countrys.Count);
        }
        public List<Country> GetMyCountrys() =>
            session.GetObject<List<Country>>(CountrysKey) ?? new List<Country>();
        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        public void SetActiveSportType(string activeSportType) =>
            session.SetString(SportTypeKey, activeSportType);
        public string GetActiveSportType() => session.GetString(SportTypeKey);

        public void SetActiveCat(string activeCat) =>
            session.SetString(CatKey, activeCat);
        public string GetActiveCat() => session.GetString(CatKey);

        public void RemoveMyCountrys()
        {
            session.Remove(CountrysKey);
            session.Remove(CountKey);
        }
    }
}
