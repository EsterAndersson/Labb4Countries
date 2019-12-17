using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Labb4Countries
{
    public class CountryRepository
    {


        public List<Country> Countries { get; set; }

        public void GetJsonData()
            {
            string json = "Model.rawData.json";
            var assembly = typeof(CountryRepository).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{json}");
            using (var reader = new StreamReader(stream))
            {
               var countryList = JsonConvert.DeserializeObject<CountryRepository>(reader.ReadToEnd());
               Countries = countryList.Countries;
            }

        }

        public List<Country> GetCountries()
        {
            GetJsonData();
            return Countries;
        }

    }
}
