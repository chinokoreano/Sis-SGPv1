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
    
    public partial class evento
    {
        public int id { get; set; }
        public Nullable<System.Guid> identificador_paquete { get; set; }
        public Nullable<int> id_tipo_evento { get; set; }
        public Nullable<int> id_oficina { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public string observacion1 { get; set; }
        public string observacion2 { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> estado { get; set; }
    
        public virtual gestion gestion { get; set; }
        public virtual oficina oficina { get; set; }
        public virtual paquete paquete { get; set; }
    }
}
