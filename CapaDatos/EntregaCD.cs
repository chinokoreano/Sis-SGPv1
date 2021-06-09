using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EntregaCD
    {
      
        public Resultado FnInsertarEntrega(entrega oEntrega)
        {
            int intId;
            intId = 0;
            Resultado oResultado = new Resultado();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    entrega objEntrega = new entrega();
                    var idMax = DB.evento.Select(u => u.id)
                                   .DefaultIfEmpty(-1)
                                   .Max();
                    if (idMax == -1)
                    {
                        objEntrega.id = 1;
                    }
                    else
                    {
                        intId = idMax + 1;
                        objEntrega.id = intId;
                    }

                    objEntrega.identificador_paquete = oEntrega.identificador_paquete;
                    objEntrega.fecha_registro = DateTime.Now;
                    objEntrega.fecha_entrega = oEntrega.fecha_entrega;
                    objEntrega.hora_entrega = oEntrega.hora_entrega;
                    objEntrega.receptor = oEntrega.receptor;
                    objEntrega.identificacion_receptor = oEntrega.identificacion_receptor;
                    objEntrega.observacion = oEntrega.observacion;
                    objEntrega.locacion_entrega = oEntrega.locacion_entrega;
                    objEntrega.control_dir_entrega = oEntrega.control_dir_entrega;
                    objEntrega.direccion_actualizada = oEntrega.direccion_actualizada;
                    objEntrega.estado = 1;
                    objEntrega.id_oficina = oEntrega.id_oficina;
                    objEntrega.id_usuario = oEntrega.id_usuario;
                    objEntrega.latitud = oEntrega.latitud;
                    objEntrega.longitud = oEntrega.longitud;
                    objEntrega.registro_fotografico = oEntrega.registro_fotografico;
                    

                    DB.entrega.Add(objEntrega);
                    DB.SaveChanges();

                    oResultado.Codigo1 = "1";

                }
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
