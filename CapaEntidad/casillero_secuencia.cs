//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaEntidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class casillero_secuencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public casillero_secuencia()
        {
            this.persona = new HashSet<persona>();
        }
    
        public int id { get; set; }
        public string prefijo { get; set; }
        public Nullable<int> secuencia { get; set; }
        public string casillero { get; set; }
        public Nullable<int> tipo { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<System.DateTime> fec_creacion { get; set; }
        public Nullable<int> usu_creacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<persona> persona { get; set; }
    }
}