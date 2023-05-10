using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public static class PersonaCN
    {
        public static string Validacion(persona persona, int opcion)
        {
            string resultado = string.Empty;
            try
            {
                if (persona.per_tipo_documento == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo tipo de documento";
                    return resultado;
                }
                if (persona.per_tipo_documento <= 0)
                {
                    resultado = "Por favor ingrese datos correctos: campo tipo de documento";
                    return resultado;
                }

                if (persona.per_numero_identificacion == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo número de identificación";
                    return resultado;
                }
                if (persona.per_tipo_documento == 1)
                {
                    if (persona.per_numero_identificacion.Length != 10)
                    {
                        resultado = "Número de identificación no es correcto";
                        return resultado;
                    }
                }
                if (persona.per_tipo_documento == 2)
                {
                    if (persona.per_numero_identificacion.Length != 13)
                    {
                        resultado = "Número de identificación no es correcto";
                        return resultado;
                    }
                }
                if (persona.per_nombres == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo nombres";
                    return resultado;
                }
                if (string.IsNullOrEmpty(persona.per_nombres) || string.IsNullOrWhiteSpace(persona.per_nombres)) 
                {
                    resultado = "Por favor ingrese datos correctos: campo nombres";
                    return resultado;
                }
                if (persona.per_apellidos == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo apellidos";
                    return resultado;
                }
                if (string.IsNullOrEmpty(persona.per_apellidos) || string.IsNullOrWhiteSpace(persona.per_apellidos))
                {
                    resultado = "Por favor ingrese datos correctos: campo apellidos";
                    return resultado;
                }
                if (persona.per_celular == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo teléfono celular";
                    return resultado;
                }
                if (string.IsNullOrEmpty(persona.per_celular) || string.IsNullOrWhiteSpace(persona.per_celular))
                {
                    resultado = "Por favor ingrese datos correctos: campo teléfono celular";
                    return resultado;
                }
                if (persona.per_correo_electronico == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo correo electrónico";
                    return resultado;
                }
                if (string.IsNullOrEmpty(persona.per_correo_electronico) || string.IsNullOrWhiteSpace(persona.per_correo_electronico))
                {
                    resultado = "Por favor ingrese datos correctos: campo correo electrónico";
                    return resultado;
                }
                if (persona.id_provincia == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo provincia";
                    return resultado;
                }
                if (persona.id_provincia <= 0)
                {
                    resultado = "Por favor ingrese datos correctos: campo provincia";
                    return resultado;
                }
                if (persona.id_canton == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo cantón";
                    return resultado;
                }
                if (persona.id_canton <= 0)
                {
                    resultado = "Por favor ingrese datos correctos: campo cantón";
                    return resultado;
                }
                if (persona.direccion_domiciliaria == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo dirección";
                    return resultado;
                }
                if (string.IsNullOrEmpty(persona.direccion_domiciliaria) || string.IsNullOrWhiteSpace(persona.direccion_domiciliaria))
                {
                    resultado = "Por favor ingrese datos correctos: campo dirección";
                    return resultado;
                }
                if (persona.per_contrasenia == null)
                {
                    resultado = "Por favor ingrese datos correctos: campo contraseña";
                    return resultado;
                }
                if (string.IsNullOrEmpty(persona.per_contrasenia) || string.IsNullOrWhiteSpace(persona.per_contrasenia))
                {
                    resultado = "Por favor ingrese datos correctos: campo contraseña";
                    return resultado;
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
