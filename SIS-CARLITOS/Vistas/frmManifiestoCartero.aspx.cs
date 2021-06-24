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
    public partial class frmManifiestoCartero : System.Web.UI.Page
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
                FnCargarCarteros();
                FnAsignarAtributos();
                
            }
        }

        private void FnAsignarAtributos()
        {
            txtCodigoEnvio1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
            
        }

        private void FnCargarCarteros()
        {
            List<cartero> oResultado = new List<cartero>();
            try
            {
                CarteroCN oCarteroCN= new CarteroCN();
                oResultado = oCarteroCN.FnConsultarCarteros();
                cmbCartero.DataSource = oResultado;

                cmbCartero.ValueField = "id";
                cmbCartero.TextField = "nm_cartero";
                
                cmbCartero.DataBind();
              
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        private void FnImprimir(manifiesto_entrega oManifiestoEntrega)
        {
            urlReporte.Visible = false;
            List<SPR_CONSULTA_MANIFIESTO_Result> oResultado = new List<SPR_CONSULTA_MANIFIESTO_Result>();
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

                ListaManifiestoCN oListaManifiestoCN = new ListaManifiestoCN();
                oResultado = oListaManifiestoCN.FnImprimirListaManifiest(oManifiestoEntrega, 1);

                DataTable dt = ClsAuxiliar.ConvertToDataTable(oResultado);
                DsReportes ds = new DsReportes();
                ds.Tables.Add(dt);

                ReportDataSource reportDataSource = new ReportDataSource("dsListado", ds.Tables[4]);

                LocalReport localReport = new LocalReport();
                localReport.ReportPath = strRutaWebReportes + "rptListaManifiesto.rdlc";
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

                string strNmArchivo = "Manifiesto_" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "") + ".pdf";
                //using (FileStream fs = File.Create(Server.MapPath("~/Reportes/" + strNmArchivo)))
                using (FileStream fs = File.Create(Server.MapPath(strRutaMapServer + strNmArchivo)))
                {
                    fs.Write(renderedBytes, 0, renderedBytes.Length);
                }

                //System.Diagnostics.Process.Start(@"C:\DesarrollosPersonales\SisCarlitosV1.1\SIS-CARLITOS\Reportes\" + strNmArchivo);
                //System.Diagnostics.Process.Start(strRutaFisicaReportes + strNmArchivo);

                string strUrlReportes = System.Configuration.ConfigurationManager.AppSettings["URLReportes"].ToString();

                urlReporte.Text = "Descargue el manifiesto generado: " + strNmArchivo;
                urlReporte.Visible = true;
                urlReporte.NavigateUrl = strUrlReportes + strNmArchivo;


            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            lblMensaje1.Visible = false;
            lblMensaje1.Text = string.Empty;
            Resultado oResultado = new Resultado();
            try
            {
                if (ddlListado.Items.Count == 0)
                {
                    lblMensaje1.Visible = true;
                    lblMensaje1.Attributes.Add("class", "btn btn-danger");
                    lblMensaje1.Text = "Por favor verifique no existe códigos de envíos asignados";
                    btnGrabar.Focus();
                    return;
                }


                //if (int.Parse(Session["IdCartero"].ToString()) < 1 || )
                if (cmbCartero.SelectedIndex == -1)
                {
                    lblMensaje1.Visible = true;
                    lblMensaje1.Text = "Seleccione un cartero";
                    return;
                }

                proceso_tmp oRegistro= new proceso_tmp();
                Guid gIndentificadorProceso = Guid.NewGuid();
                ProcesoCN oProcesoCN = new ProcesoCN();
                int intControl;
                intControl = 0;
                Resultado oResultadoReg = new Resultado();
                int intOrden = 0;
                foreach (var itm in ddlListado.Items)
                {
                    ++intOrden;
                    oRegistro.estado = 0;
                    oRegistro.codigo = itm.ToString();
                    oRegistro.proceso_id = gIndentificadorProceso;
                    oRegistro.orden = intOrden;
                    oResultadoReg = oProcesoCN.FnInsertarRegistro(oRegistro);
                    
                    intControl = intControl + int.Parse(oResultadoReg.Codigo1);

                    
                }

                if (intControl >0)
                {
                    manifiesto_entrega oManifiestoEntrega = new manifiesto_entrega();
                    oManifiestoEntrega.id_cartero = int.Parse(Session["IdCartero"].ToString());
                    oManifiestoEntrega.id_oficina = int.Parse(Session["IdOficina"].ToString());
                    oManifiestoEntrega.id_usuario = int.Parse(Session["IdUsuario"].ToString());


                    ManifiestoEntregaCN oManifiestoEntregaCN = new ManifiestoEntregaCN();
                    oResultado = oManifiestoEntregaCN.FnInsertarManifiestoEntrega(oManifiestoEntrega);




                    if (oResultado.Codigo1 == "1")
                    {

                        ListaManifiestoCN oListaManifiestoCN = new ListaManifiestoCN();
                        oManifiestoEntrega.id = int.Parse(oResultado.Codigo2);
                        Resultado oResultadoInsListaManifiesto = new Resultado();

                        oResultadoInsListaManifiesto = oListaManifiestoCN.FnInsertaListaManifiesto(oManifiestoEntrega, oRegistro, 1);
                        paquete objPaquete = new paquete();
                        PaqueteCN oPaqueteCN = new PaqueteCN();
                        paquete oResultadoBusq = new paquete();
                        if (int.Parse(oResultadoInsListaManifiesto.Codigo1)>0)
                        {
                            foreach (var itm in ddlListado.Items)
                            {

                               
                                objPaquete.codigo = itm.ToString();
                               
                                oResultadoBusq = oPaqueteCN.FnConsultarPaquete(objPaquete);

                                evento objEvento = new evento();
                                objEvento.identificador_paquete = oResultadoBusq.identificador;
                                objEvento.id_oficina = int.Parse(Session["IdOficina"].ToString());
                                objEvento.id_usuario = int.Parse(Session["IdUsuario"].ToString());
                                objEvento.id_tipo_evento = 2;
                                objEvento.observacion1 = "En proceso de distribución - Cartero: " + cmbCartero.SelectedItem.ToString();

                                EventoCN oEvento = new EventoCN();
                                oEvento.FnInsertarEvento(objEvento);

                                oPaqueteCN.FnActualizarEventoPaquete(objPaquete, objEvento);

                            }

                            

                            lblMensaje1.Visible = false;
                            FnImprimir(oManifiestoEntrega);
                            return;
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void cmbGestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IdCartero"] = cmbCartero.Value;
        }

       
        protected void cmbCartero_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IdCartero"] = cmbCartero.Value;
        }

        protected void btnAgregar1_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            lblMensaje.Visible = false;
            Boolean bolResultado = new Boolean();
            bolResultado = false;
            Boolean bolExiste = new Boolean();
            bolExiste = false;
            try
            {
                if (cmbCartero.SelectedIndex == -1)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Seleccione una cartero";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCodigoEnvio1.Text.Trim()) || string.IsNullOrEmpty(txtCodigoEnvio1.Text.Trim()))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Por favor ingrese un código de envío";
                    return;
                }

                ListItem itm = new ListItem();
                itm.Text = txtCodigoEnvio1.Text;
                bolExiste = ddlListado.Items.Contains(itm);
                if (bolExiste == true)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Código de envío ya existe";
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
                    lblMensaje.Text = "Código de envío no existe";
                    return;
                }

                evento objEvento = new evento();
                objEvento.identificador_paquete = oResultadoBusq.identificador;

                EventoCN oEventoCN = new EventoCN();
                List<evento> oResultadoEvtBusq = new List<evento>();
                oResultadoEvtBusq = oEventoCN.FnConsultarEvento(objEvento);

                List<evento> oResultadoEvtOrder = oResultadoEvtBusq.OrderByDescending(ProcedureTime => ProcedureTime.fecha_registro).ToList();

                GestionCN oGestionCN = new GestionCN();
                bolResultado = oGestionCN.FnValidarGestion(oResultadoEvtOrder[0]);

                if (bolResultado == true)
                {
                    ddlListado.Items.Add(txtCodigoEnvio1.Text.ToUpper());
                    ddlListado.DataBind();

                    lblTotalEnvios.Visible = true;
                    lblTotalEnvios.Attributes.Add("class", "btn btn-info btn-sm");
                    lblTotalEnvios.Text = "Total de envíos: " + ddlListado.Items.Count.ToString();

                    txtCodigoEnvio1.Text = string.Empty;
                    txtCodigoEnvio1.Focus();

                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Ultima gestión del envío no es válida";
                    return;
                }
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }
    }
}
