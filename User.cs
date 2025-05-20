using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string CarModel { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public bool AllowsSmoking { get; set; }
        public bool PlaysMusic { get; set; }
    }
}
