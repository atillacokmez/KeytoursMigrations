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
    
    public partial class Shipping
    {
        public int Shipping_ID { get; set; }
        public string Shipping_Type { get; set; }
        public Nullable<decimal> Shipping_Price { get; set; }
        public string Tracking_Url { get; set; }
        public Nullable<int> OrderID { get; set; }
        public bool isActive { get; set; }
    }
}