using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationAPI.Model
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String SeatNumber { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        //foreign key: Movie id isliked to miovie model
        public int MovieId { get; set; }
        
        

        //parent
        [ForeignKey("MovieId")]//specify foreign key
        public Movie Movie { get; set; }//navigationn property to the movie

    }
}
