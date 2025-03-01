using Microsoft.Data.SqlClient;

namespace CasaStark.Models
{
    public class AccesoDatos
    {
        //almacenar la cadena de conexion a la base de datos
        private readonly string _conexion;
         
        public AccesoDatos(IConfiguration configuracion)
        {
            _conexion = configuracion.GetConnectionString("Conexion");
        }

        //Metodo que busca crear el miembro de la casa Stark
        public void AgregarMiembro(Miembros nuevoMiembro) 
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {

                    string query = "EXEC spCrearMiembro @pNombre, @pHabilidad, @pRol";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pNombre", nuevoMiembro.Nombre);
                        cmd.Parameters.AddWithValue("@pHabilidad", nuevoMiembro.Habilidad);
                        cmd.Parameters.AddWithValue("@pRol", nuevoMiembro.Rol);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar el miembro: " + ex.Message);
                }
            }
        }
    }
}