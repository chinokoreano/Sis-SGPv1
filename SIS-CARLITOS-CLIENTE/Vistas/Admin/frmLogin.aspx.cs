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
    public partial class frmLogin : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session.Keys.Count == 0)
            //{
            //    Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            //}

            if (!IsPostBack)
            {
                
               
                
            }
        }

        
    }
}
