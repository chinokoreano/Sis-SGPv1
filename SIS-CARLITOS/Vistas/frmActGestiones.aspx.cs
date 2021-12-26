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
    public partial class frmActGestiones : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Keys.Count == 0)
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }
            usuario oUsuario = new usuario();
            oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
           
            if (!IsPostBack)
            {


            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {

            lblMensaje.Visible = false;
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

                if (oResultadoBusq.id_ultm_evento == 1)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Imposibel procesar: último evento del envío REGISTRADO";
                    return;
                }


                EventoCN oEventoCN = new EventoCN();

                usuario oUsuario = new usuario();
                oUsuario.nm = Session["Usuario"].ToString();

                List<SPR_ACT_ULTIMO_EVENTO_Result> oResultado = new List<SPR_ACT_ULTIMO_EVENTO_Result>();
                oResultado = oEventoCN.FnActUltimoEvento(1, objPaquete,oUsuario);

                if (oResultado[0].CODIGO1 == "1")
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-success");
                    lblMensaje.Text = "Transacción exitosa";
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");//class="btn btn-info"
                    lblMensaje.Text = "Problemas al realizar el proceso";
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
