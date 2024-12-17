using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.DTOs;
using MovieReservationAPI.Model;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]//defining the route
    [ApiController]//specifying that this is an api controller(handels json data)



    public class MovieController : Controller
    {
        private readonly AppDbContext _context;//database context for accessing database

        public MovieController(AppDbContext context)//constructor for dependency injection
        {
             _context = context;//assigning the injected database for private variable
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>>GetMovies()
        {//fetch all movies from the database along wth the reservation
            var movies=await _context.Movies
                .Include(m=>m .Reservations)//include related reservations
                .ToListAsync();//execute the querry asychronously and fetch data
        
        
        //convert the fetched movie to dtos
        var moviedtos=movies.Select(m=> new MovieDto
        {
            Id=m.Id,//mapping its properties
            Title=m.Title,
            Genre=m.Genre,
            DurationInMinutes=m.DurationInMinutes,
            reservations=m.Reservations.Select(r=>new ReservationDto
            {
                Id=r.Id,
                SeatNumber=r.SeatNumber,
                ReservationDate=r.ReservationDate
            }).ToList()
            }).ToList();

            return Ok(moviedtos);
        }
        [HttpPost]
        public async Task <ActionResult<Movie>>CreateMovie(MovieDto movieDto)
        {
            //map the incoming movie dto to movie entity
            var movie = new Movie
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                DurationInMinutes = movieDto.DurationInMinutes
            };

            //add the new movie entity to the movies table in the database

            _context.Movies.Add(movie);


            //save changes
            await _context.SaveChangesAsync();


            //return http 201 status with the created movie details
            return CreatedAtAction(nameof(GetMovies),new {id =movie.Id},movieDto);
        }
        [HttpPost("{id}/reservation")]//http for adding reservation and connecting it specfic movie
        public async Task<ActionResult> AddReservation(int id,ReservationDto reservationDto)
        {

            //find movie in database by its id
            var movie =await _context.Movies.FindAsync(id);
            //check if movie exists
            if (movie == null)
            {
                return NotFound("movie not foumd");
            }
            //create a new reservation
            var reservation = new Reservation
            {
                SeatNumber = reservationDto.SeatNumber,
                ReservationDate = reservationDto.ReservationDate,
                MovieId = id//Link reservation to the movie using its id
            };

            //Add reservation entity to the reeservations table in the database
            _context.Reservations.Add(reservation);

            //save changes
            await _context.SaveChangesAsync();


            //return http 200 response
            return Ok("reservation added successfully");
        }

    }
}
