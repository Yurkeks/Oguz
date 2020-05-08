using Microsoft.AspNetCore.Identity;
using Oguz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oguz.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public int PostCode { get; set; }
        public int Amount { get; set; }
        public bool IsSubscribe { get; set; }
    }
}
