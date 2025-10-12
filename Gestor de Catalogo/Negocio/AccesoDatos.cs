using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Negocio
{
    public class AccesoDatos : IDisposable
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CATALOGO_DB"].ConnectionString;
            conexion = new SqlConnection(connectionString);
            comando = new SqlCommand();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void Consulta(string c)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = c;
        }

        public void Parametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarConsulta()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void EjecutarComando()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        private void CerrarConexion()
        {
            if (lector != null)
                lector.Close();
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
        public void Dispose()
        {
            bool disposing = true;
            MessageBox.Show("Hola desde dispose");
            CerrarConexion();
            comando?.Dispose();
            conexion?.Dispose();
        }

    }
}
