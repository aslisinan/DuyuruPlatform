//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuyuruPlatform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DUYURU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DUYURU()
        {
            this.DUYURU_OKUNDUBILGI = new HashSet<DUYURU_OKUNDUBILGI>();
        }
    
        public int ID { get; set; }
        public string BASLIK { get; set; }
        public string ICERIK { get; set; }
        public System.DateTime DUYURU_TARIHI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DUYURU_OKUNDUBILGI> DUYURU_OKUNDUBILGI { get; set; }
    }
}