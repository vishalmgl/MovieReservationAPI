﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieReservationAPI.Model
{   //this is the parent model
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int DurationInMinutes { get; set; }

        
        //child
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
