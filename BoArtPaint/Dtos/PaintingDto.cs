using BoArtPaint.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoArtPaint.Dtos {
    public class PaintingDto {
        
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public string Description { get; set; }
            [Url]
            public string PaintUrl { get; set; }
            public double Price { get; set; }
            public int ArtistId { get; set; }

           
    }
}