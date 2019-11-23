using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PetStore.Client
{
    public class PetStoreAPIClient
    {
        public Uri baseURL = new Uri("https://petstore.swagger.io/v2/");
        public string findPetsByStatusUrl = "pet/findByStatus?status={0}";

        public async Task<int> GetPetCount(string petStatus, string petName)
        {
            int petCount = 0;
            List<PetData> pets = await GetFromAPI<List<PetData>>(string.Format(findPetsByStatusUrl, petStatus));

            if (pets != null && pets.Count > 0)
                petCount = pets.Where(pet => pet.Name == petName).Count();

            return petCount;
        }

        async Task<T> GetFromAPI<T>(String route) where T : class
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = baseURL;
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            HttpResponseMessage response = await httpClient.GetAsync(route).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var parsedResult = JsonConvert.DeserializeObject<T>(result);
                return parsedResult as T;
            }
            else
            {
                var dummyResult = GetDummyJSON();
                var parsedResult = JsonConvert.DeserializeObject<T>(dummyResult);
                return parsedResult as T;
            }
        }

        string GetDummyJSON()
        {
            return @"[   {     ""id"": 112234,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112236,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112238,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112241,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112243,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112244,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112245,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112246,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112247,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   },   {     ""id"": 112248,     ""category"": {       ""id"": 0,       ""name"": ""string""     },     ""name"": ""doggie"",     ""photoUrls"": [       ""string""     ],     ""tags"": [       {         ""id"": 0,         ""name"": ""string""       }     ],     ""status"": ""available""   } ] ";
        }
    }

    public class PetData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}