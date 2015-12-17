using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week9Lab.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public virtual List<Post> Posts { get; set; }
        public Profile ProfileInfo { get; set; }


    }
}