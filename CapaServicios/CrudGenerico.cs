using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicios
{
    public class CrudGenerico<T> where T : class, new()
    {
        public Boolean Crear(T pEntidad)
        {
            Boolean bolResultado = false;
            try
            {
                using (OPERADB dB = new OPERADB())
                {
                    dB.Entry(pEntidad).State = EntityState.Added;
                    bolResultado = dB.SaveChanges() >= 0 ? true : false;
                }
                return bolResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Actualizar(T pEntidad)
        {
            Boolean bolResultado = false;
            try
            {
                using (OPERADB dB = new OPERADB())
                {
                    dB.Entry(pEntidad).State = EntityState.Modified;
                    bolResultado = dB.SaveChanges() >= 0 ? true : false;
                }
                return bolResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Crear(List<T> pEntidad)
        {
            Boolean bolResultado = false;
            try
            {
                using (OPERADB dB = new OPERADB())
                {
                    dB.Entry(pEntidad).State = EntityState.Added;
                    bolResultado = dB.SaveChanges() >= 0 ? true : false;
                }
                return bolResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T ObtenerPrimero(Expression<Func<T, bool>> filter = null)
        {
            T resultado = null;
            try
            {
                using (OPERADB dB = new OPERADB())
                {
                    if (filter != null)
                    {
                        resultado = dB.Set<T>().Where(filter).FirstOrDefault();
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        public T Obtener(int id)
        {
            T resultado = null;
            try
            {
                using (OPERADB dB = new OPERADB())
                {
                    resultado = dB.Set<T>().Find(id);
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> ObtenerTodos(Expression<Func<T, bool>> filter = null)
        {
            List<T> resultado = null;
            try
            {
                using (OPERADB dB = new OPERADB())
                {
                    if (filter != null)
                    {
                        resultado = dB.Set<T>().Where(filter).ToList();
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
