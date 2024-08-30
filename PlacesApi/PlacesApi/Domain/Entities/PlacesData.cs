namespace PlacesApi.Domain.Entities
{
    public class PlacesData
    {
        public int id { get; set; }
        public string esp_name { get; set; }
        public string eng_name { get; set; }
        public string esp_description { get; set; }
        public string eng_description { get; set; }
        public string image { get; set; }
        public string type { get; set; }
        public int place_id { get; set; }
        public Place place { get; set; }
    }
}