using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel.DataAnnotations.Schema;

namespace housemaker.Models
{

    [System.ComponentModel.DataAnnotations.Schema.Table("CarouselItems")]
    public class CarouselItem
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsShownCarousel { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Выберите файл")]
        [ValidateFile(ErrorMessage = "Please select a PNG, GIF or JPEG image smaller than 5 MB")]
        public HttpPostedFileBase File { get; set; }
        public byte[] Photo { get; set; }
        public string Url { get; set; }
        public string Base64Image { get; set; }
        [Required(ErrorMessage = "Укажите заголовок")]
        [StringLength(100, ErrorMessage = "Headline too long")]
        [MinLength(5, ErrorMessage = "Headline too short")]
        public string Headline { get; set; }
        [StringLength(500, ErrorMessage = "Text too long")]
        public string Text { get; set; }
        public string Description { get; set; }
        [StringLength(100, ErrorMessage = "Button text too long")]
        public string ButtonText { get; set; }
        [StringLength(255, ErrorMessage = "Button URL too long")]
        public string ButtonUrl { get; set; }
    }


    public class ValidateFileAttribute : RequiredAttribute
    {

        HashSet<ImageFormat> AllowedFormats = new HashSet<ImageFormat>()
            {
                 ImageFormat.Png,
                 ImageFormat.Jpeg,
                 ImageFormat.Gif
            };

        public override bool IsValid(object value)
        {

            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            if (file.ContentLength > 5 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    // return img.RawFormat.Equals(ImageFormat.Png);
                    return AllowedFormats.Contains(img.RawFormat);
                }
            }
            catch { }
            return false;
        }
    }

}