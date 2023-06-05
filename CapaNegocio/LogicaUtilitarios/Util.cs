using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
namespace Logica.LogicaUtilitarios
{
    public static class Util
    {
        public static string GetIp(HttpRequest currentRequest)
        {
            //HttpRequest currentRequest = HttpContext.Current.Request;
            string ipAddress = currentRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (ipAddress == null || ipAddress.ToLower() == "unknown")
                ipAddress = currentRequest.ServerVariables["REMOTE_ADDR"];

            return ipAddress;

        }

        public static string StringRandomico(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        public static string cortarCadena(string cadena, int largo)
        {
            if (cadena == null)
                return null;

            if (cadena.Length > largo)
                cadena = cadena.Substring(0, largo - 1);

            return cadena;
        }

        public static string Base64_Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        public static string StringTipoTitulo(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return null;
            cadena = cadena.Trim().ToLower();
            cadena = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(cadena));

            return cadena;
        }

        //Este método no ha sido provado
        public static void ExportarAExceldeLista(HttpResponse response, List<object> lista, string nombreArchivo)
        {


            DataGrid dg = new DataGrid();
            dg.AllowPaging = false;
            dg.DataSource = nombreArchivo;
            dg.DataBind();

            response.Clear();
            response.Buffer = true;
            response.ContentEncoding = Encoding.UTF8;
            response.Charset = "";
            response.AddHeader("Content-Disposition",
              "attachment; filename=" + nombreArchivo);

            response.ContentType =
              //"application/vnd.ms-excel";
              "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlTextWriter =
              new System.Web.UI.HtmlTextWriter(stringWriter);
            dg.RenderControl(htmlTextWriter);
            response.Write(stringWriter.ToString());
            response.End();
        }

        public static void ExportarAExceldeDataTable(HttpResponse response, DataTable dt, string nombreArchivo)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Reporte");

