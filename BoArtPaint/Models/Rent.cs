using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoArtPaint.Models {
    public class Rent {
        public int Id { get; set; }
        [Required]
        public Artist Artist { get; set; }
        [Required]
        public Painting Painting { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime? DateOfReturn { get; set; }
    }
}