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
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.usuario_contrato = new HashSet<usuario_contrato>();
        }
    
        public int id { get; set; }
        public string nm { get; set; }
        public Nullable<int> tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public Nullable<System.DateTime> fecha_ultm_act { get; set; }
        public string usuario1 { get; set; }
        public Nullable<int> tipo_usuario { get; set; }
        public string contrasenia { get; set; }
        public Nullable<System.DateTime> fecha_ultm_act_contrasenia { get; set; }
        public Nullable<System.DateTime> fecha_ultm_autenticacion { get; set; }
        public Nullable<int> id_oficina { get; set; }
        public Nullable<bool> cambio_contrasenia { get; set; }
        public byte[] contrasenia_encriptada { get; set; }
        public string correo_electronico { get; set; }
    
        public virtual oficina oficina { get; set; }
        public virtual tipo_documento tipo_documento1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario_contrato> usuario_contrato { get; set; }
        public virtual tipo_usuario tipo_usuario1 { get; set; }
    }
}
