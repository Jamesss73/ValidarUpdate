using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBasesDatosII.Datos
{
    class ConexionBD
    {
     
            private OracleConnection conexion;

            // Constructor
            public ConexionBD()
            {
                string cadenaConexion = "Data Source=LOCALHOST;User Id=BD2;Password=oracle;";
                conexion = new OracleConnection(cadenaConexion);
            }

            // Método para abrir la conexión
            public void AbrirConexion()
            {
                try
                {
                    if (conexion.State != System.Data.ConnectionState.Open)
                        conexion.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                }
            }

            // Método para cerrar la conexión
            public void CerrarConexion()
            {
                try
                {
                    if (conexion.State != System.Data.ConnectionState.Closed)
                        conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
                }
            }

            // Obtener la conexión (opcional, para usarla en otros lugares)
            public OracleConnection ObtenerConexion()
            {
                return conexion;
            }
        
    }
}
