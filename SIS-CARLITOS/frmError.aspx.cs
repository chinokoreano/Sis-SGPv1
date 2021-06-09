using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS
{
    public partial class frmErrror : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = Request.QueryString["mensaje"];
            lblMensaje.Text = msg;

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            //Session.Clear();
            //Session.Abandon();
            string url = System.Configuration.ConfigurationManager.AppSettings["URLSistema"].ToString();
            Response.Redirect(url);
           

        }
    }
}