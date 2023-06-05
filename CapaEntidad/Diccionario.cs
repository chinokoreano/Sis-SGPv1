using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class Diccionario
    {
        public Dictionary<String, Object> diccionario { get; set; }
        public Diccionario(params Object[] value)
        {
            for (int i = 0; i < value.Length; i += 2)
                Anadir(value[i].ToString(), value[i + 1]);
        }
        public void Anadir(string key, object value)
        {
            if (this.diccionario == null)
                this.diccionario = new Dictionary<string, object>() { { key, value } };
            else
            {
                if (this.diccionario.ContainsKey(key))
                    this.diccionario[key] = value;
                else
                    this.diccionario.Add(key, value);
            }
        }

        public bool ExisteClave(string key)
        {
            if (this.diccionario == null)
                return false;

            if (this.diccionario.ContainsKey(key))
                return true;
            else
                return false;
        }

        public void Remover(String key)
        {
            if (this.diccionario == null)
                return;

            if (this.diccionario != null)
                this.diccionario.Remove(key);
        }

        public T Obtener<T>(String key)
        {
            T obj;
            if (this.diccionario == null)
                return default;
            else
            {
                obj = (T)Convert.ChangeType(this.diccionario[key], typeof(T));
                return obj;
            }
        }
    }

    
}
