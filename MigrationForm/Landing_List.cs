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
    
    public partial class Landing_List
    {
        public int LandingID { get; set; }
        public int CompanyID { get; set; }
        public int ApiUserID { get; set; }
        public Nullable<int> DestinationID { get; set; }
        public string Subject { get; set; }
        public string LandingText { get; set; }
        public string LandingTextBottom { get; set; }
        public string LandingCaption { get; set; }
        public Nullable<System.DateTime> Date_Edit { get; set; }
        public Nullable<System.DateTime> Date_crc { get; set; }
        public Nullable<bool> Active { get; set; }
        public string LandingURL { get; set; }
        public Nullable<bool> StaticPage { get; set; }
        public Nullable<int> Parent_LandingID { get; set; }
        public Nullable<int> TourID { get; set; }
        public string LandingDetailText { get; set; }
        public Nullable<int> Tour_ID { get; set; }
        public string PromotionCode { get; set; }
        public Nullable<int> ConstantPageID { get; set; }
        public string UrlRewrite { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool isNew { get; set; }
        public string HeaderText { get; set; }
        public string HeaderImage { get; set; }
        public string CrossHeader { get; set; }
        public bool isDisplayAsPromotion { get; set; }
        public bool isHideRight { get; set; }
        public int Promotion_Rank { get; set; }
        public string RightSideImage { get; set; }
        public string WhoUpdated { get; set; }
        public Nullable<System.DateTime> WhenUpdated { get; set; }
        public string RightSideText { get; set; }
    }
}