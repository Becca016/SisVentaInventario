using System;
using System.Data.SqlClient;

namespace SisVentaInventario.DATOS
{
    public class Conexion
    {
        private string Basededatos;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;
        
        
        //Constructor para la conexión
        private Conexion()
        {
            this.Basededatos = "BD_VENTASINVENTARIO";
            this.Servidor = "LAPTOP-1O3ISDPS";
            this.Usuario = "user_ventas";
            this.Clave = "Ventas.2026";
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                         ";Database=" + this.Basededatos +
                                         ";User id=" + this.Usuario +
                                         ";Password=" + this.Clave;
            }
            catch(Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
    
}
