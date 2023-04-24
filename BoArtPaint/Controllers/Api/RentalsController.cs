using BoArtPaint.Dtos;
using BoArtPaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoArtPaint.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public RentalsController() {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto) {
            var artist = _context.Artists.Single(a => a.Id == rentalDto.ArtistId);
            var paintings = _context.Paintings.Where(p => rentalDto.PaintingIds.Contains(p.Id));
            foreach (var painting in paintings) {
                var rent = new Rent {
                    Painting = painting,
                    Artist = artist,
                    DateOfRent = DateTime.Now
                };
                _context.Rents.Add(rent);
            }
                _context.SaveChanges();
                return Ok();
        }
    }
}
