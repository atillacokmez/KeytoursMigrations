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
    
    public partial class Voucher
    {
        public int Voucher_No { get; set; }
        public Nullable<int> Ref_ID { get; set; }
        public int Service_ID { get; set; }
        public Nullable<int> Issued_By { get; set; }
        public string Local_Contact { get; set; }
        public string Reservation_By { get; set; }
        public string Payment_By { get; set; }
        public Nullable<System.DateTime> Issue_Date { get; set; }
        public string Details { get; set; }
        public string Add_Info { get; set; }
        public Nullable<System.DateTime> Print_Date { get; set; }
        public Nullable<bool> Voucher_IsPrinted { get; set; }
        public string as_SupplName { get; set; }
        public string as_Address { get; set; }
        public string as_Area { get; set; }
        public string as_Tel { get; set; }
        public string as_Details { get; set; }
        public string as_Telephone24Hours { get; set; }
        public string Reservation_By1 { get; set; }
        public string strCity { get; set; }
        public string BookingAgent { get; set; }
        public string Tour_Item { get; set; }
        public string Pax { get; set; }
        public string StartDate { get; set; }
        public string Nights { get; set; }
        public string Room { get; set; }
        public string AddInfo { get; set; }
        public Nullable<int> VoucherNo { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Name5 { get; set; }
        public string strSchNotes { get; set; }
        public string Stime { get; set; }
        public string Meal { get; set; }
        public string as_SupplNameMod { get; set; }
        public string as_ServiceName { get; set; }
        public string as_DetailsItinerary { get; set; }
        public Nullable<System.DateTime> as_OrderDate { get; set; }
        public Nullable<int> TourServiceList { get; set; }
        public Nullable<int> as_SupplNameID { get; set; }
        public Nullable<int> Reservation_ByID { get; set; }
        public string PickupPoint { get; set; }
        public string PickupDetail { get; set; }
        public string DropoffPoint { get; set; }
        public string PickupTime { get; set; }
        public bool isRowDeleted { get; set; }
    }
}
