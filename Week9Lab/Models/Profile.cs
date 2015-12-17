using System;

namespace Week9Lab.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public DateTime DOB { get; set; }
        public int MyProperty { get; set; }
        public virtual User Userprofile { get; set; }
        

    }
}