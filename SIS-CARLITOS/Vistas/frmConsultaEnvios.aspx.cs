using CapaEntidad;
using CapaNegocio;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using Microsoft.Reporting.WebForms;
using SIS_CARLITOS.DataSet;
using SIS_CARLITOS.Recursos;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS.Vistas
{
    public partial class frmConsultaEnvios : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Keys.Count == 0)
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }
            usuario oUsuario = new usuario();
            oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
            orden_servicio oOrdenServicio = new orden_servicio();

            if (!IsPostBack)
            {
                FnCargarClientes();

            }


        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["identificador"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            Session["opcion"] = "1";
            //string strId = Session["identificador_paquete"].ToString();
        }

        private void FnCargarClientes()
        {
            List<SPR_CONSULTA_USUARIO_CONTRATO_Result> oResultado = new List<SPR_CONSULTA_USUARIO_CONTRATO_Result>();
            try
            {
                cliente oCliente = new cliente();

                ClienteCN oClienteCN = new ClienteCN();
                usuario oUsuario = new usuario();
                oUsuario.id = int.Parse(Session["IdUsuario"].ToString());


                List<usuario> objUsuario = (List<usuario>)Session["objUsuario"];
                if (objUsuario[0].tipo_usuario == 0 || objUsuario[0].tipo_usuario == 1)//tipo de usuario 0 - 1 administrador operador
                {
                    oResultado = oClienteCN.FnConsultarClientesContratos(3, objUsuario[0], oCliente);
                }
                else if (objUsuario[0].tipo_usuario == 2)//tipo de cliente 2 corresponde a cliente corporativo
                {
                    oResultado = oClienteCN.FnConsultarClientesContratos(2, objUsuario[0], oCliente);
                }

                cmbClientes.DataSource = oResultado;
                cmbClientes.ValueField = "id_codigo_contrato";
                cmbClientes.TextField = "nm_cliente";
                cmbClientes.DataBind();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvEventos.DataSource = null;
            grvEventos.DataBind();
            grvEventos.Visible = false;
            divBotonImprimir.Visible = false;

            List<SPR_CONSULTA_ENVIO_Result> oResultado = new List<SPR_CONSULTA_ENVIO_Result>();
            try
            {


                if (ddlFiltro.SelectedValue.ToString() == "1")
                {
                    if (!string.IsNullOrEmpty(txtFiltro1.Text) || !string.IsNullOrWhiteSpace(txtFiltro1.Text))
                    {
                        PaqueteCN oPaqueteCN = new PaqueteCN();
                        oResultado = oPaqueteCN.FnTrackingPaquetes(1, txtFiltro1.Text.Trim(), null, null, 0, null, null, null, 0).ToList();
                    }
                }
                if (ddlFiltro.SelectedValue.ToString() == "2")
                {
                    if (!string.IsNullOrEmpty(txtFiltro1.Text) || !string.IsNullOrWhiteSpace(txtFiltro1.Text))
                    {
                        PaqueteCN oPaqueteCN = new PaqueteCN();
                        oResultado = oPaqueteCN.FnTrackingPaquetes(2, null, null, txtFiltro1.Text.Trim(), 0, null, null, null, 0).ToList();
                    }
                }
                if (ddlFiltro.SelectedValue.ToString() == "3")
                {
                    if (!string.IsNullOrEmpty(txtFiltro1.Text) || !string.IsNullOrWhiteSpace(txtFiltro1.Text))
                    {
                        PaqueteCN oPaqueteCN = new PaqueteCN();
                        oResultado = oPaqueteCN.FnTrackingPaquetes(3, null, txtFiltro1.Text.Trim(), null, 0, null, null, null, 0).ToList();
                    }
                }
                if (ddlFiltro.SelectedValue.ToString() == "4")
                {
                    if (!string.IsNullOrEmpty(txtFechaCargaInicio.Text) && !string.IsNullOrWhiteSpace(txtFechaCargaInicio.Text)
                        && !string.IsNullOrEmpty(txtFechaCargaFin.Text) && !string.IsNullOrWhiteSpace(txtFechaCargaFin.Text) && cmbClientes.SelectedIndex != -1)
                    {
                        PaqueteCN oPaqueteCN = new PaqueteCN();
                        oResultado = oPaqueteCN.FnTrackingPaquetes(4, null, null, null, int.Parse(Session["IdUsuario"].ToString()), txtFechaCargaInicio.Text, txtFechaCargaFin.Text, null, int.Parse(cmbClientes.SelectedItem.Value.ToString())).ToList();
                    }
                }
                if (ddlFiltro.SelectedValue.ToString() == "5")
                {
                    if (!string.IsNullOrEmpty(txtFiltro1.Text) || !string.IsNullOrWhiteSpace(txtFiltro1.Text))
                    {
                        PaqueteCN oPaqueteCN = new PaqueteCN();
                        oResultado = oPaqueteCN.FnTrackingPaquetes(5, txtFiltro1.Text.Trim(), null, null, 0, null, null, null, 0).ToList();
                    }
                }

                if (oResultado.Count > 0)
                {

                    Session["ListadoEnvios"] = oResultado;
                    grvEnvios.DataSource = oResultado;
                    grvEnvios.DataBind();
                    grvEnvios.Visible = true;
                    divBotonImprimir.Visible = true;
                }
                else
                {
                    grvEnvios.DataSource = null;
                    grvEnvios.DataBind();
                    grvEnvios.Visible = true;

                    grvEventos.DataSource = null;
                    grvEventos.DataBind();
                    grvEventos.Visible = false;

                    divBotonImprimir.Visible = false;

                }

            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + Server.UrlEncode(strDescripcionError));
            }
        }

        protected void btnImgSeleccionar_Click(object sender, ImageClickEventArgs e)
        {
            Session["idPaquete"] = "";
            try
            {
                grvEventos.DataSource = null;
                grvEventos.DataBind();
                grvEventos.Visible = false;
                GridViewRow namingContainer = (GridViewRow)((ImageButton)sender).NamingContainer;
                string strIdentificador = (((Label)namingContainer.FindControl("lblId")).Text);

                EventoCN oEventoCN = new EventoCN();
                evento oEvento = new evento();
                oEvento.identificador_paquete = Guid.Parse(strIdentificador.ToString());

                List<SPR_CONSULTA_EVENTOS_Result> oResultado = oEventoCN.FnTrackingEvento(1, oEvento);
                grvEventos.DataSource = oResultado;
                grvEventos.DataBind();
                grvEventos.Visible = true;

                Session["ListaEventos"] = oResultado;
                
                divImprimirHistorial.Visible = true;
            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void grvEnvios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                List<SPR_CONSULTA_ENVIO_Result> oResultado = new List<SPR_CONSULTA_ENVIO_Result>();
                oResultado = (List<SPR_CONSULTA_ENVIO_Result>)Session["ListadoEnvios"];
                grvEnvios.DataSource = oResultado;
                grvEnvios.PageIndex = e.NewPageIndex;
                grvEnvios.DataBind();
            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void ddlFiltro_SelectedIndexChanged1(object sender, EventArgs e)
        {
            txtFiltro1.Text = string.Empty;
            grvEnvios.DataSource = null;
            grvEnvios.DataBind();
            grvEventos.DataSource = null;
            grvEventos.DataBind();
            grvEnvios.Visible = false;
            grvEventos.Visible = false;
            divBotonImprimir.Visible = false;
            divImprimirHistorial.Visible = false;

            if (ddlFiltro.SelectedValue == "4")
            {
                txtFiltro1.Visible = false;
                txtFechaCargaInicio.Visible = true;
                txtFechaCargaFin.Visible = true;
                cmbClientes.Enabled = true;
            }
            else if (ddlFiltro.SelectedValue.ToString() == "1" || ddlFiltro.SelectedValue.ToString() == "2" || ddlFiltro.SelectedValue.ToString() == "3" || ddlFiltro.SelectedValue.ToString() == "5")
            {

                txtFiltro1.Visible = true;
                txtFechaCargaFin.Visible = false;
                txtFechaCargaInicio.Visible = false;
                cmbClientes.Enabled = false;
            }
        }


        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                List<SPR_CONSULTA_ENVIO_Result> oResultado = new List<SPR_CONSULTA_ENVIO_Result>();
                oResultado = (List<SPR_CONSULTA_ENVIO_Result>)Session["ListadoEnvios"];
                DataTable dt = ClsAuxiliar.ConvertToDataTable(oResultado);
                DsReportes ds = new DsReportes();
                ds.Tables.Add(dt);

                rpvReporte.LocalReport.DataSources.Clear();
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("usuario", Session["Usuario"].ToString());
                parameters[1] = new ReportParameter("oficina", Session["Oficina"].ToString());

                rpvReporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsGestionEnvios", dt));
                rpvReporte.LocalReport.ReportPath = Server.MapPath("~/Reportes/rptGestionEnvios.rdlc");

                rpvReporte.LocalReport.SetParameters(parameters);
                string strNmArchivo = "Rpt_GestionEnvios_" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "");
                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;


                //Export the RDLC Report to Byte Array.
                byte[] bytes = rpvReporte.LocalReport.Render("Excel", null, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                //Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC." + extension);
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + strNmArchivo + "." + extension);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();


            }
            catch (Exception ex)
            {

                string descripcion_error = ex.Message;

            }
        }

        protected void btnImprimirHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                          

                List<SPR_CONSULTA_EVENTOS_Result> oResultado = (List<SPR_CONSULTA_EVENTOS_Result>)Session["ListaEventos"];
                
                DataTable dt = ClsAuxiliar.ConvertToDataTable(oResultado);
                DsReportes ds = new DsReportes();
                ds.Tables.Add(dt);

                rpvReporte.LocalReport.DataSources.Clear();
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("usuario", Session["Usuario"].ToString());
                parameters[1] = new ReportParameter("oficina", Session["Oficina"].ToString());

                rpvReporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("ds", ds.Tables[4]));
                rpvReporte.LocalReport.ReportPath = Server.MapPath("~/Reportes/rptHistorialPaquete.rdlc");

                rpvReporte.LocalReport.SetParameters(parameters);
                string strNmArchivo = "Rpt_Historial_Paquete" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "");
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
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                
                //Export the RDLC Report to Byte Array.
                byte[] bytes = rpvReporte.LocalReport.Render("PDF", deviceInfo, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                //Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC." + extension);
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + strNmArchivo + "." + extension);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();


            }
            catch (Exception ex)
            {

                string descripcion_error = ex.Message;
            }
        }
    }
}
