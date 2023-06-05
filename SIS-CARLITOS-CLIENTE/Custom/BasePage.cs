using System;
using SIS_CARLITOS.Custom;

namespace SIS_CARLITOS.Custom
{
    public abstract class BasePage : System.Web.UI.Page
    {
        public SessionManager sesion;

        protected SessionManager SessionManager
        {
            get { return sesion; }
            set { sesion = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.sesion = new SessionManager(Session);
        }

        protected override void OnLoad(EventArgs e)
        {
            string path = Request.Path;

            //List<si_menu> Vistas = this.SessionManager.usuario.menu;

            base.OnLoad(e);
            //var Vist = Newtonsoft.Json.JsonConvert.SerializeObject(Vistas);
            /*if (Vistas != null)
            {
                if (!buscarVista(Vistas, path))
                {
                    if (path.Contains("/Vistas/Libros/R/") || path.Contains("/Vistas/Libros/S/"))
                        Response.Redirect("/Navegacion/NotFound.aspx?msj=NoAutrizado&page=" + path);
                    else
                        Response.Redirect("/Navegacion/404.aspx?msj=NoAutrizado&page=" + path);
                }
                else
                    base.OnLoad(e);
            }
            else
            {
                Response.Redirect("/Navegacion/Mensaje.aspx?msj=NoVistas&page=" + path);
            }*/


        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Verifica contra el session manager si esta autentificado y si no existe la variable de sessión de usuario destruye la cookie
            bool IsAuthenticated = this.sesion.IsAuthenticated();
            if (!IsAuthenticated)
                Response.Redirect("/Default");
        }

     
    }
}