using CapaEntidad;
using CapaNegocio;

using Microsoft.Reporting.WebForms;
using SIS_CARLITOS.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS.Vistas
{
    public partial class RespaldoConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FnCargarOrdenesServicios();
                FnAsignarAtributos();
               
            }
        }

        private void FnAsignarAtributos()
        {
            txtfiltro1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
        }

        //private void FnCargarOrdenesServicios()
        //{
        //    List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = new List<SPR_CONSULTA_ORDENES_SERVICIO_Result>();
        //    lblMensaje.Text = string.Empty;
        //    try
        //    {
        //        grvOrdenesServicio.DataSource = null;
        //        grvOrdenesServicio.DataBind();
        //        List<usuario> oUsuario = (List<usuario>)Session["objUsuario"];
        //        OrdenServicioCN oOrdenServicioCN = new OrdenServicioCN();
        //        cliente oCliente = new cliente();
        //        usuario oUsuario1 = new usuario();
        //        oUsuario1.id = int.Parse(Session["IdUsuario"].ToString());
        //        orden_servicio oOrdenServicio = new orden_servicio();
        //        oResultado = oOrdenServicioCN.FnConsultarOrdenesDeServicio(1, oUsuario1, oOrdenServicio);

        //        Session["ListaOrdenesServicio"] = oResultado;

        //        grvOrdenesServicio.DataSource = oResultado;
        //        grvOrdenesServicio.DataBind();

        //        divOrdenesServicio.Visible = true;

        //    }
        //    catch (Exception ex)
        //    {

        //        string strDescripcionError = ex.Message + ex.InnerException;
        //        Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
        //    }
        //}

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = new List<SPR_CONSULTA_ORDENES_SERVICIO_Result>();
            lblMensaje.Text = string.Empty;
            string strParametro;
            strParametro = string.Empty;
            string FechaBuscada = string.Empty;
            int intSec = 0;
            try
            {

                //FnCargarOrdenesServicios();
                cliente oParametro = new cliente();
                //strParametro = txtfiltro1.Text.Trim();

                if (EsFecha(strParametro) == true)
                {
                    FechaBuscada = Convert.ToDateTime(strParametro).ToShortDateString();
                }
                oResultado = (List<SPR_CONSULTA_ORDENES_SERVICIO_Result>)Session["ListaOrdenesServicio"];
                List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultadoFiltrado = oResultado.Where((p => p.codigo_orden_servicio.Contains(strParametro)

                                                                                                || p.cliente.Contains(strParametro)
                                                                                                || p.oficina_carga.Contains(strParametro)
                                                                                                || p.servicio.Contains(strParametro)
                                                                                                || p.usuario_carga.Contains(strParametro)
                                                                                                || p.estado.Contains(strParametro)
                                                                                                || Convert.ToDateTime(p.fecha_carga).ToShortDateString() == FechaBuscada
                                                                                                )).ToList();
                foreach (var itm in oResultadoFiltrado)
                {
                    itm.orden = ++intSec;
                }
                //grvOrdenesServicio.DataSource = oResultadoFiltrado;
                //grvOrdenesServicio.DataBind();


            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        public static Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnImgSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            Session["idCliente"] = "";
            try
            {
                GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
                string strNmCliente = (((Label)namingContainer.FindControl("lbl_Nm_Cliente")).Text);
                string strIdentificacionCliente = (((Label)namingContainer.FindControl("lbl_Numero_Identificacion")).Text);
                int intId = int.Parse((((Label)namingContainer.FindControl("lblId")).Text));
                Session["idCliente"] = intId.ToString();

            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }


        //protected void grvOrdenesServicio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = new List<SPR_CONSULTA_ORDENES_SERVICIO_Result>();

        //        oResultado = (List<SPR_CONSULTA_ORDENES_SERVICIO_Result>)Session["ListaOrdenesServicio"];

        //        grvOrdenesServicio.DataSource = oResultado;
        //        grvOrdenesServicio.PageIndex = e.NewPageIndex;
        //        grvOrdenesServicio.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        string strDescripcionError = ex.Message + ex.InnerException;
        //        Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
        //    }
        //}

        protected void grvOrdenesServicio_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string  strEstado = (string)DataBinder.Eval(e.Row.DataItem, "estado");
                    if (strEstado == "Inactivo")
                    {
                        Button btn = (e.Row.FindControl("btnEliminar") as Button);
                        btn.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        private void FnImprimirOrden(int intId)
        {
            orden_servicio oOrden_Servicio = new orden_servicio();
            oOrden_Servicio.id = intId;

            OrdenServicioCN oOrdenServicioCN = new OrdenServicioCN();
            usuario oUsuario = new usuario();

            oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
            DsReportes ds = new DsReportes();
            

            List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = oOrdenServicioCN.FnConsultarOrdenesDeServicio(3, oUsuario, oOrden_Servicio).ToList();
            //DataTable dt = ClsAuxiliar.ConvertToDataTable(oResultado);
            
            //ds.Tables.Add(dt);
            //Give the collection a name (EmployeeCollection) so that we can reference it in our report designer
            ReportDataSource reportDataSource = new ReportDataSource("ds", ds.Tables[1]);

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = "../SIS-CARLITOS/Reportes/rptOrdenServicio.rdlc";
            //Array que contendrá los parámetros
            ReportParameter[] parameters = new ReportParameter[1];
            //Establecemos el valor de los parámetros
            //parameters[0] = new ReportParameter("aviso", num_aviso);
            // parameters[1] = new ReportParameter("par1", "value_par1");
            //localReport.SetParameters(parameters);
            localReport.DataSources.Add(reportDataSource);
            // localReport.DataSource

            //Pasamos el array de los parámetros al ReportViewer
            //localReport.

           
            string deviceInfo = "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                    "  <PageWidth>8.27in</PageWidth>" +
                    "  <PageHeight>11.69in</PageHeight>" +
                    "  <MarginTop>0.25in</MarginTop>" +
                    "  <MarginLeft>0.4in</MarginLeft>" +
                    "  <MarginRight>0in</MarginRight>" +
                    "  <MarginBottom>0.25in</MarginBottom>" +
                    "  <EmbedFonts>None</EmbedFonts>" +
                    "</DeviceInfo>";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes = localReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

            //Clear the response stream and write the bytes to the outputstream
            //Set content-disposition to "attachment" so that user is prompted to take an action
            //on the file (open or save)
            System.Security.PermissionSet sec = new System.Security.PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
            localReport.SetBasePermissionsForSandboxAppDomain(sec);


            //Response.Clear();
            //Response.ContentType = mimeType;
            ////Response.AddHeader("content-disposition", "attachment; filename=Notificacion." + fileNameExtension);
            ////AppendToFile("archivo.pdf", renderedBytes);
            //Response.BinaryWrite(renderedBytes);
            //Response.Flush();
            //Response.End();

            string strNmArchivo = "OrdenServicio_" + DateTime.Now.ToShortDateString().Replace("/","") + DateTime.Now.ToLongTimeString().Replace(":","") + ".pdf";
            using (FileStream fs = File.Create(Server.MapPath("~/Reportes/" + strNmArchivo)))
            {
                fs.Write(renderedBytes, 0, renderedBytes.Length);
            }
            //Response.ClearHeaders();
            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.Clear();
            //Response.Charset = "";
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment; filename=" + strNmArchivo);
            //Response.WriteFile(Server.MapPath("~/Reportes/" + strNmArchivo));

            //Response.Flush();
            //File.Delete(Server.MapPath("~/Reportes/" + "Notificacion.pdf"));
            //Response.Close();
            //Response.End();
           
            System.Diagnostics.Process.Start(@"C:\DesarrollosPersonales\SisCarlitosV1.1\SIS-CARLITOS\Reportes\" + strNmArchivo);

            //string remoteUri = "http://localhost:9226/Reportes/" + strNmArchivo;
            //string fileName = @"C:\DesarrollosPersonales\SisCarlitosV1.1\SIS-CARLITOS\Reportes\" + strNmArchivo;

            //WebClient myWebClient = new WebClient();
            //myWebClient.DownloadFile(remoteUri, fileName);
        }

        public static void AppendToFile(string fileToWrite, byte[] DT)
        {
            using (FileStream FS = new FileStream(fileToWrite, File.Exists(fileToWrite) ? FileMode.Append : FileMode.OpenOrCreate, FileAccess.Write))
            {
                FS.Write(DT, 0, DT.Length);

                FS.Flush();
                FS.Close();
            }
        }
        //private void FnImprimirOrden2(int intId)
        //{
        //    try
        //    {

        //        orden_servicio oOrden_Servicio = new orden_servicio();
        //        oOrden_Servicio.id = intId;

        //        OrdenServicioCN oOrdenServicioCN = new OrdenServicioCN();
        //        usuario oUsuario = new usuario();

        //        oUsuario.id= int.Parse(Session["IdUsuario"].ToString());


        //        List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = oOrdenServicioCN.FnConsultarOrdenesDeServicio(3, oUsuario, oOrden_Servicio).ToList();
        //        DataTable dt = ClsAuxiliar.ConvertToDataTable(oResultado);
        //        divReporte.Visible = true;
        //        rpvReporte.LocalReport.Refresh();
        //        rpvReporte.LocalReport.DataSources.Clear();


        //        rpvReporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("ds", dt));
        //        rpvReporte.LocalReport.ReportPath = Server.MapPath("~/Reportes/rptOrdenServicio.rdlc");

        //        rpvReporte.LocalReport.Refresh();



        //    }
        //    catch (Exception ex)
        //    {
        //        string strDescripcionError = ex.Message + ex.InnerException;
        //        Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
        //    }

        //}

        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {

            
                int intOrdenId = (int)ASPxGridView1.GetRowValues(e.VisibleIndex, "id");
                Session["ordenId"] = intOrdenId;

                if (e.ButtonID == "Eliminar")
                {

                }
                else if (e.ButtonID == "ImprimirOS")
                {
                    FnImprimirOrden(intOrdenId);

                }
                else if (e.ButtonID == "ImprimirGuia")
                {

                }
                //ASPxGridView1.ExportPdfToResponse(true);
            
            



        }
    }
}
