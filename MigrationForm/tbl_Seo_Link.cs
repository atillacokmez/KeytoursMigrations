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
    
    public partial class tbl_Seo_Link
    {
        public int Seo_Link_ID { get; set; }
        public Nullable<int> Tour_ID { get; set; }
        public Nullable<int> Supl_ID { get; set; }
        public Nullable<int> Dest_ID { get; set; }
        public Nullable<int> Seo_Link_Type_ID { get; set; }
        public string Seo_LinkMeta { get; set; }
        public string Seo_LinkDesc { get; set; }
        public string Seo_LinkURL { get; set; }
        public string PageName { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<System.DateTime> CrtDate { get; set; }
        public Nullable<int> BookingAgent { get; set; }
        public string Title { get; set; }
        public string Seo_AddInfo { get; set; }
        public string Seo_LinkURLNew { get; set; }
        public bool isNew { get; set; }
        public Nullable<int> LandingID { get; set; }
    }
}