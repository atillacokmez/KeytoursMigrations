//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MigrationForm
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityLog
    {
        public int Activity_ID { get; set; }
        public Nullable<int> Ref_ID { get; set; }
        public string Activity_Date { get; set; }
        public string Activity_Type { get; set; }
        public Nullable<int> Modified_By { get; set; }
        public string Modifier_Type { get; set; }
        public string Description { get; set; }
    }
}
