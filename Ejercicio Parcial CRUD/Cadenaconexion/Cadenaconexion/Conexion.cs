using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Cadenaconexion
{
    // Define una clase llamada 'Conexion' dentro del espacio de nombres 'Cadenaconexion'
    internal class Conexion
    {
        // Define un método público y estático llamado 'Conectar' que retorna un objeto SqlConnection
        public static SqlConnection Conectar()
        {
            // Define la cadena de conexión para conectarse a la base de datos SQL Server
            // 'Data Source' especifica la instancia del servidor a la que conectarse
            // 'Database' especifica la base de datos a utilizar
            // 'Integrated Security=True' indica que se usa la autenticación de Windows
            string connectionString = "Data Source=DESKTOP-0TAD2UR\\SQLEXPRESS;Database=Northwind;Integrated Security=True;";

            // Crea un nuevo objeto SqlConnection utilizando la cadena de conexión definida anteriormente
            SqlConnection cn = new SqlConnection(connectionString);

            // Abre la conexión SQL con la base de datos
            cn.Open();

            // Retorna el objeto SqlConnection abierto para que pueda ser utilizado por el llamador
            return cn;
        }
    }
}
