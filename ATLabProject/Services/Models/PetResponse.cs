namespace ATLabProject.Services.Models
{
    public class PetResponse
    {
        public long id { get; set; }

        public string name { get; set; }

        public List<Object> photoUrls { get; set; }

        public List<Object> tags { get; set; }
    }
}