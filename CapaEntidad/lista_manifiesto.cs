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
    
    public partial class lista_manifiesto
    {
        public int id { get; set; }
        public int id_manifiesto { get; set; }
        public Nullable<System.Guid> identificador_paquete { get; set; }
        public Nullable<int> orden { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
    
        public virtual manifiesto_entrega manifiesto_entrega { get; set; }
        public virtual paquete paquete { get; set; }
    }
}