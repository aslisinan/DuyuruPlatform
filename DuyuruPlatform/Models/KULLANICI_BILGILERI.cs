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
    
    public partial class KULLANICI_BILGILERI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KULLANICI_BILGILERI()
        {
            this.DUYURU_OKUNDUBILGI = new HashSet<DUYURU_OKUNDUBILGI>();
        }
    
        public int ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string TELEFON { get; set; }
        public string MAIL { get; set; }
        public string SIFRE { get; set; }
        public string YETKI_GRUP { get; set; }
        public string DUYURU_GRUP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DUYURU_OKUNDUBILGI> DUYURU_OKUNDUBILGI { get; set; }
    }
}
