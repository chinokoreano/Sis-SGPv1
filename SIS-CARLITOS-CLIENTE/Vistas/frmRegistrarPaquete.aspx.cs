using CapaEntidad;
using CapaNegocio;
using CapaServicios;
using Logica.LogicaUtilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS.Vistas
{
    public partial class frmRegistrarPaquete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            AlertasJS.Exito(this, "Registro exitoso");
            Random rdm = new Random();
            int codigo = rdm.Next(1000, 9999);
            Dictionary<string, string> valores = new Dictionary<string, string>();
            valores.Add("@@codigo", codigo.ToString());
            CorreoElectronico.enviar("carlosdarwinromero@gmail.com", "romerocarlos79@hotmail.com", "CODIGO DE VERIFICACION", "", "", "PLANTILLA_CODIGO_VERIFICACION",valores);
        }
    }
}