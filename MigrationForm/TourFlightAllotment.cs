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
    
    public partial class TourFlightAllotment
    {
        public int Tour_Flight_Allotment_ID { get; set; }
        public int Departure_City_ID { get; set; }
        public int Tour_Allotment_ID { get; set; }
        public Nullable<System.DateTime> TourFlightAllotment_CancelReminderDate { get; set; }
        public Nullable<int> TourFlightAllotment_Total { get; set; }
        public Nullable<int> TourFlightAllotment_Booked { get; set; }
        public Nullable<int> TourFlightAllotment_Cancel { get; set; }
        public Nullable<decimal> TourFlightAllotment_AddOnPrice { get; set; }
        public Nullable<int> TourFlightAllotment_AlertValue { get; set; }
        public Nullable<int> TourSchedule_ID { get; set; }
        public Nullable<System.DateTime> TourFlightAllotment_Date { get; set; }
        public Nullable<int> tourFlightAllotment_AddOnPriceNet { get; set; }
        public Nullable<double> tourFlightAllotment_MarkUp { get; set; }
        public Nullable<int> tourFlightAllotment_CurType { get; set; }
    
        public virtual DepartureCity DepartureCity { get; set; }
        public virtual TourAllotment TourAllotment { get; set; }
    }
}
