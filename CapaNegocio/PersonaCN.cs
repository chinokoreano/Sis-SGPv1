using CapaEntidad;
using CapaServicios;
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
                if (opcion == 1)
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

                }

                if (opcion == 2)
                {
                    if (persona.per_tipo_documento == null)
                    {
                        resultado = "Seleccione tipo de documento";
                        return resultado;
                    }
                    if (persona.per_tipo_documento <= 0)
                    {
                        resultado = "Seleccione tipo de documento";
                        return resultado;
                    }
                    if (persona.per_numero_identificacion == null)
                    {
                        resultado = "Número de identificación no puede estar vacío";
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
                        resultado = "Nombres no puede esta vacío";
                        return resultado;
                    }
                    if (string.IsNullOrEmpty(persona.per_nombres) || string.IsNullOrWhiteSpace(persona.per_nombres))
                    {
                        resultado = "Nombres no puede esta vacío";
                        return resultado;
                    }
                    if (persona.per_apellidos == null)
                    {
                        resultado = "Apellidos no puede estar vacío";
                        return resultado;
                    }
                    if (string.IsNullOrEmpty(persona.per_apellidos) || string.IsNullOrWhiteSpace(persona.per_apellidos))
                    {
                        resultado = "Apellidos no puede estar vacío";
                        return resultado;
                    }                    
                    if (persona.per_correo_electronico == null)
                    {
                        resultado = "Correo electrónico no puede estar vacío";
                        return resultado;
                    }
                    if (string.IsNullOrEmpty(persona.per_correo_electronico) || string.IsNullOrWhiteSpace(persona.per_correo_electronico))
                    {
                        resultado = "Correo electrónico no puede estar vacío";
                        return resultado;
                    }                   
                }

                if (opcion == 3)
                {
                    List<persona> resultadoBusq = new List<persona>();
                    CrudGenerico<persona> Persona1 = new CrudGenerico<persona>();
                    resultadoBusq =  Persona1.ObtenerTodos(p => p.per_numero_identificacion == persona.per_numero_identificacion &&
                                               p.per_tipo_documento == persona.per_tipo_documento);
                    if(resultadoBusq.Count >0)
                    {
                        resultado = "Número de identificación ya se encuentra registrado";
                    }
                    else
                    {
                        resultadoBusq = Persona1.ObtenerTodos(p => p.per_correo_electronico == persona.per_correo_electronico);
                        if (resultadoBusq.Count >0)
                        {
                            resultado = "Correo electrónico ya se encuentra registrado";
                        }
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void EnviarCodigoAcceso(int codigo, persona persona)
        {
            Dictionary<string, string> valores = new Dictionary<string, string>();
            valores.Add("@@codigo", codigo.ToString());
            CorreoElectronico.enviar("",persona.per_correo_electronico, "CODIGO DE VERIFICACION", "", "", "PLANTILLA_CODIGO_VERIFICACION", valores);

        }

    }
   
}
