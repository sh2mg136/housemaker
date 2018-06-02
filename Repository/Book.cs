using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository
{

    [Table("Books")]
    public class Book : BaseEntity
    {
        [MinLength(2, ErrorMessage = "too short")]
        [MaxLength(1000, ErrorMessage = "too long")]
        [StringLength(1000, ErrorMessage = "Слишком длинное название", MinimumLength = 5)]
        public string Name { get; set; }

        public int PublishYear { get; set; }

        public string AuthorName { get; set; }
    }

}
