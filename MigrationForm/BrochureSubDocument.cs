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
    
    public partial class BrochureSubDocument
    {
        public int SubDocument_ID { get; set; }
        public int BrochureType_ID { get; set; }
        public string SubDcumentName { get; set; }
        public Nullable<int> BrochurePages { get; set; }
        public Nullable<int> BrochureSize { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> PicUploadDate { get; set; }
    
        public virtual BrochureType BrochureType { get; set; }
    }
}