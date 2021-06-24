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
    public partial class frmGestion : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Keys.Count == 0)
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }

            if (!IsPostBack)
            {
                Session["IdGestion"] = 0;
                FnCargarGestiones();
                FnAsignarAtributos();
                fnDataTableTemporal();
                
            }
        }

        private void FnAsignarAtributos()
        {
            txtCodigoEnvio1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
            txtObservacion1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");

        }

        private void FnCargarGestiones()
        {
            List<gestion> oResultado = new List<gestion>();
            try
            {
                GestionCN oGestionCN = new GestionCN();
                oResultado = oGestionCN.FnConsultarGestiones();
                cmbGestion.DataSource = oResultado;

                cmbGestion.ValueField = "id";
                cmbGestion.TextField = "nm";

                cmbGestion.DataBind();
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void cmbGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IdGestion"] = cmbGestion.Value;
        }

        protected void btnGrabar1_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = "";
            Boolean bolExiste;
            bolExiste = false;
            
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigoEnvio1.Text.Trim()) || string.IsNullOrEmpty(txtCodigoEnvio1.Text.Trim()))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");//class="btn btn-info"
                    lblMensaje.Text = "Por favor ingrese un código de envío";
                    return;
                }

                paquete objPaquete = new paquete();
                objPaquete.codigo = txtCodigoEnvio1.Text.Trim();
                PaqueteCN oPaqueteCN = new PaqueteCN();
                paquete oResultadoBusq = new paquete();
                oResultadoBusq = oPaqueteCN.FnConsultarPaquete(objPaquete);

                if (oResultadoBusq == null)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Codigo de envío no existe";
                    return;
                }

                if (int.Parse(Session["IdGestion"].ToString()) < 1)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Seleccione una gestión";
                    return;

                }

                ParametroCN oParametroCN = new ParametroCN();
                List<parametro> oResultadoParametros = new List<parametro>();
                oResultadoParametros = oParametroCN.FnConsultarParametros();
                List<parametro> oResultadoBusqParam = oResultadoParametros.Where(p => p.tipo == "ENTREGA_PRECONDICION").ToList();

                string[] strPreCondiciones = oResultadoBusqParam[0].valor1.Split(',');


                foreach (var itm1 in strPreCondiciones)
                {
                    if (itm1.ToString() == oResultadoBusq.id_ultm_evento.ToString())
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Attributes.Add("class", "btn btn-danger");
                        lblMensaje.Text = "Codigo de envío ya ha sido entregado o devuelto";
                        txtCodigoEnvio1.Focus();
                        return;
                    }
                }


                evento objEvento = new evento();
                objEvento.identificador_paquete = oResultadoBusq.identificador;
                objEvento.id_oficina = int.Parse(Session["IdOficina"].ToString());
                objEvento.id_usuario = int.Parse(Session["IdUsuario"].ToString());
                objEvento.id_tipo_evento = int.Parse(Session["IdGestion"].ToString());
                objEvento.observacion1 = txtObservacion1.Text.Trim();

                EventoCN oEvento = new EventoCN();
                oEvento.FnInsertarEvento(objEvento);

                oPaqueteCN.FnActualizarEventoPaquete(objPaquete, objEvento);

                ListItem itm = new ListItem();
                itm.Text = txtCodigoEnvio1.Text;
                
                bolExiste = ddlListado.Items.Contains(itm);
                if (bolExiste == true)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Código de envío ya existe";
                    return;
                }else if (bolExiste == false)
                {
                    DataTable dt = (DataTable)Session["DataTable"];
                    DataRow dr = dt.NewRow();
                    dr["CODIGO"] = txtCodigoEnvio1.Text.ToUpper();
                    dr["ORDEN"] = int.Parse(ddlListado.Items.Count.ToString()) + 1;
                    dr["EVENTO"] = cmbGestion.Text.ToString();
                    dr["OBSERVACION"] = txtObservacion1.Text.Trim();
                    dt.Rows.Add(dr);
                    Session["DataTable"] = dt;

                    ddlListado.Items.Add(txtCodigoEnvio1.Text.ToUpper());

                    divListadoEnvios.Visible = true;
                   
                    lblTotalEnvios.Visible = true;
                    lblTotalEnvios.Attributes.Add("class", "btn btn-info btn-sm");
                    lblTotalEnvios.Text = "Total de envíos: " + ddlListado.Items.Count.ToString();


                    btnImprimirListado.Visible = true;
                    btnImprimirListado.Enabled = true;
                    urlReporte.Visible = false;
                    
                }

                lblMensaje.Visible = true;
                lblMensaje.Attributes.Add("class", "btn btn-success");
                lblMensaje.Text = "Transacción exitosa";
                txtCodigoEnvio1.Text = string.Empty;
                txtCodigoEnvio1.Focus();
                return;

            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        private void fnDataTableTemporal()
        {

            DataTable dt = new DataTable();

            dt.Columns.Add("CODIGO", Type.GetType("System.String"));
            dt.Columns.Add("ORDEN", Type.GetType("System.String"));
            dt.Columns.Add("EVENTO", Type.GetType("System.String"));
            dt.Columns.Add("OFICINA", Type.GetType("System.String"));
            dt.Columns.Add("USUARIO", Type.GetType("System.String"));
            dt.Columns.Add("FECHA_REGISTRO", Type.GetType("System.String"));
            dt.Columns.Add("OBSERVACION", Type.GetType("System.String"));
            Session["DataTable"] = dt;
            
        }

        protected void btnImprimirListado_Click(object sender, EventArgs e)
        {
            //int intOrden;
            //intOrden = 0;
            try
            {
                //DataTable dt = fnDataTableTemporal();
                //foreach (var reg in ddlListado.Items)
                //{
                //    ++intOrden;
                //    DataRow dr = dt.NewRow();
                //    dr["CODIGO"] = reg.ToString();
                //    dr["ORDEN"] = intOrden.ToString();
                //    dr["EVENTO"] = cmbGestion.Text.ToString();

                //    dt.Rows.Add(dr);
                //}
                DataTable dt = (DataTable)Session["DataTable"];
                ParametroCN oParametroCN = new ParametroCN();
                List<parametro> oResultadoParametros = new List<parametro>();
                oResultadoParametros = oParametroCN.FnConsultarParametros();
                List<parametro> oResultadoBusq = oResultadoParametros.Where(p => p.tipo == "RUTAREPORTES").ToList();

                string[] strRutasReportes = oResultadoBusq[0].valor1.Split(',');
                string strRutaWebReportes = strRutasReportes[0].ToString();
                string strRutaFisicaReportes = strRutasReportes[1].ToString();
                string strRutaMapServer = strRutasReportes[2].ToString();
                DsReportes ds = new DsReportes();
                
                ds.Tables.Add(dt);
                ReportDataSource reportDataSource = new ReportDataSource("dsListaEnviosEventos", ds.Tables[4]);

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = strRutaWebReportes + "rptListadoEnvios.rdlc";

                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("oficina", Session["Oficina"].ToString());
                parameters[1] = new ReportParameter("usuario", Session["Usuario"].ToString());
                parameters[2] = new ReportParameter("fecha", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

                localReport.SetParameters(parameters);
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

                string strNmArchivo = "Listado_" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "") + ".pdf";
                //using (FileStream fs = File.Create(Server.MapPath("~/Reportes/" + strNmArchivo)))
                using (FileStream fs = File.Create(Server.MapPath(strRutaMapServer + strNmArchivo)))
                {
                    fs.Write(renderedBytes, 0, renderedBytes.Length);
                }

                //System.Diagnostics.Process.Start(@"C:\DesarrollosPersonales\SisCarlitosV1.1\SIS-CARLITOS\Reportes\" + strNmArchivo);
                //System.Diagnostics.Process.Start(strRutaFisicaReportes + strNmArchivo);

                string strUrlReportes = System.Configuration.ConfigurationManager.AppSettings["URLReportes"].ToString();

                urlReporte.Text = "Descargue el listado generado: " + strNmArchivo;
                urlReporte.Visible = true;
                urlReporte.NavigateUrl = strUrlReportes + strNmArchivo;

                ddlListado.Items.Clear();
                ds.Clear();
                ds.Tables.Clear();
                btnImprimirListado.Visible = false;
                lblTotalEnvios.Visible = false;
                lblTotalEnvios.Text = string.Empty;
                divListadoEnvios.Visible = false;

            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }
    }
}
