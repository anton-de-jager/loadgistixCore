using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loadgistix.Models
{
    public partial class LoadsAvailableRequest
    {
        public float Distance { get; set; }
        public float Weight { get; set; }
        public float VolumeCm { get; set; }
        public float VolumeLt { get; set; }
    }
}
