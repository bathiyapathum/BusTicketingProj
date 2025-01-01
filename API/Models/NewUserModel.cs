namespace API.Models
{
    public class NewUserModel
    {
        public string fullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public string NIC { get; set; }
        //public string EmailConfirmed { get; set; }
        //public string PhoneNumberConfirmed { get; set; }
        //public string TwoFactorEnabled { get; set; }
        //public string LockoutEnabled { get; set; }
        //public string AccessFailedCount { get; set; }

    }
}
