using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ReadyTech.Axis.Service.Models
{
    public enum Scope
    {
        [Description("CURRENT")]
        Current,
        [Description("EXPIRED")]
        Expired,
        [Description("CANCELLED")]
        Cancelled,
        [Description("ALL")]
        All
    }
}
