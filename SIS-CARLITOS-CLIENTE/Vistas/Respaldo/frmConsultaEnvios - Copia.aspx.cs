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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_CARLITOS.Vistas
{
    public partial class frmConsultaEnvios : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["IdUsuario"].ToString()))
            {
                Response.Redirect("~/frmUsuarioNoAutenticado.aspx?mensaje=" + "Error: " + "Sesión Finalizada");
            }
            usuario oUsuario = new usuario();
            oUsuario.id = int.Parse(Session["IdUsuario"].ToString());
            orden_servicio oOrdenServicio = new orden_servicio();

            if (!IsPostBack)
            {
               
               
            }
        }

        protected void detailGrid_DataSelect(object sender, EventArgs e)
        {
            Session["identificador"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            Session["opcion"] = "1";
            //string strId = Session["identificador_paquete"].ToString();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnExportar1_Click(object sender, EventArgs e)
        {
            XlsxExportOptionsEx options1 = new XlsxExportOptionsEx();
            options1.SheetName = "Rpt_";
            ASPxGridView1.ExportXlsxToResponse("ReporteGestion_", true);
        }
    }
}
