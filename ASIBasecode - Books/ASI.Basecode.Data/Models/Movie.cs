using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        
        public string Title { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateTimeCreated = DateTime.Now;
    }

}
