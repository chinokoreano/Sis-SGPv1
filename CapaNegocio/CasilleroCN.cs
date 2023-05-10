using CapaEntidad;
using CapaServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public static class CasilleroCN
    {
        public static int Obtener(int tipo)
        {
            int id=0;
            try
            {
                DateTime dtFecha = DateTime.Now;
                CrudGenerico<casillero_secuencia> crud = new CrudGenerico<casillero_secuencia>();
                casillero_secuencia casilleroBusq = crud.ObtenerUltimo(c => c.tipo == tipo);
                casillero_secuencia casillero = new casillero_secuencia();
                if (casilleroBusq == null)
                {
                    casillero.tipo = tipo;
                    casillero.fec_creacion = dtFecha;
                    casillero.usu_creacion = 1;
                    casillero.secuencia = 1;
                    casillero.casillero = casillero.secuencia.ToString().PadLeft(5,'0');
                }
                else
                {
                    casillero.tipo = tipo;
                    casillero.fec_creacion = dtFecha;
                    casillero.usu_creacion = 1;
                    casillero.secuencia = casilleroBusq.secuencia + 1;
                    casillero.casillero = casillero.secuencia.ToString().PadLeft(5, '0');
                }
                Boolean bolResultado = crud.Crear(casillero);
                
                if (bolResultado == true)
                {
                    casillero_secuencia casilleroNuevo =  crud.ObtenerPrimero(c => c.tipo == tipo && c.secuencia == casillero.secuencia);
                    id = casilleroNuevo.id;
                }
                return id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
