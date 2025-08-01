using System.ComponentModel.DataAnnotations;

namespace MovieEnitityFrameWork.Models
{
    public class Movie
    {


        public int Id { get; set; }

        [Required(ErrorMessage = "Title is a Required Input")]
        [StringLength(maximumLength: 30, ErrorMessage = "String Lenght cannot be more than 30 characters" )]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is a Required Input")]
        [StringLength(maximumLength:200, ErrorMessage ="Description cannot be more than 200 characters")]
        public string Description { get; set; }


        // Foreign key relation
        [Required(ErrorMessage = "Please select a director")]

        public int DirectorId { get; set; }

        // Navigation property
        public Director Director { get; set; }




    }
}


