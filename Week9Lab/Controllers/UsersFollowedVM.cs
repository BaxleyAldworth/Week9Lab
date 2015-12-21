namespace Week9Lab.Controllers
{
     class UsersFollowedVM
    {
        internal bool AlreadyFollowing;

        public UsersFollowedVM()
        {
        }

        public string FullName { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}