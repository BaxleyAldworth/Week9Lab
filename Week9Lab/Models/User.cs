using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Week9Lab.Models
{
   
        public class User : UsersFollwedVM
        {
            public bool AlreadyFollowing { get; set; }
            public virtual List<UsersFollwedVM> UsersFollowed { get; set; }

        }
}
