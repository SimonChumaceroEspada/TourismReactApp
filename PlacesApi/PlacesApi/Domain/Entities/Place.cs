namespace PlacesApi.Domain.Entities
{
    public class Place
    {
        public int id { get; set; }
        public string name { get; set; }
        public string capital { get; set; }
        public string image { get; set; }
        public string esp_description { get; set; }
        public string eng_description { get; set; }
        public List<TouristicPlace> touristic_places { get; set; }
        public List<Food> foods { get; set; }
        public List<Party> parties { get; set; }
        public List<PlacesData> places_data { get; set; }

    }
}
