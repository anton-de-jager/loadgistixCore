using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loadgistix.Models
{
    public partial class UploadRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string fileName { get; set; }
    }
}
