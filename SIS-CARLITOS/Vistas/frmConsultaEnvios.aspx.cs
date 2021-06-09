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


            }
        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["identificador"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            Session["opcion"] = "1";
            //string strId = Session["identificador_paquete"].ToString();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grvEventos.DataSource = null;
            grvEventos.DataBind();
            grvEventos.Visible = false;

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
                Session["ListadoEnvios"] = oResultado;
                grvEnvios.DataSource = oResultado;
                grvEnvios.DataBind();


            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
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

                //int intId = int.Parse((((Label)namingContainer.FindControl("lblId")).Text));
                //int intIdContrato = int.Parse((((Label)namingContainer.FindControl("lblIdContrato")).Text));
                //Session["idContrato"] = intIdContrato.ToString();
                //Session["idCliente"] = intId.ToString();
                //txtCliente.Text = strNmCliente;
                //txtIdentificacion.Text = strIdentificacionCliente;
                //txtIdCliente.Text = intId.ToString();

                //divControl.Visible = true;
                //if (int.Parse(Session["ControlPantalla"].ToString()) == 1)//1 = Control para mostrar opcion para el cliente corporativo
                //{
                //    divDatosCarga.Visible = true;
                //    divBuscar.Visible = true;
                //}
                //else
                //{
                //    divClientes.Visible = false;

                //}

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
        }

        protected void btnExportar_Click1(object sender, EventArgs e)
        {

            List<SPR_CONSULTA_ENVIO_Result> oResultado = (List<SPR_CONSULTA_ENVIO_Result>)Session["ListadoEnvios"];
            DataTable dt = ClsAuxiliar.ConvertToDataTable(oResultado);

            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            
            FnExportarAExcel(dgGrid);
           
        }

        private void FnExportarAExcel(DataGrid dgv)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            System.Web.UI.Page pageToRender = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(dgv);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + "listadoEnvios");
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }

        //    private void FnExportarAExcel(DataGrid dgv)
        //{
        //    try
        //    {
        //        ParametroCN oParametroCN = new ParametroCN();
        //        List<parametro> oResultadoParametros = new List<parametro>();
        //        oResultadoParametros = oParametroCN.FnConsultarParametros();
        //        List<parametro> oResultadoBusq = oResultadoParametros.Where(p => p.tipo == "RUTAREPORTES").ToList();

        //        string[] strRutasReportes = oResultadoBusq[0].valor1.Split(',');
        //        string strRutaWebReportes = strRutasReportes[0].ToString();
        //        string strRutaFisicaReportes = strRutasReportes[1].ToString();

        //        if (dgv.Items.Count > 0)
        //        {


        //            string filename = "Envio_"; //+ DateTime.Now.ToString();
        //            System.IO.StringWriter tw = new System.IO.StringWriter();
        //            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


        //            //Get the HTML for the control.
        //            dgv.RenderControl(hw);
        //            //Write the HTML back to the browser.
        //            //Response.ContentType = application/vnd.ms-excel;
        //            Response.Charset = "UTF-8";
        //            Response.ContentEncoding = Encoding.Default;
        //            Response.ContentType = "application/vnd.ms-excel";
        //            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + ".xls");

        //            //Response.Write(tw.ToString());
        //            Response.WriteFile(strRutaFisicaReportes + filename);
        //            Response.End();

                   
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

       
        
    }
}
