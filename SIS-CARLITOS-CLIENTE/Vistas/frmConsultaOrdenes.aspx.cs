using CapaEntidad;
using CapaNegocio;
using Microsoft.Reporting.WebForms;
using SIS_CARLITOS.DataSet;
using SIS_CARLITOS.Recursos;
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
    public partial class frmConsultaOrdenes : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Keys.Count ==0)
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }
        
                     

            usuario oUsuario = new usuario();
            oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
            orden_servicio oOrdenServicio = new orden_servicio();

            if (!IsPostBack)
            {
                FnCargarGridOrdenServicio(1,oUsuario, oOrdenServicio);
            }
        }

        private void FnCargarGridOrdenServicio(int intOpcion, usuario oUsuario, orden_servicio oOrdenServicio)
        {
            List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = new List<SPR_CONSULTA_ORDENES_SERVICIO_Result>();
            try
            {
                OrdenServicioCN oOrdenServicioCN = new OrdenServicioCN();
                oResultado = oOrdenServicioCN.FnConsultarOrdenesDeServicio(intOpcion, oUsuario, oOrdenServicio);
                Session["ListaOrdenesServicios"] = oResultado;
                grvOrdServicios.DataSource = oResultado;
                grvOrdServicios.DataBind();
                
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        private void FnImprimirOrden(int intId)
        {
            urlReporte.Visible = false;
            try
            {
                
                ParametroCN oParametroCN = new ParametroCN();
                List<parametro> oResultadoParametros = new List<parametro>();
                oResultadoParametros = oParametroCN.FnConsultarParametros();
                List<parametro> oResultadoBusq = oResultadoParametros.Where(p => p.tipo == "RUTAREPORTES").ToList();

                string[] strRutasReportes = oResultadoBusq[0].valor1.Split(',');
                string strRutaWebReportes = strRutasReportes[0].ToString();
                string strRutaFisicaReportes = strRutasReportes[1].ToString();
                string strRutaMapServer = strRutasReportes[2].ToString();
                orden_servicio oOrden_Servicio = new orden_servicio();
                oOrden_Servicio.id = intId;

                OrdenServicioCN oOrdenServicioCN = new OrdenServicioCN();
                usuario oUsuario = new usuario();

                oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
                DsReportes ds = new DsReportes();

                List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = oOrdenServicioCN.FnConsultarOrdenesDeServicio(3, oUsuario, oOrden_Servicio).ToList();
                DataTable dt = ClsAuxiliar.ConvertToDataTable(oResultado);

                ds.Tables.Add(dt);

                ReportDataSource reportDataSource = new ReportDataSource("ds", ds.Tables[4]);

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = strRutaWebReportes + "rptOrdenServicio.rdlc";
                //localReport.ReportPath = "../SIS-CARLITOS/Reportes/rptOrdenServicio.rdlc";

                localReport.DataSources.Add(reportDataSource);

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


                System.Security.PermissionSet sec = new System.Security.PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
                localReport.SetBasePermissionsForSandboxAppDomain(sec);

                string strNmArchivo = "OrdenServicio_" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "") + ".pdf";
                //using (FileStream fs = File.Create(Server.MapPath("~/Reportes/" + strNmArchivo)))
                using (FileStream fs = File.Create(Server.MapPath(strRutaMapServer + strNmArchivo)))
                {
                    fs.Write(renderedBytes, 0, renderedBytes.Length);
                }

                string strUrlReportes = System.Configuration.ConfigurationManager.AppSettings["URLReportes"].ToString();

                urlReporte.Text = "Descargue el archivo generado: " + strNmArchivo;
                urlReporte.Visible = true;
                urlReporte.NavigateUrl = strUrlReportes + strNmArchivo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void FnImprimirGuias(int intId)
        {
            urlReporte.Visible = false;
            try
            {

                ParametroCN oParametroCN = new ParametroCN();
                List<parametro> oResultadoParametros = new List<parametro>();
                oResultadoParametros = oParametroCN.FnConsultarParametros();
                List<parametro> oResultadoBusq = oResultadoParametros.Where(p => p.tipo == "RUTAREPORTES").ToList();

                string[] strRutasReportes = oResultadoBusq[0].valor1.Split(',');
                string strRutaWebReportes = strRutasReportes[0].ToString();
                string strRutaFisicaReportes = strRutasReportes[1].ToString();
                string strRutaMapServer = strRutasReportes[2].ToString();
                orden_servicio oOrden_Servicio = new orden_servicio();
                OrdenServicioCN oOrdenServicioCN = new OrdenServicioCN();
                oOrden_Servicio.id = intId;

                PaqueteCN oPaqueteCN = new PaqueteCN();
                usuario oUsuario = new usuario();

                oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
                DsReportes ds = new DsReportes();

                List<SPR_CONSULTA_ENVIO_GUIAS_Result> oResultado = oPaqueteCN.FnConsultarGuias(1, oOrden_Servicio);
                DataTable dt1 = ClsAuxiliar.ConvertToDataTable(oResultado);

                ds.Tables.Add(dt1);

                DataView dv = dt1.DefaultView;
                dv.Sort = "codigo asc";
                DataTable dt = dv.ToTable();

                ReportDataSource reportDataSource = new ReportDataSource("dsGuias", ds.Tables[4]);

                List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultadoOrdenServicio = oOrdenServicioCN.FnConsultarOrdenesDeServicio(3, oUsuario, oOrden_Servicio).ToList();
                
                LocalReport localReport = new LocalReport();
                localReport.ReportPath = strRutaWebReportes + "rptGuias.rdlc";
                //localReport.ReportPath = "../SIS-CARLITOS/Reportes/rptOrdenServicio.rdlc";

                ReportParameter[] parameters = new ReportParameter[13];
                parameters[0] = new ReportParameter("servicio", oResultadoOrdenServicio[0].servicio);
                parameters[1] = new ReportParameter("codigo_orden", oResultadoOrdenServicio[0].codigo_orden_servicio);
                parameters[2] = new ReportParameter("usuario", oResultadoOrdenServicio[0].usuario_carga);
                parameters[3] = new ReportParameter("oficina", oResultadoOrdenServicio[0].oficina_carga);
                parameters[4] = new ReportParameter("cliente", oResultadoOrdenServicio[0].cliente);
                parameters[5] = new ReportParameter("registros", oResultadoOrdenServicio[0].numero_registros_cargados.ToString());
                parameters[6] = new ReportParameter("provincia", oResultadoOrdenServicio[0].provincia);
                parameters[7] = new ReportParameter("canton", oResultadoOrdenServicio[0].canton);
                parameters[8] = new ReportParameter("numero_identificacion", oResultadoOrdenServicio[0].numero_identificacion);
                parameters[9] = new ReportParameter("fecha", oResultadoOrdenServicio[0].fecha_carga.ToString());
                parameters[10] = new ReportParameter("direccion", oResultadoOrdenServicio[0].direccion.ToString());
                parameters[11] = new ReportParameter("telefono", oResultadoOrdenServicio[0].telefono.ToString());
                parameters[12] = new ReportParameter("detalle", oResultadoOrdenServicio[0].detalle.ToString());

                localReport.SetParameters(parameters);
                localReport.DataSources.Add(reportDataSource);

                string reportType="PDF";
                string mimeType;
                string encoding;
                string fileNameExtension;

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
                
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);


                System.Security.PermissionSet sec = new System.Security.PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);
                localReport.SetBasePermissionsForSandboxAppDomain(sec);

                string strNmArchivo = "Guias_" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "") + ".pdf";

                using (FileStream fs = File.Create(Server.MapPath(strRutaMapServer + strNmArchivo)))
                {
                    fs.Write(renderedBytes, 0, renderedBytes.Length);
                }
                string strRuta01 = strRutaFisicaReportes + strNmArchivo;

                string strUrlReportes = System.Configuration.ConfigurationManager.AppSettings["URLReportes"].ToString();

                urlReporte.Text = "Descargue el archivo generado: " + strNmArchivo;
                urlReporte.Visible = true;
                urlReporte.NavigateUrl = strUrlReportes + strNmArchivo;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void FnEliminarOrden(int intId)
        {
            Boolean bolResultado;
            bolResultado = false;
            try
            {
                orden_servicio oOrden_Servicio = new orden_servicio();
                oOrden_Servicio.id = intId;

                OrdenServicioCN oOrdenServicioCN = new OrdenServicioCN();
                bolResultado = oOrdenServicioCN.FnEliminarOrdenServicio(oOrden_Servicio);
                if (bolResultado == true)
                {
                    grvOrdServicios.DataBind();
                }

            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void grvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = new List<SPR_CONSULTA_ORDENES_SERVICIO_Result>();
                oResultado = (List<SPR_CONSULTA_ORDENES_SERVICIO_Result>)Session["ListaOrdenesServicios"];
                grvOrdServicios.DataSource = oResultado;
                grvOrdServicios.PageIndex = e.NewPageIndex;
                grvOrdServicios.DataBind();
            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void btnImpOrdenServicio_Click(object sender, ImageClickEventArgs e)
        {
            int intIdOrdenTrabajo = 0;
            try
            {
                GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
                intIdOrdenTrabajo = int.Parse((((Label)namingContainer.FindControl("lblId")).Text));
                FnImprimirOrden(intIdOrdenTrabajo);

            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                
            }
        }

        protected void btnImpGuias_Click(object sender, ImageClickEventArgs e)
        {
            int intIdOrdenTrabajo = 0;
            try
            {
                GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
                intIdOrdenTrabajo = int.Parse((((Label)namingContainer.FindControl("lblId")).Text));
                FnImprimirGuias(intIdOrdenTrabajo);

            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                //Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void btnEliminarOrden_Click(object sender, ImageClickEventArgs e)
        {
            int intIdOrdenTrabajo = 0;
            string strOrdenServicio = string.Empty;
            try
            {
                GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
                intIdOrdenTrabajo = int.Parse((((Label)namingContainer.FindControl("lblId")).Text));
                strOrdenServicio = (((Label)namingContainer.FindControl("lblOrdenServicio")).Text).ToString();
                //FnEliminarOrden(intIdOrdenTrabajo);
                lblMensaje.Visible = true;
                lblMensaje.Text = "Se ha eliminado la Orden de Servicio No: " + strOrdenServicio;
                //return;
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = new List<SPR_CONSULTA_ORDENES_SERVICIO_Result>();
            urlReporte.Visible = false;
            string strFiltro = string.Empty;
            try
            {
                strFiltro = txtFiltro.Text.Trim().ToUpper();

                oResultado = (List<SPR_CONSULTA_ORDENES_SERVICIO_Result>)Session["ListaOrdenesServicios"];
                if (!strFiltro.Equals(""))
                {
                    oResultado = oResultado.Where(p => p.cliente.Contains(strFiltro) || p.canton.Contains(strFiltro) ||
                p.canton.Contains(strFiltro) || p.codigo_orden_servicio.Contains(strFiltro) || p.fecha_carga.ToString().Contains(strFiltro)
                || p.usuario_carga.Contains(strFiltro) || p.oficina_carga == strFiltro).ToList();
                }
                grvOrdServicios.DataSource = oResultado;
                grvOrdServicios.DataBind();



            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }


        //protected void grvOrdenesServicio_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        //{
        //    try
        //    {
        //        int intOrdenId = (int)grvOrdServicios.GetRowValues(e.VisibleIndex, "id");
        //        Session["ordenId"] = intOrdenId;

        //        if (e.ButtonID == "Eliminar")
        //        {
        //            FnEliminarOrden(intOrdenId);

        //        }
        //        else if (e.ButtonID == "ImprimirOS")
        //        {
        //            FnImprimirOrden(intOrdenId);

        //        }
        //        else if (e.ButtonID == "ImprimirGuia")
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        string strDescripcionError = ex.Message + ex.InnerException;
        //        Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
        //    }
        //}


    }
}
