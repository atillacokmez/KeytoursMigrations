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
    
    public partial class TaskType
    {
        public int TaskTypeID { get; set; }
        public string TypeName { get; set; }
        public string Descripton { get; set; }
        public bool isActive { get; set; }
        public Nullable<int> QuoteStatusID { get; set; }
        public bool CanJump { get; set; }
        public bool isJumpable { get; set; }
    }
}
