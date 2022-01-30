using System;
using System.Collections.Generic;

namespace loadgistix.Models
{
    public partial class ResetPasswordRequest
    {
        public Guid? Reset { get; set; }
        public string Password { get; set; }
    }
}
