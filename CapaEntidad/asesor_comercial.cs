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
    
    public partial class asesor_comercial
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public asesor_comercial()
        {
            this.contrato = new HashSet<contrato>();
        }
    
        public int id { get; set; }
        public string numero_identificacion { get; set; }
        public string nm { get; set; }
        public Nullable<bool> direccion { get; set; }
        public Nullable<System.DateTime> telefono { get; set; }
        public string correo_electronico { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contrato> contrato { get; set; }
    }
}
