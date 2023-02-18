using ATLabProject.Services.Models;
using System.Net.Http.Json;

namespace ATLabProject.Services
{
    /// <summary>
    /// class contains methods for work with API Swagger Petstore
    /// </summary>
    public class UserStoreService
    {
        public string baseUrl = "https://petstore.swagger.io/v2/";
        public HttpClient client;

        public UserStoreService()
        {
            client = new HttpClient();
        }

        public async Task<UserResponse> Add(string userName)
        {
            var endpoint = "user";

            var user = new UserRequest { username = userName };

            var httpsResponse = await client.PostAsJsonAsync(baseUrl + endpoint, user);

            httpsResponse.EnsureSuccessStatusCode();

            UserResponse? userResponse = await httpsResponse.Content.ReadFromJsonAsync<UserResponse>();

            if (userResponse is null)
            {
                throw new ArgumentNullException(nameof(userResponse));
            }

            return userResponse;
        }

        public async Task<UserResponse> FindByUserName(string username)
        {
            var endpoint = $"user/{username}";

            var httpsResponse = await client.GetAsync(baseUrl + endpoint);

            httpsResponse.EnsureSuccessStatusCode();

            UserResponse? userResponse = await httpsResponse.Content.ReadFromJsonAsync<UserResponse>();

            if (userResponse is null)
            {
                throw new ArgumentNullException(nameof(userResponse));
            }
            return userResponse;
        }
    }
}