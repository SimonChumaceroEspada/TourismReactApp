namespace PlacesApi.Domain.Entities
{
    public class Place
    {
        public int Id { get; set; }                  // Unique identifier for the place
        public string Name { get; set; }             // Name of the place
        public string Capital { get; set; }  
        public string Image { get; set; }        // Capital of the place
        // public byte[] Image { get; set; }            // Binary data of the image
        public string Description { get; set; }      // Brief description of the place
    }
}
