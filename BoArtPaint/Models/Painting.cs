using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoArtPaint.Models {
    public class Painting {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Url]
        public string PaintUrl { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Subtotal => Price * Quantity;
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}