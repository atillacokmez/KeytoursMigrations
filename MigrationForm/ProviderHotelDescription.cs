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
    
    public partial class ProviderHotelDescription
    {
        public int Id { get; set; }
        public int ParsecHotelID { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string GeneralDescription { get; set; }
        public string AdditionalDescription { get; set; }
        public string Thumbnail { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CheckoutTime { get; set; }
        public string CheckinTime { get; set; }
    }
}
