using System.Text.Json.Serialization;

namespace MovieReservationAPI.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        //public int MovieId { get; set; }
        public String SeatNumber { get; set; }
        public DateTime ReservationDate { get; set; }


        
        [JsonIgnore]
        public MovieDto MovieDto { get; set; }
        [JsonIgnore]
        public MovieDtoo MovieDtoo { get; set; }
    }
}
