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
    
    public partial class WebUserDisposablePassword
    {
        public int WebUserDisposablePasswordID { get; set; }
        public int Web_User_ID { get; set; }
        public string Password { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public bool isActive { get; set; }
    }
}