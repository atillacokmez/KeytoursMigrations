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
    
    public partial class TourExpense
    {
        public int Tour_Expense_ID { get; set; }
        public int Tour_ID { get; set; }
        public Nullable<decimal> TourExpense_Price { get; set; }
        public Nullable<decimal> TourExpense_Price_Old { get; set; }
    }
}
