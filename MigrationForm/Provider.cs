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
    
    public partial class Provider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provider()
        {
            this.ApiUserProviders = new HashSet<ApiUserProvider>();
        }
    
        public byte ProviderId { get; set; }
        public string ProviderName { get; set; }
        public Nullable<int> ParentProviderCode { get; set; }
        public int ProviderCode { get; set; }
        public bool IsGateWay { get; set; }
        public bool IsSendGrossAndNet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApiUserProvider> ApiUserProviders { get; set; }
    }
}