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
    
    public partial class Tourdet
    {
        public Nullable<int> Supl_ID { get; set; }
        public int Tourdet_ID { get; set; }
        public string Tour_Code { get; set; }
        public string Suppl_Name { get; set; }
        public Nullable<System.DateTime> Tour_Date { get; set; }
        public Nullable<int> Nights { get; set; }
        public Nullable<int> Tour_ID { get; set; }
        public string Tour_Route { get; set; }
        public string Itinerary { get; set; }
        public string Itin_Meal { get; set; }
        public Nullable<int> Tour_Day { get; set; }
        public Nullable<int> Detail_Tour_ID { get; set; }
        public Nullable<int> Tourdet_List_ID { get; set; }
        public Nullable<bool> Tourdet_Breakfast { get; set; }
        public Nullable<bool> Tourdet_Lunch { get; set; }
        public Nullable<bool> Tourdet_Dinner { get; set; }
        public Nullable<bool> TourDet_DayIncludesCruise { get; set; }
        public Nullable<bool> Tour_Type { get; set; }
        public bool isFlightArrivesSameDay { get; set; }
    }
}
