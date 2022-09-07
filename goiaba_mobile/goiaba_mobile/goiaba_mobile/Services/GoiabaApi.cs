using goiaba_mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace goiaba_mobile.Services
{
    public class GoiabaApi : IGoiabaService
    {

        const string URL = "http://192.168.0.10:8081/users";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }


        public async Task<List<UserModel>> FindAll()
        {
            HttpClient client = GetClient();
           
            var response = await client.GetAsync(URL);
            if (response.IsSuccessStatusCode) //codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<UserModel>>(content);
            }

            return new List<UserModel>();
        }

        public async Task<UserModel> Find(string Id)
        {
            String dados = URL + "/" + Id;
            
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.GetAsync(dados);
            
            if (response.IsSuccessStatusCode) //codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserModel>(content);

                return user;
            }

            return new UserModel();
        }


        public async Task<UserModel> Create(UserModel user)
        {
            String dados = URL;     
            var json = JsonConvert.SerializeObject(new
            {
                firstName = user.FirstName,
                surname = user.Surname,
                age = user.Age

            });

            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(dados, content);

            if (response.IsSuccessStatusCode)
            {
                string user_response = await response.Content.ReadAsStringAsync();
                var userResponse = JsonConvert.DeserializeObject<UserModel>(user_response);

                return userResponse;
            }

            return new UserModel();

        }

        public async Task<Boolean> Update(UserModel user)
        {
            String dados = URL + "/" + user.Id;

            var json = JsonConvert.SerializeObject(new
            {
                firstName = user.FirstName,
                surname = user.Surname,
                age = user.Age

            });

            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(dados, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }

        public async Task<Boolean> Destroy(string Id)
        {
            String dados = URL + "/" + Id.ToString();
            HttpClient client = GetClient();
            HttpResponseMessage response = await client.DeleteAsync(dados);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}
