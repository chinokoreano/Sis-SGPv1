using CapaEntidad;
using CapaNegocio;
using SIS_CARLITOS.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS.Admin
{
    public partial class frmAutenticacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            List<usuario> oResultado = new List<usuario>();
            lblMensaje.Visible = false;
            lblMensaje.Text = String.Empty;
            try
            {
                usuario oUsuario = new usuario();
                oUsuario.usuario1 = txtUsuario.Text.Trim();
                oUsuario.contrasenia = txtContrasenia.Text.Trim();

                UsuarioCN oUsuarioCN = new UsuarioCN();
                oResultado = oUsuarioCN.FnConsultaUsuario(oUsuario);

                if (oResultado == null)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Por favor verifique que el usuario y la contraseña sean correctos.";
                    txtUsuario.Focus();
                    return;
                }

                if (oResultado[0].contrasenia != txtContrasenia.Text.Trim())
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Por favor verifique que el usuario y la contraseña sean correctos.";
                    txtUsuario.Focus();
                    return;
                }

                if (oResultado[0].cambio_contrasenia == false)
                {
                    txtContraseniaNueva.Visible = true;
                    txtConfirmarContrasenia.Visible = true;
                    btnCambiarContrasenia.Visible = true;
                    btnIniciarSesion.Visible = false;

                }
                else if (oResultado[0].cambio_contrasenia == true)
                {

                    OficinaCN oOficinaCN = new OficinaCN();
                    List<oficina> oResultadoOficinas = new List<oficina>();
                    oResultadoOficinas = oOficinaCN.FnConsultarClientes();
                    List<oficina> oResultadoOficinaBusq = oResultadoOficinas.Where(p => p.id == oResultado[0].id_oficina).ToList();

                    Session["objUsuario"] = oResultado;
                    Session["Usuario"] = oResultado[0].nm;//nombre de usuario
                    Session["IdUsuario"] = oResultado[0].id;
                    Session["IdTipoUsuario"] = oResultado[0].tipo_usuario;

                    Session["Oficina"] = oResultadoOficinaBusq[0].nm_oficina;
                    Session["IdOficina"] = oResultadoOficinaBusq[0].id;
                    Session["Login"] = oResultado[0].usuario1;

                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Por favor contactar con Soporte Técnico";
                }

            }

            
            catch (Exception)
            {

                throw;
            }


}

protected void btnCambiarContrasenia_Click(object sender, EventArgs e)
{
    List<usuario> oResultado = new List<usuario>();
    try
    {
        usuario oUsuario = new usuario();
        oUsuario.usuario1 = txtUsuario.Text.Trim();
        oUsuario.contrasenia = txtContrasenia.Text.Trim();

        UsuarioCN oUsuarioCN = new UsuarioCN();
        oResultado = oUsuarioCN.FnConsultaUsuario(oUsuario);
        Resultado oResultadoA = new Resultado();

        if (oResultado == null)
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "Por favor verifique que el usuario y la contraseña sean correctos.";
            txtUsuario.Focus();
        }
        else
        {
            if (!string.IsNullOrEmpty(txtContraseniaNueva.Text.Trim()) && !string.IsNullOrWhiteSpace(txtContraseniaNueva.Text.Trim())
                && !string.IsNullOrEmpty(txtConfirmarContrasenia.Text.Trim()) && !string.IsNullOrWhiteSpace(txtConfirmarContrasenia.Text.Trim()))
            {
                if (txtContraseniaNueva.Text.Trim().Equals(txtConfirmarContrasenia.Text.Trim()))
                {
                    oResultadoA = oUsuarioCN.FnActualizaUsuario(oResultado[0], txtConfirmarContrasenia.Text.Trim());
                    if (oResultadoA.Codigo1 == "1")
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Attributes.Add("class", "text-success");//class="btn btn-info"
                        lblMensaje.Text = "Cambio de contraseña realizado correctamente. Por favor inicie sesión.";

                        txtUsuario.Text = String.Empty;
                        txtContrasenia.Text = String.Empty;
                        txtConfirmarContrasenia.Visible = false;
                        txtContraseniaNueva.Visible = false;
                        btnCambiarContrasenia.Visible = false;
                        txtUsuario.Focus();
                        btnIniciarSesion.Visible = true;
                    }
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Contraseña no coinciden por favor verifique.";
                }

            }
        }


    }
    catch (Exception ex)
    {

        throw ex;
    }


}
    }
}