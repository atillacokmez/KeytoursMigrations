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
    
    public partial class LandingCrossSale
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ApiUserID { get; set; }
        public int LandingID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public Nullable<int> TourID { get; set; }
    }
}