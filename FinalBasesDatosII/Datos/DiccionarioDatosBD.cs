using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBasesDatosII.Datos
{
    public class DiccionarioDatosBD
    {
        public string ExceptionOracle { get; set; }
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


        public bool Realizaraupdate(string sentencia)
        {
            ConexionBD conexionBD = new ConexionBD();
            OracleConnection miConexion = conexionBD.ObtenerConexion();

            try
            {
                miConexion.Open();
                OracleCommand command = new OracleCommand("updatePackage.spcActualizarTabla", miConexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("v_updateQuery", OracleDbType.Varchar2).Value = sentencia;
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
            finally
            {
                miConexion.Close();
            }
        }

        public DataSet ConsultaDiccionario(string pColumnas)
        {
            this.ExceptionOracle = "";
            ConexionBD conexionBD = new ConexionBD();
            OracleConnection miConexion = conexionBD.ObtenerConexion();

            try
            {
                //abrir la conexion
                miConexion.Open();
                OracleCommand ora_cmd = new OracleCommand("updatePackage.spCONSULTADICCIONARIO", miConexion);
                ora_cmd.Parameters.Add("O_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                ora_cmd.Parameters.Add("V_COL", OracleDbType.Varchar2, pColumnas, ParameterDirection.Input);
                ora_cmd.CommandType = CommandType.StoredProcedure;
                //un OracleDataAdapter permite llenar un dataset
                OracleDataAdapter da = new OracleDataAdapter(ora_cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TECLADOS");
                return ds;
            }
            catch (Exception e)
            {
                
                return null;
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
