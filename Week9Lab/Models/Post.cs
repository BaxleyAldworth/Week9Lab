using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week9Lab.Models
{
    public class Post
    {

        public int PostId { get; set; }
       
        public string Title { get; set; }
        public string Message { get; set; }
    
        [NotMapped]
        public DateTime PostDate { get; set; }
        public virtual UsersFollwedVM User { get; set; }
    }
}