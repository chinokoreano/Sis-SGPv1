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
    public partial class frmCambioContrasena : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session.Keys.Count == 0)
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }
            if (!IsPostBack)
            {
                
                
            }
        }

        protected void btnCambiarContrasenia_Click(object sender, EventArgs e)
        {
            List<usuario> oResultado = new List<usuario>();
            try
            {
                usuario oUsuario = new usuario();
                oUsuario.usuario1 = Session["Login"].ToString();
                oUsuario.contrasenia = txtContrasenia.Text.Trim();

                if (string.IsNullOrEmpty(txtContraseniaNueva.Text.Trim()) || string.IsNullOrWhiteSpace(txtContraseniaNueva.Text.Trim())
                    || string.IsNullOrEmpty(txtConfirmarContrasenia.Text.Trim()) || string.IsNullOrWhiteSpace(txtConfirmarContrasenia.Text.Trim())
                    || string.IsNullOrEmpty(txtContrasenia.Text.Trim()) || string.IsNullOrWhiteSpace(txtContrasenia.Text.Trim()))
                        
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Por favor complete la información de todos los campos.";
                    txtContrasenia.Focus();
                    
                }

                UsuarioCN oUsuarioCN = new UsuarioCN();
                oResultado = oUsuarioCN.FnConsultaUsuario(oUsuario);
                Resultado oResultadoA = new Resultado();

                                             
                if (oResultado == null)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Attributes.Add("class", "btn btn-danger");
                    lblMensaje.Text = "Por favor verifique que la contraseña actual sea correcta.";
                    txtContrasenia.Focus();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtContraseniaNueva.Text.Trim()) && !string.IsNullOrWhiteSpace(txtContraseniaNueva.Text.Trim())
                        && !string.IsNullOrEmpty(txtConfirmarContrasenia.Text.Trim()) && !string.IsNullOrWhiteSpace(txtConfirmarContrasenia.Text.Trim()))
                    {
                        if (txtContraseniaNueva.Text.Trim().Equals(oResultado[0].contrasenia))
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Attributes.Add("class", "btn btn-danger");//class="btn btn-info"
                            lblMensaje.Text = "Contraseña nueva no puede ser igual a la anterior";
                            return;
                        }
                        if (txtContraseniaNueva.Text.Trim().Equals(txtConfirmarContrasenia.Text.Trim()))
                        {
                            oResultadoA = oUsuarioCN.FnActualizaUsuario(oResultado[0], txtConfirmarContrasenia.Text.Trim(),1);
                            if (oResultadoA.Codigo1 == "1")
                            {
                                lblMensaje.Visible = true;
                                lblMensaje.Attributes.Add("class", "btn btn-success");//class="btn btn-info"
                                lblMensaje.Text = "Cambio de contraseña realizado correctamente. Por favor cierre sesión y vuelva a iniciar";
                                

                                txtContrasenia.Visible = false;
                                txtConfirmarContrasenia.Visible = false;
                                txtContraseniaNueva.Visible = false;
                                btnCambiarContrasenia.Visible = false;

                                Session.Clear();
                                Session.RemoveAll();
                                Session.Abandon();
                                return;
                            }
                        }
                        else
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Attributes.Add("class", "btn btn-danger");
                            lblMensaje.Text = "Contraseña nuevas no coinciden por favor verifique.";
                            txtContraseniaNueva.Focus();
                        }

                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }
    }





}

