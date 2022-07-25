using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Entidad;
using System.Data;



namespace Datos
{
    public class D_Caracteristicas
    {
        SqlConnection Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Caracteristicas> ListarDatos(string buscar)
        {
            SqlDataReader leerfilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCONTACTO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerfilas = cmd.ExecuteReader();

            List<E_Caracteristicas> Listar = new List<E_Caracteristicas>();
            while (leerfilas.Read())
            {
                Listar.Add(new E_Caracteristicas
                {
                    Id = leerfilas.GetInt32(0),
                    Nombre = leerfilas.GetString(1),
                    Apellido = leerfilas.GetString(2),
                    Telefono = leerfilas.GetInt32(3),
                    Estado_Civil = leerfilas.GetString(4),
                    Genero = leerfilas.GetString(5),
                    Correo = leerfilas.GetString(6),
                    Direccion = leerfilas.GetString(7),

                });
            }
            Conexion.Close();
            leerfilas.Close();
            return Listar;

        }

        public void InsertarDatos(E_Caracteristicas Datos)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCONTACTO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID", Datos.Id);
            cmd.Parameters.AddWithValue("@NOMBRE", Datos.Nombre);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarDatos(E_Caracteristicas Datos)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCONTACTO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID", Datos.Id);
            cmd.Parameters.AddWithValue("@NOMBRE", Datos.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", Datos.Apellido);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarCategoria(E_Caracteristicas Datos)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCONTACTO", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@ID", Datos.Id);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        
        }
    }
}
