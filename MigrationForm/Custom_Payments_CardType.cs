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
    
    public partial class Custom_Payments_CardType
    {
        public int CreditCardID { get; set; }
        public Nullable<int> CardTypeID { get; set; }
        public string CardTypeDesc { get; set; }
        public string CardShortCode { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
