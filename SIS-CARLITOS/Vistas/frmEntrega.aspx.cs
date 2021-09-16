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
    public partial class frmEntrega : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session.Keys.Count == 0)
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }
            if (!IsPostBack)
            {
                
                FnAsignarAtributos();
            }
        }

        private void FnAsignarAtributos()
        {
            txtCodigoEnvio1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
            txtDireccionActualizada.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
            txtIdentificacionReceptor.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
            txtRecibidoPor.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");
            txtObservacion.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase() ;");

        }

       

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = "";
            chk.Checked = false;
            txtDireccionActualizada.Visible = false;
            try
            {
                btnGrabar.Visible = false;
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

                ParametroCN oParametroCN = new ParametroCN();
                List<parametro> oResultadoParametros = new List<parametro>();
                oResultadoParametros = oParametroCN.FnConsultarParametros();
                List<parametro> oResultadoBusqParam = oResultadoParametros.Where(p => p.tipo == "ENTREGA_PRECONDICION").ToList();

                string[] strPreCondiciones = oResultadoBusqParam[0].valor1.Split(',');


                foreach (var itm in strPreCondiciones)
                {
                    if (itm.ToString() == oResultadoBusq.id_ultm_evento.ToString())
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Attributes.Add("class", "btn btn-danger");
                        lblMensaje.Text = "Codigo de envío ya ha sido entregado o devuelto";
                        txtCodigoEnvio1.Focus();
                        return;
                    }
                }
                btnGrabar.Visible = true;
                txtRecibidoPor.Focus();
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }

        }




        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
            lblMensaje.Text = "";
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

                ParametroCN oParametroCN = new ParametroCN();
                List<parametro> oResultadoParametros = new List<parametro>();
                oResultadoParametros = oParametroCN.FnConsultarParametros();
                List<parametro> oResultadoBusqParam = oResultadoParametros.Where(p => p.tipo == "ENTREGA_PRECONDICION").ToList();

                string[] strPreCondiciones = oResultadoBusqParam[0].valor1.Split(',');


                foreach (var itm in strPreCondiciones)
                {
                    if (itm.ToString() == oResultadoBusq.id_ultm_evento.ToString())
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Attributes.Add("class", "btn btn-danger");
                        lblMensaje.Text = "Codigo de envío ya ha sido entregado o devuelto";
                        txtCodigoEnvio1.Focus();
                        return;
                    }
                }

                entrega objEntrega = new entrega();
                objEntrega.identificador_paquete = oResultadoBusq.identificador;
                objEntrega.fecha_entrega = txtFechaEntrega1.Text.Trim();
                objEntrega.hora_entrega = txtHoraEntrega1.Text.Trim();
                objEntrega.receptor = txtRecibidoPor.Text.Trim();
                objEntrega.identificacion_receptor = txtIdentificacionReceptor.Text.Trim();
                objEntrega.observacion = txtObservacion.Text.Trim();
                objEntrega.locacion_entrega =null;
                if (chk.Checked == true)
                    objEntrega.control_dir_entrega = 1;
                else
                    objEntrega.control_dir_entrega = 0;

                objEntrega.direccion_actualizada = txtDireccionActualizada.Text.Trim();
                objEntrega.id_oficina = int.Parse(Session["IdOficina"].ToString()); ;
                objEntrega.id_usuario = int.Parse(Session["IdUsuario"].ToString()); ;

                EntregaCN oEntrega = new EntregaCN();
                Resultado oResultado = new Resultado();

                oResultado = oEntrega.FnInsertarEntrega(objEntrega);
                evento objEvento = new evento();
                objEvento.identificador_paquete = oResultadoBusq.identificador;
                objEvento.id_oficina = int.Parse(Session["IdOficina"].ToString());
                objEvento.id_usuario = int.Parse(Session["IdUsuario"].ToString());
                
                if (oResultado.Codigo1 == "1")
                {
                    objEvento.id_tipo_evento = 9;//ENTREGA
                    EventoCN oEvento = new EventoCN();
                    oEvento.FnInsertarEvento(objEvento);

                    oPaqueteCN.FnActualizarEventoPaquete(oResultadoBusq, objEvento);

                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-success");
                    lblMensaje.Text = "Transacción exitosa";
                    
                    btnGrabar.Visible = false;
                    txtCodigoEnvio1.Text = string.Empty;
                    txtCodigoEnvio1.Focus();

                    txtDireccionActualizada.Text = string.Empty;
                    txtFechaEntrega1.Text = string.Empty;
                    txtHoraEntrega1.Text = string.Empty;
                    txtObservacion.Text = string.Empty;
                    txtRecibidoPor.Text = string.Empty;
                    txtIdentificacionReceptor.Text = string.Empty;
                   
                    chk.Checked = false;
                    txtDireccionActualizada.Visible = false;


                }
                else
                {
                    objEvento.id_tipo_evento = 12;//ERROR AL REGISTRAR
                    objEvento.observacion1 = "Error al registrar entrega";
                    EventoCN oEvento = new EventoCN();
                    oEvento.FnInsertarEvento(objEvento);

                    oPaqueteCN.FnActualizarEventoPaquete(oResultadoBusq, objEvento);

                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Error al registrar entrega";
                    btnGrabar.Visible = false;
                    txtCodigoEnvio1.Text = string.Empty;
                    txtCodigoEnvio1.Focus();
                    
                }
            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmError.aspx?mensaje=" + "Error: " + strDescripcionError);
            }
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (chk.Checked == true)
            {
                txtDireccionActualizada.Visible = true;
            }else if (chk.Checked ==false)
            {
                txtDireccionActualizada.Visible = false;
            }
        }
    }
}
