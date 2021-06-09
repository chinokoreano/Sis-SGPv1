using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session.Keys.Count == 0)
            {
                string strUlrAutenticacion = System.Configuration.ConfigurationManager.AppSettings["UrlAutenticacion"].ToString();
                Response.Redirect(strUlrAutenticacion);
            }

            if (Session["IdTipoUsuario"].ToString() == "0")
            {
                mnu_administracion.Visible = true;
                mnu_procesos.Visible = true;
            }

            if (Session["IdTipoUsuario"].ToString() == "2")
            {
                mnu_administracion.Visible = false;
                mnu_procesos.Visible = false;
            }

            if (Session["IdTipoUsuario"].ToString() == "3")
            {
                mnu_administracion.Visible = false;
                mnu_procesos.Visible = true;
            }
            lblOficina.Text = Session["Oficina"].ToString() + "&nbsp;";
            lblUsuario.Text = Session["Usuario"].ToString() + "&nbsp;";
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            string strUlrAutenticacion = System.Configuration.ConfigurationManager.AppSettings["UrlAutenticacion"].ToString();
            Response.Redirect(strUlrAutenticacion);
            
        }
    }
}