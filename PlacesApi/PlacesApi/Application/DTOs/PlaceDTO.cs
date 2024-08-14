namespace PlacesApi.Application.DTOs
{
    public class PlaceDto
    {
        public int Id { get; set; }                  // Unique identifier for the place
        public string Name { get; set; }             // Name of the place
        public string Capital { get; set; }          // Capital of the place
        public string Image { get; set; }            // URL or path to an image of the place
        public string EspDescription { get; set; }      // Brief description of the place
        public string EngDescription { get; set; }   // English description of the place
    }
}
