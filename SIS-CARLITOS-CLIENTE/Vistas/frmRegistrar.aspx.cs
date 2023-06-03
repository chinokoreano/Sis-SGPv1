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
    public partial class frmRegistrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FnCargarUbicacionesGeograficas();
            if (!IsPostBack)
            {

            }
        }

        private void FnCargarUbicacionesGeograficas()
        {
            List<SPR_CONSULTA_UBICACIONES_GEOGRAFICAS_Result> oResultado = new List<SPR_CONSULTA_UBICACIONES_GEOGRAFICAS_Result>();
            try
            {
                UbicacionGeograficaCN oUbicacionGeograficaCN = new UbicacionGeograficaCN();
                oResultado = oUbicacionGeograficaCN.FnConsultarUbicacionesGeograficas(1);
                cmbLocalidad.DataSource = oResultado;

                cmbLocalidad.ValueField = "id_canton";
                cmbLocalidad.TextField = "nm_canton";

                cmbLocalidad.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            string resultado = string.Empty;
            Boolean bolResultado = false;
            string strIdProvinciaCarga = string.Empty;
            string strIdCantonCarga = string.Empty;
            try
            {
                persona persona = new persona();

                persona.per_tipo_documento = int.Parse(cmbTipoDocumento.SelectedItem.Value.ToString());
                persona.per_numero_identificacion = txtDocumentoIdentificacion.Text.Trim();
                persona.per_nombres = txtNombres.Text.Trim().ToUpper();
                persona.per_apellidos = txtApellidos.Text.Trim().ToUpper();
                persona.per_celular = txtTelefono.Text.Trim().ToUpper();
                persona.per_correo_electronico = txtCorreo.Text.Trim().ToUpper();

                string strIdUbicacion = string.Empty;
                try
                {
                    strIdUbicacion = cmbLocalidad.SelectedItem.Value.ToString();
                    string[] strUbicaionGeografica = strIdUbicacion.Split('-');                    
                    strIdProvinciaCarga = strUbicaionGeografica[0].ToString();
                    strIdCantonCarga = strUbicaionGeografica[1].ToString();
                    persona.id_provincia = int.Parse(strIdProvinciaCarga);
                    persona.id_canton = int.Parse(strIdCantonCarga);
                }
                catch (Exception)
                {
                    persona.id_provincia = 0;
                    persona.id_canton = 0;
                }
                persona.direccion_domiciliaria = txtDireccion1.Text.Trim().ToUpper();
                persona.per_contrasenia = txtContrasenia.Text.Trim();

                resultado = PersonaCN.Validacion(persona, 0);

                if (resultado != string.Empty)
                {
                    AlertasJS.Advertencia(this, resultado);
                }



                //CrudGenerico<persona> crud = new CrudGenerico<persona>();
                //int idCasillero = CasilleroCN.Obtener(1);
                //if (idCasillero >0)
                //{
                //    persona.per_casillero = idCasillero;
                //    bolResultado = crud.Crear(persona);
                //    if (bolResultado == true)
                //    {
                //        CrudGenerico<casillero_secuencia> casillero = new CrudGenerico<casillero_secuencia>();
                //        casillero_secuencia casilleroGenerado = casillero.Obtener(idCasillero);

                //    }
                //}


            }
            catch (Exception ex)
            {

                string strDescripcionError = ex.Message + ex.InnerException;
                Response.Redirect("~/frmErrorCarga.aspx?mensaje=" + "Error: " + Server.UrlEncode(strDescripcionError));
            }
        }

        protected void btn_solicitarCodigo_Click(object sender, EventArgs e)
        {

        }
    }
}