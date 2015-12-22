using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week9Lab.Models
{
    public class PostIndexVM
    {
        public string AuthorId { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime PostedOn { get; set; }
        public int PostId { get; set; }
        public bool IsAlreadyFollowing { get; set; }

    }
}