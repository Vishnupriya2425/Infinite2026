using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task1.Models
{
    public class DropdownMaster
    {
            public int Id { get; set; }

            public string Category { get; set; }

            public string TextValue { get; set; }

            public string ValueField { get; set; }

            public int? SortOrder { get; set; }

            public bool IsActive { get; set; }
        }
    }