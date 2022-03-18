using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OponeoViewsAndAuth.Start.ViewModels
{
    public class UserProfileViewModel
    {
        public string EmailAddress { get; set; }

        public string Nickname { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Name { get; set; }

        public string NameId { get; set; }

        public bool EmailVerified { get; set; }

        public string ProfileImage { get; set; }
    }
}
