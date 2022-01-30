using System;
using System.Collections.Generic;

#nullable disable

namespace loadgistix.Models
{
    public partial class ProcedureResult
    {
        public Guid Id { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
