using System;
using System.Data.SqlClient;
using System.Data;
using SisVentaInventario.ENTIDADES;   //Se importa la clase E_TiposEmpresas


namespace SisVentaInventario.DATOS
    
{
    public class D_TiposEmpresas
    {
       
        public DataTable Listado_te(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("usp_Listado_te", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Tabla;
        }

        public string Guardar_te(int nOpcion, E_TiposEmpresas oTe)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("usp_Guardar_te", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nOpcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@cCodigo_te", SqlDbType.Int).Value = oTe.Codigo_te;
                Comando.Parameters.Add("@cDescripcion_te", SqlDbType.VarChar).Value = oTe.Descripcion_te;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "Ok" : "¡No se pudo ingresar el registro!";
            }
            catch (Exception ex)
            {

                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;

        }

        public string Activo_te(int nCodigo_te)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCommand Comando = new SqlCommand("usp_Activo_te", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_te", SqlDbType.Int).Value = nCodigo_te;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "¡No se pudo cambiar el estado del registro!";

            }
            catch (Exception ex)
            {

                Rpta= ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
            
        }

    }
}
