using MovieReservationAPI.Model;

namespace MovieReservationAPI.DTOs
{
    public class MovieDto
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int DurationInMinutes { get; set; }
        public List<ReservationDto>reservations { get; set; }=new List<ReservationDto>();
    }
}
