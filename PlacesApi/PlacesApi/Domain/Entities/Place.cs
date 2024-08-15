namespace PlacesApi.Domain.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Image { get; set; }
        public string EspDescription { get; set; }
        public string EngDescription { get; set; }
        public List<TouristicPlace> TouristicPlaces { get; set; }

    }
}
