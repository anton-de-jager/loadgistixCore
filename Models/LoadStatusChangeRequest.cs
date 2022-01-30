using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loadgistix.Models
{
    public partial class LoadStatusChangeRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
