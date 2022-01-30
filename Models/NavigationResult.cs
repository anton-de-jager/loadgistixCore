using System;
using System.Collections.Generic;
using loadgistix.Models;

namespace loadgistix.Models
{
    public partial class NavigationResult
    {
        public List<Navigation> Default { get; set; }
        public List<Navigation> Compact { get; set; }
        public List<Navigation> Futuristic { get; set; }
        public List<Navigation> Horizontal { get; set; }
    }
}
