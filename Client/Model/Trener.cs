//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trener
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trener()
        {
            this.Vodis = new HashSet<Vodi>();
        }
    
        public string ime_trenera { get; set; }
        public string prezime_trenera { get; set; }
        public int id_trenera { get; set; }
        public string drzava { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vodi> Vodis { get; set; }
    }
}
