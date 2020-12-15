using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Packt.Shared
{
    [Keyless]
    public partial class EmployeeTerritory
    {
        public long EmployeeID { get; set; }
        [Required]
        public string TerritoryID { get; set; }
    }
}
