using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace housemaker.Models
{

    public class CarouselItem
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsShownCarousel { get; set; }
        public byte[] Photo { get; set; }
        public string Url { get; set; }
        public string Base64Image { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public string ButtonUrl { get; set; }
    }

}