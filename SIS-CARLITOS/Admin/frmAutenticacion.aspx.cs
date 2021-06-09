using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS.Admin
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            List<usuario> oResultado = new List<usuario>();
            try
            {
                usuario oUsuario = new usuario();
                oUsuario.usuario1 = txtUsuario.Text.Trim();
                oUsuario.contrasenia = txtContrasenia.Text.Trim();

                UsuarioCN oUsuarioCN = new UsuarioCN();
                oResultado = oUsuarioCN.FnConsultaUsuario(oUsuario);

                if (oResultado.Count == 0)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Por favor verifique que el usuario y la contraseña sean correctos.";
                    txtUsuario.Focus();
                }
                else
                {
                    OficinaCN oOficinaCN = new OficinaCN();
                    List<oficina> oResultadoOficinas = new List<oficina>();
                    oResultadoOficinas = oOficinaCN.FnConsultarClientes();
                    List<oficina> oResultadoOficinaBusq = oResultadoOficinas.Where(p => p.id == oResultado[0].id_oficina).ToList();

                    Session["objUsuario"] = oResultado;
                    Session["Usuario"] = oResultado[0].nm;
                    Session["IdUsuario"] = oResultado[0].id;
                    Session["IdTipoUsuario"] = oResultado[0].tipo_usuario;

                    Session["Oficina"] = oResultadoOficinaBusq[0].nm_oficina;
                    Session["IdOficina"] = oResultadoOficinaBusq[0].id;
                    Response.Redirect("~/Default.aspx");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
    }
}