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
    
    public partial class Stadion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stadion()
        {
            this.Posedujes = new HashSet<Poseduje>();
        }
    
        public string naziv_stadiona { get; set; }
        public int id_stadiona { get; set; }
        public string grad { get; set; }
        public Nullable<int> kapacitet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poseduje> Posedujes { get; set; }
    }
}
