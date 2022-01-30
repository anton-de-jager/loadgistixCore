using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

#nullable disable

namespace loadgistix.Models
{
    public partial class LoginResult
    {
        public string accessToken { get; set; }
        public VwUser user { get; set; }
        public ICollection<Permission> permissions { get; set; }
        public bool result { get; set; }
    }
}
