using CapaEntidad;
using CapaNegocio;
using CapaServicios;
using Logica.LogicaUtilitarios;
using SIS_CARLITOS.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util = Logica.LogicaUtilitarios.Util;

namespace SIS_CARLITOS.Vistas
{
    public partial class frmRegistrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FnCargarUbicacionesGeograficas();
            SessionManager sm = new SessionManager(Session);
            var u = sm.usuario;
            if (sm.IsAuthenticated())
            {
                Response.Redirect("/Vistas/Inicio");
            }

            //if (!IsPostBack)
            //{

            //}
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
                persona.per_contrasenia = Util.Base64_Encode(txtContrasenia.Text.Trim());
                persona.fec_creacion = DateTime.Now;
                persona.per_estado = 1;
                persona.usu_creacion = 1;
                resultado = PersonaCN.Validacion(persona, 1);
                
                if (resultado != string.Empty)
                {
                    AlertasJS.Advertencia(this, "Verifica e intenta nuevamente", null, resultado);
                }

                CrudGenerico<persona> crud = new CrudGenerico<persona>();
                int idCasillero = CasilleroCN.Obtener(1);
                if (idCasillero >0)
                {
                    persona.per_casillero = idCasillero;
                    bolResultado = crud.Crear(persona);
                    if (bolResultado == true)
                    {
                        CrudGenerico<casillero_secuencia> casillero = new CrudGenerico<casillero_secuencia>();
                        casillero_secuencia casilleroGenerado = casillero.Obtener(idCasillero);
                        AlertasJS.NotificacionRedirect(this, "Felicidades, su registro ha sido exitoso", "Su casillero es: " + casilleroGenerado.casillero.ToString(), "success", "/Vistas/Admin/frmLogin");
                    }
                }
                

            }
            catch (Exception ex)
            {
                AlertasJS.js_exepcion(this, ex);
            }
        }

        protected void btn_solicitarCodigo_Click(object sender, EventArgs e)
        {
            string resultado = string.Empty;
            try
            {
                persona persona = new persona();

                persona.per_tipo_documento = int.Parse(cmbTipoDocumento.SelectedItem.Value.ToString());
                persona.per_numero_identificacion = txtDocumentoIdentificacion.Text.Trim();
                persona.per_nombres = txtNombres.Text.Trim().ToUpper();
                persona.per_apellidos = txtApellidos.Text.Trim().ToUpper();
                persona.per_correo_electronico = txtCorreo.Text.Trim().ToUpper();
                resultado = PersonaCN.Validacion(persona, 2);
                resultado = PersonaCN.Validacion(persona, 3);
                if (resultado != string.Empty)
                {
                    AlertasJS.Advertencia(this, "Verifica e intenta nuevamente", null, resultado);
                    return;
                }

                Random rdm = new Random();
                int codigo = rdm.Next(1000, 9999);
                SessionManager sm = new SessionManager(Session);
                PersonaCN.EnviarCodigoAcceso(codigo, persona);
                sm.Anadir("codigo_acceso", codigo.ToString());
                btn_validarCodigo.Visible = true;
                AlertasJS.Notificacion(this, "Se ha enviado código a su correo electrónico", "info");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btn_validarCodigo_Click(object sender, EventArgs e)
        {
            btnGrabar.Enabled = false;
            divDatosAdicionales.Visible = false;
            try
            {
                SessionManager sm = new SessionManager(Session);
                Boolean bolExiste= sm.ExisteClave("codigo_acceso");
                if (bolExiste)
                {
                    if (string.IsNullOrEmpty(txt_codigo.Text) || string.IsNullOrWhiteSpace(txt_codigo.Text))
                    {
                        AlertasJS.Notificacion(this, "Código no válido, verifica e intenta nuevamente", "info");
                        return;
                    }
                    if (txt_codigo.Text.Trim().Length <= 3 || txt_codigo.Text.Trim().Length > 6)
                    {
                        AlertasJS.Notificacion(this, "Código no válido, verifica e intenta nuevamente", "info");
                        return;
                    }

                    if (txt_codigo.Text.ToString().Trim().Equals(sm.Obtener<string>("codigo_acceso")))
                    {
                        txtDocumentoIdentificacion.ReadOnly = true;
                        cmbTipoDocumento.Enabled = false;
                        txt_codigo.ReadOnly = true;
                        txtNombres.ReadOnly = true;
                        txtApellidos.ReadOnly = true;
                        txtCorreo.ReadOnly = true;
                        btn_solicitarCodigo.Enabled = false;
                        btn_validarCodigo.Enabled = false;

                        divDatosAdicionales.Visible = true;
                        btnGrabar.Enabled = true;
                        
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