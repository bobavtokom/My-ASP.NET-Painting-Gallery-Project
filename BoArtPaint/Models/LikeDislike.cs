using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoArtPaint.Models {
    public class LikeDislike {
        public int Id { get; set; }
        public string UserId { get; set; }
        public  bool IsLiked { get; set; }
    }
}