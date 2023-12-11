using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBasesDatosII.Datos
{
    internal class DiccionarioDatosBD
    {

        public bool validarExistenciaTablaBD(string nombreTabla)
        {
            ConexionBD conexionBD = new ConexionBD();
            OracleConnection miConexion = conexionBD.ObtenerConexion();

            try
            {
                miConexion.Open();
                OracleCommand command = new OracleCommand("updatePackage.spValidarExistenciaTabla", miConexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("v_nombreTabla", OracleDbType.Varchar2, nombreTabla,ParameterDirection.Input);
                command.Parameters.Add("V_EXISTE", OracleDbType.Varchar2, 256).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                string existe = command.Parameters["V_EXISTE"].Value.ToString();

                return existe.Equals("SI");
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (miConexion.State == ConnectionState.Open)
                {
                    miConexion.Close();
                }
            }
        }


        public bool ValidarDatosTablaBD(string nombreTabla)
        {
            ConexionBD conexionBD = new ConexionBD();
            OracleConnection miConexion = conexionBD.ObtenerConexion();

            try
            {
                miConexion.Open();
                OracleCommand command = new OracleCommand("updatePackage.spValidarDatosTabla", miConexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("v_nombreTabla", OracleDbType.Varchar2, nombreTabla, ParameterDirection.Input);
                command.Parameters.Add("V_EXISTE", OracleDbType.Varchar2, 256).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                string existe = command.Parameters["V_EXISTE"].Value.ToString();


                return existe.Equals("SI");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            finally
            {
                if (miConexion.State == ConnectionState.Open)
                {
                    miConexion.Close();
                }
            }

        }

        public bool ValidarColumnaBD(string nombreTabla, string nombreColumna)
        {
            ConexionBD conexionBD = new ConexionBD();
            OracleConnection miConexion = conexionBD.ObtenerConexion();

            try
            {
                miConexion.Open();
                OracleCommand command = new OracleCommand("updatePackage.spValidarColumna", miConexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("v_nombreTabla", OracleDbType.Varchar2, nombreTabla, ParameterDirection.Input);
                command.Parameters.Add("v_nombreColumna", OracleDbType.Varchar2, nombreColumna, ParameterDirection.Input);
                command.Parameters.Add("V_EXISTE", OracleDbType.Varchar2, 256).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                string existe = command.Parameters["V_EXISTE"].Value.ToString();


                return existe.Equals("SI");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            finally
            {
                if (miConexion.State == ConnectionState.Open)
                {
                    miConexion.Close();
                }
            }

        }

    }
}
