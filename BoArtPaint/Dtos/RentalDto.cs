using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoArtPaint.Dtos {
    public class RentalDto {
        public int ArtistId { get; set; }
        public List<int> PaintingIds { get; set; }
    }
}