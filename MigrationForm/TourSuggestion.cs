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
    
    public partial class TourSuggestion
    {
        public int ID { get; set; }
        public int Tour_ID { get; set; }
        public int Suggested_Tour_ID { get; set; }
        public Nullable<decimal> TourSuggestion_Price { get; set; }
        public Nullable<bool> optinal { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> Day { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public string ShortDesc { get; set; }
        public bool isOnline { get; set; }
        public string SuggestedTourCode { get; set; }
        public Nullable<int> ProviderCode { get; set; }
    }
}