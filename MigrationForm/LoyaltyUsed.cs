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
    
    public partial class LoyaltyUsed
    {
        public int LoyaltyUsed_ID { get; set; }
        public int LoyaltyEarned_ID { get; set; }
        public int LoyaltyUsed_Ref_ID { get; set; }
        public decimal Used { get; set; }
        public System.DateTime UsedDate { get; set; }
        public bool isAppliedToCom { get; set; }
    }
}