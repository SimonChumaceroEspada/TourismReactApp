namespace PlacesApi.Application.DTOs
{
    public class CreateTouristicPlaceDto
    {
        public string Name { get; set; }
        public string EspDescription { get; set; }
        public string EngDescription { get; set; }
        public string Image { get; set; }
        public int PlaceId { get; set; }
    }
}