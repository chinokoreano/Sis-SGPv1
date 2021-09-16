using CapaEntidad;
using CapaNegocio;
using SIS_CARLITOS.Recursos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS.Vistas
{
    public partial class frmCargaMasiva : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Keys.Count == 0)
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }


            if (!IsPostBack)
            {
                Session["ControlPantalla"] = -1;
                FnCargarServicios();
                FnAsignarAtributos();
                FnCargarClientes();
                FnCargarUbicacionesGeograficas();
                
            }
        }

        private void FnAsignarAtributos()
        {
            txtfiltro1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
            txtObservacion.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
        }

        private void FnCargarClientes()
        {
            List<SPR_CONSULTA_USUARIO_CONTRATO_Result> oResultado = new List<SPR_CONSULTA_USUARIO_CONTRATO_Result>();
            lblMensaje.Text = string.Empty;
            try
            {
                List<usuario> oUsuario = (List<usuario>)Session["objUsuario"];
                if (oUsuario[0].tipo_usuario == 2)//tipo de cliente 2 corresponde a cliente corporativo
                {
                    ClienteCN oClienteCN = new ClienteCN();
                    cliente oCliente = new cliente();
                    usuario oUsuario1 = new usuario();
                    oUsuario1.id = int.Parse(Session["IdUsuario"].ToString());

                    oResultado = oClienteCN.FnConsultarClientesContratos(2, oUsuario1, oCliente);

                    Session["ListaClientes"] = oResultado;

                    grvClientes.DataSource = oResultado;
                    grvClientes.DataBind();

                    divClientes.Visible = true;
                    ddlTipoFiltro.Visible = false;
                    txtfiltro1.Visible = false;
                    btnBuscar.Visible = false;

                    Session["ControlPantalla"] = 1;
                }

            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        private void FnCargarServicios()
        {
            try
            {
                ServicioCN oServicioCN = new ServicioCN();
                List<servicio> oResultado = new List<servicio>();
                oResultado = oServicioCN.FnConsultarServicios();
                if (oResultado.Count > 0)
                {
                    ddlServicio.Items.Clear();
                    ddlServicio.DataSource = oResultado;
                    ddlServicio.DataValueField = "id";
                    ddlServicio.DataTextField = "nm_servicio";
                    ddlServicio.DataBind();
                }
            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);

            }
        }

        private void FnCargarUbicacionesGeograficas()
        {
            List<SPR_CONSULTA_UBICACIONES_GEOGRAFICAS_Result> oResultado = new List<SPR_CONSULTA_UBICACIONES_GEOGRAFICAS_Result>();
            try
            {
                UbicacionGeograficaCN oUbicacionGeograficaCN = new UbicacionGeograficaCN();
                oResultado = oUbicacionGeograficaCN.FnConsultarUbicacionesGeograficas(1);
                cmbLocalidad.DataSource = oResultado;

                cmbLocalidad.ValueField = "id_canton";
                cmbLocalidad.TextField = "nm_canton";
                
                cmbLocalidad.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<SPR_CONSULTA_USUARIO_CONTRATO_Result> oResultado = new List<SPR_CONSULTA_USUARIO_CONTRATO_Result>();
            lblMensaje.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtfiltro1.Text.Trim()) || string.IsNullOrWhiteSpace(txtfiltro1.Text.Trim()))
                {
                    
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Por favor ingrese un número de indentificación, nombre o razón social.";
                    divClientes.Visible = false;


                }
                else
                {
                    grvClientes.DataSource = null;
                    grvClientes.DataBind();
                    cliente oCliente = new cliente();
                    if (int.Parse(ddlTipoFiltro.SelectedValue.ToString()) == 1)
                    {
                        oCliente.nm_cliente = txtfiltro1.Text.Trim() + '%';
                    }
                    else
                    {
                        oCliente.numero_identificacion = txtfiltro1.Text.ToString() + '%';
                    }
                    ClienteCN oClienteCN = new ClienteCN();
                    usuario oUsuario = new usuario();
                    oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
                    
                    oResultado = oClienteCN.FnConsultarClientesContratos(1, oUsuario, oCliente);
                    
                    
                    
                    Session["ListaClientes"] = oResultado;
                    
                    grvClientes.DataSource = oResultado;
                    grvClientes.DataBind();

                    divClientes.Visible = true;
                    lblMensaje.Visible = false;
                }
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string strRutaArchivoCargado = string.Empty;
            DataTable dt = new DataTable();
            lblMensaje1.Visible = false;
            try
            {

                if (String.IsNullOrEmpty(txtIdCliente.Text.Trim()) || string.IsNullOrEmpty(txtCliente.Text.Trim())||
                    String.IsNullOrEmpty(txtIdentificacion.Text.Trim()))
                  
                {
                    lblMensaje1.Visible = true;
                    lblMensaje1.Attributes.Add("class", "btn btn-danger");
                    lblMensaje1.Text = "Por favor seleccione el cliente";
                    return;

                }


                if (cmbLocalidad.SelectedIndex == -1)
                {
                    lblMensaje1.Visible = true;
                    lblMensaje1.Attributes.Add("class", "btn btn-danger");
                    lblMensaje1.Text = "Por favor seleccione la locación";
                    return;

                }

                if (string.IsNullOrEmpty(txtObservacion.Text.Trim())) 
                {
                    lblMensaje1.Visible = true;
                    lblMensaje1.Attributes.Add("class", "btn btn-danger");
                    lblMensaje1.Text = "Por favor ingrese el detalle de la carga";
                    return;

                }


                ParametroCN oParametroCN = new ParametroCN();
                List<parametro> oResultado = new List<parametro>();
                oResultado = oParametroCN.FnConsultarParametros();
                List<parametro> oResultadoBusq = oResultado.Where(p => p.tipo == "RUTAARCHIVOCARGADO").ToList();
                strRutaArchivoCargado = oResultadoBusq[0].valor1.ToString();

                if (strRutaArchivoCargado == "")
                    throw new Exception("Error de carga: Error de configuración de la aplicación.");

                if (strRutaArchivoCargado.LastIndexOf('\\') != (strRutaArchivoCargado.Length - 1))
                    strRutaArchivoCargado = strRutaArchivoCargado + "\\";

                if (FupArchivo.HasFile == true && (System.IO.Path.GetExtension(FupArchivo.FileName).ToUpper() == ".XLS" ||
                    System.IO.Path.GetExtension(FupArchivo.FileName).ToUpper() == ".XLSX"))
                {
                    string strNombreArchivo = System.IO.Path.GetFileName(FupArchivo.FileName);
                    FupArchivo.SaveAs(strRutaArchivoCargado + strNombreArchivo);
                    ArchivoCN oArchivoCN = new ArchivoCN();
                    dt = oArchivoCN.FnCargarArchivo(strNombreArchivo);

                    DataTable dtDepurado = new DataTable();
                    dtDepurado = oArchivoCN.FnDepuraDatos(dt); //Depuracion de caracteres especiales

                    PaqueteCN oPaqueteCN = new PaqueteCN();
                    Guid gLote = Guid.NewGuid();

                    List<usuario> oUsuario = (List<usuario>)Session["objUsuario"];

                    int intIdServicio = int.Parse(ddlServicio.SelectedValue.ToString());
                    int intIdOficina = int.Parse(oUsuario[0].id_oficina.ToString());
                    int intIdUsuario = int.Parse(oUsuario[0].id.ToString());
                    int intIdCliente = int.Parse(Session["idCliente"].ToString());
                    int intIdContrato = int.Parse(Session["idContrato"].ToString());
                    string strDetalleDeOrdenServicio = txtObservacion.Text.Trim();
                   
                    string strIdUbicacion = string.Empty;
                    strIdUbicacion = cmbLocalidad.SelectedItem.Value.ToString();
                    string[] strUbicaionGeografica = strIdUbicacion.Split('-');
                    string strIdProvinciaCarga = string.Empty;
                    string strIdCantonCarga = string.Empty;
                    strIdProvinciaCarga = strUbicaionGeografica[0].ToString();
                    strIdCantonCarga = strUbicaionGeografica[1].ToString();

                    //Carga a tabla temporal
                    oPaqueteCN.FnCargarDatosTablaTemporal(dtDepurado, gLote, intIdServicio,intIdUsuario, intIdCliente, strDetalleDeOrdenServicio,intIdOficina, strIdProvinciaCarga, strIdCantonCarga,intIdContrato);

                    Resultado oResultadoProceso = new Resultado();
                    oResultadoProceso = oPaqueteCN.FnProcesarCargaDatos(gLote);

                    if (oResultadoProceso.Codigo1 == "1")
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Attributes.Add("class", "btn btn-success");
                        lblMensaje.Text = "Orden de Servicio Generada: " + oResultadoProceso.Mensaje1;
                        btnGuardar.Visible = false;
                        return;
                    }
                    else
                    {
                        
                        SucesoCN oSucesoCN = new SucesoCN();
                        suceso objSuceso = new suceso();
                        objSuceso.id_lote = gLote;
                        List<suceso> oResultadoSucesos = new List<suceso>();
                        oResultadoSucesos = oSucesoCN.FnConsultarSucesos(objSuceso);
                        string strResultado;
                        strResultado = string.Empty;
                        foreach (var itm in oResultadoSucesos)
                        {
                            strResultado = strResultado + itm.mensaje;
                        }
                        lblMensaje1.Visible = true;
                        lblMensaje1.Attributes.Add("class", "btn btn-danger");
                        lblMensaje1.Text = "Problemas al realizar proceso de carga: " + strResultado;
                        //Response.Redirect("~/frmErrorCarga.aspx?mensaje=" + "Error: " + Server.UrlEncode(strResultado));
                        return;
                    }
                }
                else
                {
                    lblMensaje1.Visible = true;
                    lblMensaje1.Attributes.Add("class", "btn btn-danger");
                    lblMensaje1.Text = "Por favor seleccione el archivo";
                    return;
                }
            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmErrorCarga.aspx?mensaje=" + "Error: " + Server.UrlEncode(strDescripcionError));
            }
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
                int intIdContrato = int.Parse((((Label)namingContainer.FindControl("lblIdContrato")).Text));
                Session["idContrato"] = intIdContrato.ToString();
                Session["idCliente"] = intId.ToString();
                txtCliente.Text = strNmCliente;
                txtIdentificacion.Text = strIdentificacionCliente;
                txtIdCliente.Text = intId.ToString();
                
                divControl.Visible = true;
                if (int.Parse(Session["ControlPantalla"].ToString()) == 1)//1 = Control para mostrar opcion para el cliente corporativo
                {
                    divDatosCarga.Visible = true;
                    divBuscar.Visible = true;
                }
                else
                {
                    divClientes.Visible = false;
                   
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
                List<cliente> oResultado = new List<cliente>();
                oResultado = (List<cliente>)Session["ListaClientes"];
                grvClientes.DataSource = oResultado;
                grvClientes.PageIndex = e.NewPageIndex;
                grvClientes.DataBind();
            }
            catch (Exception ex)
            {
                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }
    }
}
