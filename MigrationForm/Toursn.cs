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
    
    public partial class Toursn
    {
        public Nullable<int> Airline_ID { get; set; }
        public string Tour_Code { get; set; }
        public Nullable<int> Supl_ID { get; set; }
        public Nullable<int> Start_Destination_ID { get; set; }
        public Nullable<int> End_Destination_ID { get; set; }
        public string Tour_Name { get; set; }
        public Nullable<int> Service_Category_ID { get; set; }
        public byte ServiceTypeId { get; set; }
        public string Tour_Option_Name { get; set; }
        public Nullable<int> Run_MinPax { get; set; }
        public string Notes { get; set; }
        public string Advse_Book { get; set; }
        public string Tour_Desc { get; set; }
        public Nullable<int> Tour_Duration { get; set; }
        public string Distance { get; set; }
        public int Tour_ID { get; set; }
        public string Tour_Map1 { get; set; }
        public Nullable<int> Tour_Num_Days_Cruise { get; set; }
        public string Tour_Itinerary_File { get; set; }
        public Nullable<int> Cruise_Supl_ID { get; set; }
        public bool Toursn_Deleted { get; set; }
        public string Tour_Picture { get; set; }
        public Nullable<int> motherTour_ID { get; set; }
        public Nullable<bool> isMotherTour { get; set; }
        public Nullable<int> Tour_cruise_before_day { get; set; }
        public string Tour_Thumbnail { get; set; }
        public Nullable<byte> MainNotification { get; set; }
        public Nullable<int> Operated_Supl_ID { get; set; }
        public Nullable<bool> TransferStatus { get; set; }
        public Nullable<int> TransferType { get; set; }
        public Nullable<bool> Escor { get; set; }
        public Nullable<bool> OnList { get; set; }
        public Nullable<System.DateTime> PicUploadDate { get; set; }
        public Nullable<int> TransCat { get; set; }
        public string TransferNo { get; set; }
        public Nullable<int> TransferDuration { get; set; }
        public string DeparTime { get; set; }
        public string ArrivTime { get; set; }
        public Nullable<bool> Educational { get; set; }
        public string Tour_Picture_AltTag { get; set; }
        public Nullable<bool> OnlyBookingAgent { get; set; }
        public Nullable<System.DateTime> DuplicateDate { get; set; }
        public Nullable<bool> Duplicate { get; set; }
        public Nullable<int> DuplicateNo { get; set; }
        public Nullable<bool> Toursn_CruiseCnt { get; set; }
        public Nullable<int> SightseeingType { get; set; }
        public string Highlight { get; set; }
        public string HighlightTmp { get; set; }
        public bool isShowHighlightTmp { get; set; }
        public Nullable<System.DateTime> AutoStopDate { get; set; }
        public Nullable<int> PaymentTypeID { get; set; }
        public bool isTopSellers { get; set; }
        public Nullable<bool> showSignUp { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string GbtKeywords { get; set; }
        public string SupplierTourCode { get; set; }
        public string Default_Additional_Info { get; set; }
        public string MeetingPointMap { get; set; }
        public Nullable<bool> isPreferred { get; set; }
        public bool isFamTrip { get; set; }
        public bool isLandOnlyHidden { get; set; }
        public string SupplierTourName { get; set; }
        public string ArrivalLocation { get; set; }
        public string Supplier_Info { get; set; }
    }
}