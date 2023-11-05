using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccesoADatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get
            {
                return lector;
            }
        }

        public AccesoADatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CallCenter; integrated security=true"); //la database hay que cambiarla si se usa otro nombre
            comando = new SqlCommand();
        }

        public AccesoADatos(string connec)
        {
            conexion = new SqlConnection(connec);
            comando = new SqlCommand();
        }

        public void AbrirConexion()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
        }

        public void consultar(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        
        public void setearProcedimiento(string sp)
        {
            comando.CommandType=System.Data.CommandType.StoredProcedure;
            comando.CommandText=sp;
        }
    }
}
