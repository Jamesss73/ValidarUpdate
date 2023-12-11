using FinalBasesDatosII.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FinalBasesDatosII.Datos;

namespace FinalBasesDatosII.Logica
{
    internal class DiccionarioDatos
    {
        //Creo un objeto para comunicarme con la capa de Datos
        DiccionarioDatosBD dicBD = new DiccionarioDatosBD();


        //Crear metodo para validar existencia de la Tabla
        public bool validarExistenciaTabla(String nombreTabla)
        {
            return dicBD.validarExistenciaTablaBD( nombreTabla);
        }

    }
}
