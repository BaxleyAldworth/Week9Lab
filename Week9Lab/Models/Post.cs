using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week9Lab.Models
{
    public class Post
    {

        public int PostId { get; set; }
        [Display(Name = "Posted By")]
        public string Title { get; set; }
        public string Message { get; set; }
        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }
        [NotMapped]
        public DateTime PostDate { get; set; }
        public virtual User User { get; set; }
    }
}