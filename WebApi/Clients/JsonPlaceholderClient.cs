using Newtonsoft.Json;
using System.Text;
using WebApi.Models.DataTransferObject;





namespace WebApi.Clients
{
    public class JsonPlaceholderClient : IJsonPlaceholderClient
    {
        private HttpClient _httpClient;


        public JsonPlaceholderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            var users = await response.Content.ReadAsAsync<List<UserDto>>();

            return users;
        }

        public async Task<string> Create(UserDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            string result = "";
            using (HttpResponseMessage response = await _httpClient.PostAsync("https://jsonplaceholder.typicode.com/users", content))
            {
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        public async Task<JsonResult<UserDto>> GetUserById(int id)
        {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<UserDto>();
                return new JsonResult<UserDto>
                {
                    Data = data,
                    IsSuccessful = true,
                    ErrorMessage = ""
                };
            }
            else
            {
                return new JsonResult<UserDto>
                {
                    IsSuccessful = false,
                    ErrorMessage = response.StatusCode.ToString()
                };
            }
        }

    }
}

//public async Task CreateUser(UserDto user)
//{
//    var json = JsonConvert.SerializeObject(user);
//    var content = new StringContent(json, Encoding.UTF8, "application/json");

//    var response = await _httpClient.PostAsync("https://jsonplaceholder.typicode.com/users", content);

//    if (response.IsSuccessStatusCode)
//    {
//        var responseContent = await response.Content.ReadAsStringAsync();
//        // Galite tvarkyti sukurtą resursą, jei to reikia
//        Console.WriteLine("Sukurtas vartotojas: " + responseContent);
//    }
//    else
//    {
//        Console.WriteLine("Klaida kuriant vartotoją. Statuso kodas: " + response.StatusCode);
//    }
//}


//var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
//var users = await response.Content.Create(user);