using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week9Lab.Models
{
    public class Post
    {

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public DateTime PostDate { get; set; }
        public virtual User User { get; set; }
    }
}