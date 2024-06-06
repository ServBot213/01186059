using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Persistencias
{
    public class CD_Conexion
    {
        private SqlConnection connection = new SqlConnection("Server=localhost;Database=Proyecto;Integrated Security=true;");


        public SqlConnection AbrirConexion()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }


        public SqlConnection CerrarConexion()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return connection;
        }
    }
}
