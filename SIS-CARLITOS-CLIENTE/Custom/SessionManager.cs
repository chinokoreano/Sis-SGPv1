using System;
using System.Web.Security;
using System.Web.SessionState;
using CapaEntidad;
//https://stackoverflow.com/questions/4943817/mapping-object-to-dictionary-and-vice-versa

namespace SIS_CARLITOS.Custom
{
    public class SessionManager
    {
        #region variables
        private HttpSessionState _currentSession;
        #endregion

        public SessionManager(HttpSessionState session)
        {
            this._currentSession = session;
        }

        #region metodos
        private HttpSessionState CurrentSession
        {
            get { return this._currentSession; }
        }

        public bool IsAuthenticated()
        {
            bool IsAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if (!IsAuthenticated)
                this.usuario = null;
            else if (this.usuario == null)
            {
                FormsAuthentication.SignOut();
                IsAuthenticated = false;
            }

            return IsAuthenticated;
        }

        public persona usuario
        {
            set { CurrentSession["UserSession"] = value; }
            get { return (persona)CurrentSession["UserSession"]; }
        }

       

        public Diccionario diccionario
        {
            set { CurrentSession["diccionario"] = value; }
            get { return (Diccionario)CurrentSession["diccionario"]; }
        }

        public void Anadir(string key, object value)
        {
            if (this.diccionario == null)
                this.diccionario = new Diccionario(key, value);
            else
                this.diccionario.Anadir(key, value);
        }

        public bool ExisteClave(string key)
        {
            if (this.diccionario == null)
                return false;

            return this.diccionario.ExisteClave(key);
        }
        public T Obtener<T>(String key)
        {
            return this.diccionario.Obtener<T>(key);
        }
        public void Remover(string key)
        {
            if (this.diccionario == null)
                return;

            this.diccionario.Remover(key);
        }
        #endregion
    }
}
