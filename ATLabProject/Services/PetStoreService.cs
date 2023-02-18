using ATLabProject.Services.Models;
using System.Net.Http.Json;

namespace ATLabProject.Services
{
    /// <summary>
    /// class contains methods for work with API Swagger Petstore
    /// </summary>
    public class PetStoreService
    {
        public string baseUrl = "https://petstore.swagger.io/v2/";
        public HttpClient client;

        public PetStoreService()
        {
            client = new HttpClient();
        }

        public async Task<PetResponse> Add(string petName)
        {
            var endpoint = "pet";

            var pet = new PetRequest { name = petName };

            var httpsResponse = await client.PostAsJsonAsync(baseUrl + endpoint, pet);

            httpsResponse.EnsureSuccessStatusCode();

            PetResponse? petResponse = await httpsResponse.Content.ReadFromJsonAsync<PetResponse>();

            if (petResponse is null)
            {
                throw new ArgumentNullException(nameof(petResponse));
            }
            return petResponse;
        }

        public async Task<PetResponse> FindById(long petId)
        {
            var endpoint = $"pet/{petId}";

            var httpsResponse = await client.GetAsync(baseUrl + endpoint);

            httpsResponse.EnsureSuccessStatusCode();

            PetResponse?petResponse = await httpsResponse.Content.ReadFromJsonAsync<PetResponse>();

            if (petResponse is null)
            {
                throw new ArgumentNullException(nameof(petResponse));
            }
            return petResponse;
        }      

    }
}