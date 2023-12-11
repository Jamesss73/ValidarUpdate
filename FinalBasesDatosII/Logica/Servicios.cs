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

        public DataTable ValidarSintaxis(string sentenciaSQL)
        {
            string pattern = @"^UPDATE\s+([\w\d_]+)\s+SET\s+((?:\w+\s*=\s*[\w\d'/]+(?:,\s*)?)+)\s+WHERE\s+(.+);$";

            Match match = Regex.Match(sentenciaSQL, pattern);

            if (match.Success)
            {
                string nombreTabla = match.Groups[1].Value;
                string columnas = match.Groups[2].Value;

                Console.WriteLine("Nombre de la tabla: " + nombreTabla);

                string[] nombresColumnas = columnas.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(c => c.Trim().Split('=')[0])
                                                    .ToArray();

                Console.WriteLine("Nombres de las columnas:");
                if (nombresColumnas.Length > 4||nombresColumnas.Length <= 0)
                {
                    return new DataTable();
                }
                else {
                    // Crear un DataTable para almacenar los resultados
                    DataTable resultadosTabla = new DataTable();

                    // Agregar columnas al DataTable para representar los resultados de los métodos
                    resultadosTabla.Columns.Add("NombreTabla", typeof(string));
                    resultadosTabla.Columns.Add("ExistenciaTabla", typeof(bool));
                    resultadosTabla.Columns.Add("DatosValidados", typeof(bool));
                    resultadosTabla.Columns.Add("ColumnasValidadas", typeof(string));

                    // Suponiendo que tienes una lista de nombres de columnas

                    // Suponiendo que tienes los métodos para validar existencia, datos y columnas
                    bool existeTabla = validarExistenciaTabla(nombreTabla);
                    bool datosValidados = ValidarDatosTabla(nombreTabla);
                    string columnasValidadas="";

              
                    validarExistenciaTabla(nombreTabla);
                    ValidarDatosTabla(nombreTabla);
                    foreach (string nombreColumna in nombresColumnas ) {
                        columnasValidadas += nombreColumna;
                        if (ValidarColumna(nombreTabla, nombreColumna))
                        {
                            columnasValidadas += ": Si";
                        }
                        else {
                            columnasValidadas += ": No";

                        }
                    }
                    // Agregar los resultados a una fila en el DataTable
                    resultadosTabla.Rows.Add(nombreTabla, existeTabla, datosValidados, columnasValidadas);



                    return resultadosTabla;

                }

            }
            return new DataTable();

        }


        private bool validarExistenciaTabla(string nombreTabla)
        {
            return dicBD.validarExistenciaTablaBD(nombreTabla);
        }
        private bool ValidarDatosTabla(string nombreTabla) {
            return dicBD.ValidarDatosTablaBD(nombreTabla);
                }

        private bool ValidarColumna(string nombreTabla,string  nombreColumna)
        {
            return dicBD.ValidarColumnaBD(nombreTabla, nombreColumna);
        }
    }
}
