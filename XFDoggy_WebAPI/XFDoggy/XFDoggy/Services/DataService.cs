using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XFDoggy.Helps;
using XFDoggy.Models;

namespace XFDoggy.Services
{
    public class DataService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient(new HttpClientHandler());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        #region TravelExpense
        public async Task<IEnumerable<TravelExpense>> GetTravelExpensesAsync(string account)
        {
            using (HttpClient client = GetClient())
            {
                var fooStr = $"{AppData.TravelExpenseUrl}?account={account}";
                HttpResponseMessage httpResponseMessage = await client.GetAsync(fooStr);
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<TravelExpense>>(content);
            }
        }

        public async Task PostTravelExpensesAsync(TravelExpense travelExpense)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.PostAsync(AppData.TravelExpenseUrl,
                new StringContent(
                    JsonConvert.SerializeObject(travelExpense, _jsonSerializerSettings),
                    Encoding.UTF8, "application/json"));
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return;
            }
        }

        public async Task PutTravelExpensesAsync(TravelExpense travelExpense)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.PutAsync(AppData.TravelExpenseUrl,
                new StringContent(
                    JsonConvert.SerializeObject(travelExpense, _jsonSerializerSettings),
                    Encoding.UTF8, "application/json"));
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return;
            }
        }

        public async Task DeleteTravelExpensesAsync(int id)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"{AppData.TravelExpenseUrl}?id={id}");
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return ;
            }
        }

        #endregion

        #region TravelExpensesCategory
        public async Task<IEnumerable<TravelExpensesCategory>> GetTravelExpensesCategoryAsync()
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(AppData.TravelExpensesCategoryUrl);
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<TravelExpensesCategory>>(content);
            }
        }

        #endregion

        #region User
        public async Task<AuthUserResult> AuthUserAsync(AuthUser authUser)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.PostAsync(AppData.UserAuthUrl,
                new StringContent(
                    JsonConvert.SerializeObject(authUser, _jsonSerializerSettings),
                    Encoding.UTF8, "application/json"));
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthUserResult>(content);
            }
        }
        #endregion
    }
}
