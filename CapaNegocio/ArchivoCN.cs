using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ArchivoCN
    {
        public DataTable FnCargarArchivo(string strNombreArchivo)
        {
            OleDbConnection oledbConn = null;
            System.Data.DataTable dt = null;
            OleDbDataAdapter da = null;
            DataSet ds = new DataSet();

            ParametroCN oParametroCN = new ParametroCN();
            List<parametro> oResultado = new List<parametro>();
            oResultado = oParametroCN.FnConsultarParametros();

            List<parametro> oResultadoBusq = new List<parametro>();
            oResultadoBusq = oResultado.Where(p => p.tipo == "RUTAARCHIVOCARGADO").ToList();

            string strRutaArchivoCargado = oResultadoBusq[0].valor1.ToString();

            oResultadoBusq.Clear();
            oResultadoBusq = oResultado.Where(p => p.tipo == "NMHOJAARCHIVO").ToList();
            string strNmHoja = oResultadoBusq[0].valor1.ToString();

            oResultadoBusq.Clear();
            oResultadoBusq = oResultado.Where(p => p.tipo == "CAMPOSARCHIVO").ToList();
            string strCamposArchivo = oResultadoBusq[0].valor1.ToString();

            oResultadoBusq.Clear();
            oResultadoBusq = oResultado.Where(p => p.tipo == "CAMPOSARCHIVOOBLIGATORIO").ToList();
            string [] strCamposObligatorios = oResultadoBusq[0].valor1.ToString().Split(',');

            try
            {
                if (strRutaArchivoCargado.Trim() == "" || strRutaArchivoCargado == null)
                    throw new Exception("No existe definición de ruta de archivo en la tabla parámetros.");

                if (strRutaArchivoCargado.LastIndexOf('\\') != (strRutaArchivoCargado.Length - 1))
                    strRutaArchivoCargado = strRutaArchivoCargado + "\\";

                string connString = string.Empty;

                if (System.IO.Path.GetExtension(strNombreArchivo.ToLower()) == ".xlsx")
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strRutaArchivoCargado + strNombreArchivo + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";
                }
                else
                {
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strRutaArchivoCargado + strNombreArchivo + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                }

                oledbConn = new OleDbConnection(connString);
                oledbConn.Open();
                
                
                if (strCamposArchivo == String.Empty)
                {
                    throw new Exception("No existe definición de campos en la tabla parámetros.");
                }
                else
                {
                    if (strCamposArchivo != String.Empty)
                    {
                        string strSQL = "";
                        strSQL = "SELECT * FROM [" + strNmHoja.Trim() + "$]";
                        da = new OleDbDataAdapter(strSQL, oledbConn);
                        dt = new System.Data.DataTable();
                        da.Fill(dt);
                        //elimina las filas en blanco del datatable
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            if (dt.Rows[i][0].ToString() == String.Empty && dt.Rows[i][1].ToString() == String.Empty)
                            {
                                dt.Rows.RemoveAt(i);
                            }
                        }
                        
                        while (dt.Columns.Count > 22)
                        {
                            {
                               dt.Columns.RemoveAt(dt.Columns.Count -1);
                            }
                        }
                        

                        //if (dt.Columns.Count > 22)//NUMERO DE COLUMNAS QUE DEBE TENER EL ARCHIVO
                        //{
                            
                        //    throw new Exception("Por favor verifique que el archivo tenga solo contenga el número de columnas definidas en el formato de carga");

                        //}

                        


                        if (dt.Rows.Count == 0)
                        {
                            throw new Exception("No existe datos en el archivo.");
                        }

                        string[] strListaCampos = strCamposArchivo.ToString().Split(',');
                        FnValidarColumnasArchivo(dt, strListaCampos);
                        string strResultadoValidacionCampo = fnValidaCamposArchivo(dt, strCamposObligatorios);
                        if (!strResultadoValidacionCampo.Equals("-1"))
                        {
                            throw new Exception(strResultadoValidacionCampo);
                        }

                    }
                }
                oledbConn.Close();
                return dt;

            }
            catch (Exception ex)
            {
                oledbConn.Close();
                throw ex;
            }
        }

        public void FnValidarColumnasArchivo(DataTable dt, string[] strListaCampos)
        {
            try
            {
                Boolean bolExisteCampo;
                bolExisteCampo = false;

                foreach (var itm in strListaCampos)
                {
                    foreach (System.Data.DataColumn columna in dt.Columns)
                    {
                        if (columna.ColumnName.Trim().ToUpper() == itm.ToString().ToUpper())
                        {
                            bolExisteCampo = true;
                            break;
                        }
                    }
                    if (bolExisteCampo == false)
                    {
                        throw new Exception("En el archivo no existe la columna: " + itm.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string fnValidaCamposArchivo(DataTable dt, string[] strListaCampos)
        {

            string strCampo = string.Empty;
            int intFila;
            string strMensaje = "-1";
            intFila = 0;
           
                        
            foreach (DataRow fila in dt.Rows)
            {
                intFila++;
                foreach (DataColumn columna in dt.Columns)
                {
                    for (int i = 0; i < strListaCampos.Length; i++)
                    {
                        strCampo = strListaCampos[i].ToString();
                        if (columna.ColumnName.Trim() == strCampo.Trim())
                        {
                            if (fila[strCampo].ToString().Trim() == string.Empty)
                            {
                                strMensaje = strMensaje + " - Fila: " + intFila.ToString() + " No existe información o el dato no esta en el formato correcto. Campo: " + strCampo + Environment.NewLine;
                            }
                        }
                    }
                }
            }

            return strMensaje;

        }

        public DataTable FnDepuraDatos(DataTable dt)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["CALLE_PRINCIPAL"] = CleanInput(dr["CALLE_PRINCIPAL"].ToString());
                    dr["NUMERO"] = CleanInput(dr["NUMERO"].ToString());
                    dr["INTERSECCION"] = CleanInput(dr["INTERSECCION"].ToString());
                    dr["REFERENCIA"] = CleanInput(dr["REFERENCIA"].ToString());
                    dr["DESTINATARIO"] = CleanInput(dr["DESTINATARIO"].ToString());
                    dr["TELEFONO"] = CleanInput(dr["TELEFONO"].ToString());
                    dr["CODIGO_POSTAL"] = CleanInput(dr["CODIGO_POSTAL"].ToString());
                }

                return dt;
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }

        public static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-\\%#\s]", "",
                                        RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            // If we timeout when replacing invalid characters,
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }
    }
}
