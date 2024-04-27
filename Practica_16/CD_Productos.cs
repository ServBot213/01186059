using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_16
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ShowProducts";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertProducts";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@name", nombre);
            comando.Parameters.AddWithValue("@description", desc);
            comando.Parameters.AddWithValue("@brand", marca);
            comando.Parameters.AddWithValue("@price", precio);
            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();


        }

        public void Editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditProducts";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@name", nombre);
            comando.Parameters.AddWithValue("@description", desc);
            comando.Parameters.AddWithValue("@brand", marca);
            comando.Parameters.AddWithValue("@price", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();

        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DeleteProduct";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@productId", SqlDbType.Int).Value = id;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}

