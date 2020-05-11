using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyTech.Axis.Service.Models
{
    public class ScopeParameter
    {
        public ScopeParameter()
        {

        }
        public ScopeParameter(Scope scope)
        {
            Scope = scope.GetDescription();
        }

        public string Scope { get; set; }
    }
}
