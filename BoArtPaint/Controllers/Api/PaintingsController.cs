using AutoMapper;
using BoArtPaint.Dtos;
using BoArtPaint.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace BoArtPaint.Controllers.Api {
    public class PaintingsController : ApiController {
        private ApplicationDbContext _context;
        public PaintingsController() {
            _context = new ApplicationDbContext();
        }
        // GET /api/paintings
        public IEnumerable<PaintingDto> GetPaintings() {
            return _context.Paintings.ToList().Select(Mapper.Map<Painting, PaintingDto>);
        }

        // GET /api/paintings/1
        public IHttpActionResult GetPainting(int id) {
            var painting = _context.Paintings.FirstOrDefault(x => x.Id == id);
            if (painting == null) {
                return NotFound();
            }
            return Ok(Mapper.Map<Painting, PaintingDto>(painting));
        }

        // POST /api/paintings
        [HttpPost]
        public IHttpActionResult CreatePainting(PaintingDto paintingDto) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var painting = Mapper.Map<PaintingDto, Painting>(paintingDto);
            _context.Paintings.Add(painting);
            _context.SaveChanges();
            paintingDto.Id = painting.Id;
            return Created(new Uri(Request.RequestUri + "/" + painting.Id), paintingDto);
        }

        // PUT /api/paintings/1
        [HttpPost]
        public void UpdatePainting(int id, PaintingDto paintingDto) {
            if (!ModelState.IsValid) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var paintingId = _context.Paintings.FirstOrDefault(p => p.Id == id);
            if (paintingId == null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Mapper.Map(paintingDto, paintingId);
            _context.SaveChanges();
        }

        // DELETE /api/paintings/1
        [HttpDelete]
        public void DeletePainting(int id) {
            var paintingId = _context.Paintings.FirstOrDefault(p => p.Id == id);
            if (paintingId == null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Paintings.Remove(paintingId);
            _context.SaveChanges();
        }
    }
}