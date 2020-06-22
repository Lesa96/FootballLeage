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
    
    public partial class Igrac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Igrac()
        {
            this.Menadzers = new HashSet<Menadzer>();
            this.transferistorijas = new HashSet<transferistorija>();
        }
    
        public int id_igraca { get; set; }
        public string ime_igraca { get; set; }
        public string prezime_igraca { get; set; }
        public Nullable<int> vodi_id_trenera { get; set; }
        public string vodi_naziv { get; set; }
        public string naziv_kluba { get; set; }
        public Nullable<int> odigranih_utakmica { get; set; }
        public Nullable<int> postignutih_golova { get; set; }
        public Nullable<double> prosek_golova { get; set; }
        public Nullable<int> godine_igraca { get; set; }
    
        public virtual Klub Klub { get; set; }
        public virtual Vodi Vodi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menadzer> Menadzers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transferistorija> transferistorijas { get; set; }
    }
}
