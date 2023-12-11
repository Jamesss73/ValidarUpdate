using FinalBasesDatosII.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalBasesDatosII.Logica
{
    public class Servicios
    {//Creo un objeto para comunicarme con la capa de Datos
        DiccionarioDatosBD dicBD = new DiccionarioDatosBD();


        //Crear metodo para validar existencia de la Tabla

        public String ValidarSintaxis(string sentenciaSQL)
        {
            bool hacerUpdate = false;
            string pattern = @"^UPDATE\s+([\w\d_]+)\s+SET\s+((?:\w+\s*=\s*[\w\d'/]+(?:,\s*)?)+)\s+WHERE\s+(.+);$";

            bool existeTabla = false;
            bool datosValidados = false;
            bool columnasValidadas = true;
            string resultados = "";


            Match match = Regex.Match(sentenciaSQL, pattern);

            if (match.Success)
            {
                string nombreTabla = match.Groups[1].Value;
                string columnas = match.Groups[2].Value;

                Console.WriteLine("Nombre de la tabla: " + nombreTabla);

                string[] nombresColumnas = columnas.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(c => c.Trim().Split('=')[0])
                                                    .ToArray();

                if (nombresColumnas.Length > 4 || nombresColumnas.Length <= 0)
                {
                    resultados += " Tienes mas columnas de las presentes en la tabla \n ";
                }
                else
                {
                    if (validarExistenciaTabla(nombreTabla))
                    {
                        resultados += $"lA TABLA {nombreTabla} EXISTE\n";
                        existeTabla = true;
                    }
                    else
                    {
                        resultados += $"lA TABLA {nombreTabla} NO EXISTE\n";
                    }


                    if (ValidarDatosTabla(nombreTabla))
                    {
                        resultados += $"lA TABLA {nombreTabla} TIENE DATOS\n";
                        datosValidados = true;
                    }
                    else
                    {
                        resultados += $"lA TABLA {nombreTabla} NO TIENE DATOS\n ";
                    }

                    foreach (string nombreColumna in nombresColumnas)
                    {

                        if (ValidarColumna(nombreTabla, nombreColumna))
                        {
                            resultados += $"La columna {nombreColumna} existe\n";
                            if (columnasValidadas)
                            {
                                columnasValidadas = true;
                            }
                        }
                        else
                        {
                            resultados += $"La columna {nombreColumna} NO existe\n";
                            columnasValidadas = false;
                        }


                    }
                    if (existeTabla && datosValidados && columnasValidadas)
                    {
                        hacerUpdate = true;
                    }
                    else
                    {
                        resultados += "No se puede realizar el update\n";
                    }


                    if (hacerUpdate)
                    {
                        if (Updatecolumn(sentenciaSQL))
                        {
                            resultados += "Se realizo el update correctamente\n";
                        }
                        else
                        {
                            resultados += "NO Se realizo el update\n";
                        }
                    }




                    return resultados;

                }

            }


            return "no se puede realizar la consulta" + EncontrarError(pattern, sentenciaSQL);

        }


        private bool validarExistenciaTabla(string nombreTabla)
        {
            return dicBD.validarExistenciaTablaBD(nombreTabla);
        }
        private bool ValidarDatosTabla(string nombreTabla)
        {
            return dicBD.ValidarDatosTablaBD(nombreTabla);
        }

        private bool ValidarColumna(string nombreTabla, string nombreColumna)
        {
            return dicBD.ValidarColumnaBD(nombreTabla, nombreColumna);
        }

        private bool Updatecolumn(string sentencia)
        {

            return dicBD.Realizaraupdate(sentencia);
        }





        private string[] DividirConsulta(string consulta)
        {
            consulta = Regex.Replace(consulta, "\\s+", " ");
            consulta = Regex.Replace(consulta, "\\s*,\\s*", ",");
            return Regex.Split(consulta, @"\s");
        }


        private string EncontrarError(string formato, string consulta)
        {
            string resultado = "";
            string[] partes = DividirConsulta(consulta);
            string error = dicBD.ExceptionOracle;
            var data = dicBD.ConsultaDiccionario("COLUMN_NAME, DATA_TYPE");
            string cols = partes[1];
            string[] columnas = Regex.Split(cols, @"\s*,\s*");


            if (error.Equals("Identificador invalido"))
            {
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < columnas.Length; j++)
                    {
                        if (data.Tables[0].Rows[i].ItemArray[0].Equals(columnas[j]))
                        {
                            cols = Regex.Replace(cols, columnas[j], "");
                        }
                    }
                }
                string[] c = Regex.Split(cols, ",");
                resultado += string.Format(":\n");
                foreach (string l in c)
                {
                    resultado += string.Format("La columna {0} no existe\n", l);
                }
            }

            return resultado;

        }



    }
}