                response.Clear();
                response.Buffer = true;
                response.Charset = "";
                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                response.AddHeader("content-disposition", "attachment;filename=" + nombreArchivo + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(response.OutputStream);
                    response.Flush();
                    response.End();
                }
            }
        }


        public static string QuitarAcentos(string s)
        {
            Regex replace_a_Accents = new Regex("[á|à|ä|â|Á|À|Ä|Â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê|É|È|Ë|Ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î|Í|Ì|Ï|Î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô|Ó|Ò|Ö|Ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û|Ú|Ù|Ü|Û]", RegexOptions.Compiled);
            s = replace_a_Accents.Replace(s, "a");
            s = replace_e_Accents.Replace(s, "e");
            s = replace_i_Accents.Replace(s, "i");
            s = replace_o_Accents.Replace(s, "o");
            s = replace_u_Accents.Replace(s, "u");
            s = s.Replace("\\", " ");
            s = s.Replace("     ", " ");
            s = s.Replace("    ", " ");
            s = s.Replace("   ", " ");
            s = s.Replace("  ", " ");
            s = s.ToUpper();
            return s;
        }


        public static bool CompararString(string s1, string s2)
        {
            s1 = QuitarAcentos(s1);
            s2 = QuitarAcentos(s2);
            return s1.Equals(s2);
        }


        //Función para mostrar el correo con 'X' en lugar de ciertos caracteres dependiendo de la longitud
        /*
        orden           0	1	2	3	4	5	6
        long            1	2	3	4	5	6	7

        num caracteres  | Resultado
            >7	        1	2	x	x	x	6	7
            6	        1	2	x	x	x	6	
            5	        1	2	x	x	5		
            4	        1	x	x	4			
            3	        1	x	x				
            2	        1	x					
         */
        public static string ofuscarCorreo(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                return null;
            }

            int arroba = correo.IndexOf("@");

            string usuario = arroba < 1 ? correo : correo.Substring(0, arroba);

            int longitud_usuario = usuario.Length;

            StringBuilder sb = new StringBuilder(correo);

            if (longitud_usuario > 1)
                switch (longitud_usuario)
                {
                    case 2:
                        sb[1] = 'x';
                        break;
                    case 3:
                        sb[1] = 'x'; sb[2] = 'x';
                        break;
                    case 4:
                        sb[1] = 'x'; sb[2] = 'x';
                        break;
                    case 5:
                        sb[2] = 'x'; sb[3] = 'x';
                        break;
                    case 6:
                        sb[2] = 'x'; sb[3] = 'x'; sb[4] = 'x';
                        break;
                    default:
                        for (int i = 2; i <= longitud_usuario - 3; i++)
                            sb[i] = 'x';
                        break;

                }

            correo = sb.ToString();

            return correo;
        }

        public static string ofuscarCadena(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
            {
                return null;
            }

            int longitud = cadena.Length;

            StringBuilder sb = new StringBuilder(cadena);

            if (longitud > 1)
                switch (longitud)
                {
                    case 2:
                        sb[1] = 'X';
                        break;
                    case 3:
                        sb[1] = 'X'; sb[2] = 'X';
                        break;
                    case 4:
                        sb[1] = 'X'; sb[2] = 'X';
                        break;
                    case 5:
                        sb[2] = 'X'; sb[3] = 'X';
                        break;
                    case 6:
                        sb[2] = r(sb[2]); sb[3] = r(sb[3]); sb[4] = r(sb[4]);
                        break;
                    case 7:
                        sb[2] = r(sb[2]); sb[3] = r(sb[3]); sb[4] = r(sb[4]);
                        break;
                    case 8:
                        sb[3] = r(sb[3]); sb[4] = r(sb[4]); sb[5] = r(sb[5]);
                        break;
                    case 9:
                        sb[3] = r(sb[3]); sb[4] = r(sb[4]); sb[5] = r(sb[5]);
                        break;
                    case 10:
                        sb[3] = r(sb[3]); sb[4] = r(sb[4]); sb[5] = r(sb[5]); ; sb[6] = r(sb[6]);
                        break;
                    case 11:
                        sb[4] = r(sb[4]); sb[5] = r(sb[5]); sb[6] = r(sb[6]); ; sb[7] = r(sb[7]);
                        break;
                    default:
                        if (longitud > 20)
                            for (int i = 7; i <= longitud - 7; i++)
                                sb[i] = r(sb[i]);
                        else
                            for (int i = 4; i <= longitud - 3; i++)
                                sb[i] = r(sb[i]);
                        break;
                }
            cadena = sb.ToString();

            return cadena;
        }

        public static string ofuscarDireccion(string cadena)
        {


            if (string.IsNullOrEmpty(cadena))
            {
                return string.Empty;
            }

            cadena = cadena.Trim();

            char[] whitespace = new char[] { ' ', '\t' };
            string[] palabras = cadena.Split(whitespace);



            if (palabras.Length >= 1 && palabras.Length <= 6)
            {
                for (int i = 1; i < palabras.Length; i += 2)
                    palabras[i] = new Regex("\\S").Replace(palabras[i], "x");
            }

            if (palabras.Length > 6)
            {
                bool[] pintar = { false, true, true, false, false, false, true, false, false, true, true, false, false, false, true };
                int j = 0;
                for (int i = 0; i < palabras.Length; i++)
                {

                    if (pintar[j])
                        palabras[i] = new Regex("\\S").Replace(palabras[i], "x");

                    //Si es el íltimo ítem del patron para pintar se reinicia el contador j
                    if (j + 1 == pintar.Length)
                        j = 0;
                    else
                        j++;

                }

            }


            return string.Join(" ", palabras);
        }

        private static char r(char c)
        {
            char letra = c == ' ' ? c : 'X';
            return letra;
        }

        private static char r1(char c, char ant, char post)
        {
            if (ant == ' ' && post == ' ')
                return c;
            else
                return c == ' ' ? c : 'X';

        }


        //El id a seleccionar debe estar en la posicion [1]
        public static ArrayList ObtenerIdsCheckedValues(GridView grid)
        {
            //Se obtiene el array de las materias seleccionadas
            ArrayList array = new ArrayList();
            foreach (GridViewRow row in grid.Rows)
            {
                if ((row.FindControl("chkSelect") as CheckBox).Checked)
                {
                    array.Add(row.Cells[1].Text);
                }
            }

            return array;
        }

        public static List<int> listInt(string cadena, char delimitador = ',')
        {
            string[] strArray = cadena.Split(delimitador);
            List<int> listInt = Array.ConvertAll(strArray, int.Parse).ToList();
            return listInt;
        }

        public static List<int?> listIntNull(string cadena)
        {
            string[] strArray = cadena.Split(',');
            List<int> listInt = Array.ConvertAll(strArray, int.Parse).ToList();
            return listInt.Select(i => (int?)i).ToList();
        }

        public static List<string> listStr(string cadena,char delimitador = ',')
        {
            List<string> listStr = cadena.Split(delimitador).ToList();
            return listStr;
        }

        public static string strANull(string cadena)
        {
            cadena = String.IsNullOrWhiteSpace(cadena) ? "null" : cadena;

            return cadena;
        }

        public static string strNull(string cadena)
        {
            cadena = String.IsNullOrWhiteSpace(cadena) ? null : cadena;

            return cadena;
        }
        public static int? intNull(int? numero)
        {
            numero = numero == null ? 0 : numero;

            return numero;
        }

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string StringExt(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            else
            {
                value = value.Trim();
                return value.Length <= maxLength ? value : value.Substring(0, maxLength);
            }

        }

        public static string VerificarTipoDocumento(string identificacion)
        {
            int longitud = identificacion.Length;
            string tipo = "P";

            switch (longitud)
            {
                case 10:
                    tipo = "C";
                    break;
                case 13:
                    tipo = "R";
                    break;
            }

            return tipo;
        }

        public static Tuple<string, string> SeprararNombres(string nombreCompleto)
        {
            string nombres = null;
            string apellidos = null;

            string[] ns = nombreCompleto.Split(' ');
            int cantidad = ns.Count() >= 6 ? 6 : ns.Count();

            if (cantidad > 0)
                for (int i = 0; i <= cantidad - 1; i++)
                    ns[i] = ns[i].Trim();

            switch (cantidad)
            {
                case 1:
                    apellidos = ns[0];
                    break;
                case 2:
                    apellidos = ns[0];
                    nombres = ns[1];

                    break;
                case 3:
                    apellidos = ns[0] + " " + ns[1];
                    nombres = ns[2];
                    break;
                case 4:
                    apellidos = ns[0] + " " + ns[1];
                    nombres = ns[2] + " " + ns[3];
                    break;
                case 5:
                    apellidos = ns[0] + " " + ns[1] + " " + ns[2]; ;
                    nombres = ns[3] + " " + ns[4];
                    break;
                case 6:
                    apellidos = ns[0] + " " + ns[1] + " " + ns[2]; ;
                    nombres = ns[3] + " " + ns[4] + " " + ns[4];
                    break;
            }

            return new Tuple<string, string>(nombres, apellidos);
        }
    }
}
