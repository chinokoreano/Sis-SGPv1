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
    public partial class frmServicios : System.Web.UI.Page
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

       
       
        
    }
}
