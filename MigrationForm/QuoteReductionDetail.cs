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
    
    public partial class QuoteReductionDetail
    {
        public int QuoteReductionDetail_ID { get; set; }
        public int Ref_ID { get; set; }
        public decimal Amount { get; set; }
        public Nullable<double> PercentAmount { get; set; }
        public int QuoteReductionDetailTypeID { get; set; }
        public string Code { get; set; }
    }
}