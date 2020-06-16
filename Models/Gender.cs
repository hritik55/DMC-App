using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Diagnostic_Medical_Center.Models
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female = 2
    }
}