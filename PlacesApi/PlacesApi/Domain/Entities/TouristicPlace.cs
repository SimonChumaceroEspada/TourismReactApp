namespace PlacesApi.Domain.Entities
{
    public class TouristicPlace
    {
        public int Id { get; set; }
        public string EspName { get; set; }
        public string EngName { get; set; }
        public string EspDescription { get; set; }
        public string EngDescription { get; set; }
        public string Image { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}