using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PaqueteCD
    {

        public paquete FnConsultarPaquete(paquete oPaquete)
        {
            paquete oResultado = new paquete();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.paquete.Where(p => p.codigo == oPaquete.codigo).SingleOrDefault();
                    return oResultado;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean FnInsertarPaquete(paquete oPaquete)
        {
            Boolean bolResultado = false;
            int intId;
            try
            {
                using (OPERADB DB = new OPERADB())
                {

                    var idMax = DB.paquete.Select(u => u.id)
                                    .DefaultIfEmpty(-1)
                                    .Max();
                    if (idMax == -1)
                    {
                        oPaquete.id = 1;
                    }
                    else
                    {
                        intId = idMax + 1;
                        oPaquete.id = intId;
                    }
                    DB.paquete.Add(oPaquete);
                    DB.SaveChanges();

                }
                return bolResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean FnActualizarEventoPaquete(paquete oPaquete, evento oEvento)
        {
            Boolean bolResultado = false;
            paquete oResultado = new paquete();
           
            try
            {
                using (OPERADB DB = new OPERADB())
                {

                    oResultado = DB.paquete.Where(p => p.codigo == oPaquete.codigo).SingleOrDefault();

                    if (oResultado != null)
                    {
                        oResultado.id_ultm_evento = oEvento.id_tipo_evento;
                        oResultado.fecha_ultimo_evento = oEvento.fecha_registro = DateTime.Now;
                        oResultado.id_oficina_ultm_evento = oEvento.id_oficina;
                        DB.SaveChanges();
                        bolResultado = true;
                    }
                  
                }
                return bolResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<paquete> FnConsultaOrdenServicio(paquete oOrden_Servicio)
        {
            List<paquete> oResultado = new List<paquete>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.paquete.ToList();

                }

                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void FnCargarDatosTablaTemporal(DataTable dt,Guid gLote, int intIdServicio,int intIdUsuario,int intIdCliente,string strDetalleOrdenServicio, int intIdOficina, string strIdProvinciaCarga, string strIdCantonCarga, int intIdContrato)
        {
            string strConexion = System.Configuration.ConfigurationManager.ConnectionStrings["OPERADB_DAO"].ToString();
            try
            {
                
                using (SqlConnection con = new SqlConnection(strConexion))
                {
                    con.Open();
                    string sql = null;
                    sql = "INSERT INTO PAQUETE_TEMPORAL (ID_LOTE,CODIGO,CODIGO_ALTERNO,PROVINCIA,CANTON,PARROQUIA,CALLE_PRINCIPAL,NUMERO,INTERSECCION,";
                    sql = sql + "REFERENCIA,CODIGO_POSTAL,DESTINATARIO,TELEFONO,LATITUD,LONGITUD,PESO,SEGURO,TIPO_CONTENIDO,MONTO_SEGURO,ALTO, ";
                    sql = sql + "ANCHO,PROFUNDIDAD,DATO_ADICIONAL1,DATO_ADICIONAL2,ID_OFICINA_CARGA,ID_USUARIO,ID_SERVICIO,ID_CLIENTE,DETALLE_ORDEN_SERVICIO,ID_PROVINCIA_CARGA,ID_CANTON_CARGA,ID_CONTRATO)";
                    DataColumn colIdLote = dt.Columns.Add("ID_LOTE", typeof(string));
                    colIdLote.SetOrdinal(0);

                    DataColumn colCodigo = dt.Columns.Add("CODIGO", typeof(string));
                    colCodigo.SetOrdinal(1);
                   
                    dt.Columns.Add("ID_OFICINA_CARGA", typeof(int));
                    dt.Columns.Add("ID_USUARIO", typeof(int));
                    dt.Columns.Add("ID_SERVICIO", typeof(int));
                    dt.Columns.Add("ID_CLIENTE", typeof(int));
                    dt.Columns.Add("DETALLE_ORDEN_SERVICIO", typeof(string));
                    dt.Columns.Add("ID_PROVINCIA_CARGA", typeof(string));
                    dt.Columns.Add("ID_CANTON_CARGA", typeof(string));
                    dt.Columns.Add("ID_CONTRATO", typeof(string));

                    foreach (DataRow fila in dt.Rows)
                    {
                        fila["CODIGO"] =1;
                        fila["ID_LOTE"] = gLote;
                        fila["ID_OFICINA_CARGA"] = intIdOficina;
                        fila["ID_USUARIO"] = intIdUsuario;
                        fila["ID_SERVICIO"] = intIdServicio;
                        fila["ID_CLIENTE"] = intIdCliente;
                        fila["DETALLE_ORDEN_SERVICIO"] = strDetalleOrdenServicio;
                        fila["ID_PROVINCIA_CARGA"] = strIdProvinciaCarga;
                        fila["ID_CANTON_CARGA"] = strIdCantonCarga;
                        fila["ID_CONTRATO"] = intIdContrato;
                    }

                  
                    using (SqlCommand cmd = new SqlCommand(sql + " SELECT * FROM @ParamTabla", con))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.Add(
                        new SqlParameter()
                        {
                            ParameterName = "@ParamTabla",
                            SqlDbType = SqlDbType.Structured,
                            TypeName = "paquete_temporal_tbl",
                            Value = dt,
                        });

                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Resultado FnProcesarCargaDatos(Guid gIdentificador)
        {
            Resultado oResultado = new Resultado();
            string strConexion = System.Configuration.ConfigurationManager.ConnectionStrings["OPERADB_DAO"].ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(strConexion))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SPR_CARGADATOS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("ID_LOTE", gIdentificador);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                oResultado.Codigo1 = reader["Codigo"].ToString();
                                oResultado.Mensaje1 = reader["Mensaje"].ToString();
                                oResultado.Mensaje2 = reader["Mensaje2"].ToString();
                            }
                        }
                    }
                    con.Close();
                }
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_ENVIO_GUIAS_Result> FnConsultarGuias(int intOpcion,orden_servicio oOrdenServicio)
        {
            List<SPR_CONSULTA_ENVIO_GUIAS_Result> oResultado = new List<SPR_CONSULTA_ENVIO_GUIAS_Result>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.SPR_CONSULTA_ENVIO_GUIAS(intOpcion, oOrdenServicio.id).ToList();

                }

                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_ENVIO_Result> FnTrackingPaquetes(int intOpcion, string strCodigoEnvio, string strCodigoOrdenServicio, string strDestinatario, int intUsuario, string strFecha1, string strFecha2, string strGestion,int intIdCliente)
        {

            List<SPR_CONSULTA_ENVIO_Result> oResultado = new List<SPR_CONSULTA_ENVIO_Result>();

            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.SPR_CONSULTA_ENVIO(intOpcion, strCodigoEnvio, strCodigoOrdenServicio, strDestinatario, intUsuario,strFecha1,strFecha2,strGestion,intIdCliente).ToList();

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
