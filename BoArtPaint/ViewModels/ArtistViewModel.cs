using BoArtPaint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoArtPaint.ViewModels {
    public class ArtistViewModel {
        public IEnumerable<Artist> Artists { get; set; }
        public Painting Painting { get; set; }
    }
}