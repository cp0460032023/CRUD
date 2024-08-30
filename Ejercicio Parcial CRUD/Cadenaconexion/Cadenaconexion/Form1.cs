using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Cadenaconexion
{
    // Clase parcial Form1 que hereda de Form
    public partial class Form1 : Form
    {
        // Constructor de la clase Form1
        public Form1()
        {
            // Inicializa los componentes del formulario
            InitializeComponent();
        }

        // Evento que se ejecuta cuando el formulario se carga
        private void Form1_Load(object sender, EventArgs e)
        {
            // Conecta a la base de datos
            Conexion.Conectar();
            // Muestra un mensaje indicando que el proceso se realizó
            MessageBox.Show(" SE REALIZÓ EL PROCESO ");

            // Rellena el DataGridView con los datos obtenidos de la base de datos
            dataGridView1.DataSource = Llenar_grid();
        }

        // Método que devuelve un DataTable con los datos de la tabla Customers
        public DataTable Llenar_grid()
        {
            // Conecta a la base de datos
            Conexion.Conectar();
            // Crea una nueva instancia de DataTable
            DataTable dt = new DataTable();
            // Consulta SQL para seleccionar todos los datos de la tabla Customers
            string consulta = "SELECT * FROM Customers";
            // Crea un comando SQL con la consulta y la conexión
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            // Crea un adaptador de datos con el comando SQL
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Llena el DataTable con los resultados de la consulta
            da.Fill(dt);
            // Devuelve el DataTable
            return dt;
        }

        // Evento que se ejecuta cuando se hace clic en el botón 1
        private void button1_Click(object sender, EventArgs e)
        {
            // Conecta a la base de datos
            Conexion.Conectar();
            // Consulta SQL para insertar un nuevo registro en la tabla Customers
            string insertar = "INSERT INTO Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country) VALUES(@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country)";
            // Crea un comando SQL con la consulta de inserción y la conexión
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            // Añade los parámetros al comando con los valores de los controles de texto
            cmd1.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd1.Parameters.AddWithValue("@CompanyName", textBox4.Text);
            cmd1.Parameters.AddWithValue("@ContactName", textBox7.Text);
            cmd1.Parameters.AddWithValue("@ContactTitle", textBox2.Text);
            cmd1.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd1.Parameters.AddWithValue("@City", textBox8.Text);
            cmd1.Parameters.AddWithValue("@Region", textBox3.Text);
            cmd1.Parameters.AddWithValue("@PostalCode", textBox6.Text);
            cmd1.Parameters.AddWithValue("@Country", textBox9.Text);

            // Ejecuta la consulta de inserción
            cmd1.ExecuteNonQuery();

            // Muestra un mensaje indicando que los datos se añadieron correctamente
            MessageBox.Show("¡Los datos fueron añadidos sin problemones!");

            // Rellena el DataGridView con los datos actualizados
            dataGridView1.DataSource = Llenar_grid();
        }

        // Evento que se ejecuta cuando se hace clic en una celda del DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Rellena los controles de texto con los valores de la celda seleccionada en el DataGridView
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch
            {
                // Manejo de excepciones vacío
            }
        }

        // Evento que se ejecuta cuando se hace clic en el botón 2
        private void button2_Click(object sender, EventArgs e)
        {
            // Conecta a la base de datos
            Conexion.Conectar();
            // Consulta SQL para actualizar un registro existente en la tabla Customers
            string actualizar = "UPDATE Customers SET CustomerID=@CustomerID, CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country WHERE CustomerID=@CustomerID";
            // Crea un comando SQL con la consulta de actualización y la conexión
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            // Añade los parámetros al comando con los valores de los controles de texto
            cmd2.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd2.Parameters.AddWithValue("@CompanyName", textBox4.Text);
            cmd2.Parameters.AddWithValue("@ContactName", textBox7.Text);
            cmd2.Parameters.AddWithValue("@ContactTitle", textBox2.Text);
            cmd2.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd2.Parameters.AddWithValue("@City", textBox8.Text);
            cmd2.Parameters.AddWithValue("@Region", textBox3.Text);
            cmd2.Parameters.AddWithValue("@PostalCode", textBox6.Text);
            cmd2.Parameters.AddWithValue("@Country", textBox9.Text);

            // Ejecuta la consulta de actualización
            cmd2.ExecuteNonQuery();
            // Muestra un mensaje indicando que los datos se actualizaron correctamente
            MessageBox.Show("¡Los datos han sido actualizados, enhorabuena :)!");
            // Rellena el DataGridView con los datos actualizados
            dataGridView1.DataSource = Llenar_grid();
        }

        // Evento que se ejecuta cuando se hace clic en el botón 3
        private void button3_Click(object sender, EventArgs e)
        {
            // Conecta a la base de datos
            Conexion.Conectar();
            // Consulta SQL para eliminar un registro de la tabla Customers
            string eliminar = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
            // Crea un comando SQL con la consulta de eliminación y la conexión
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());

            // Añade el parámetro al comando con el valor del control de texto
            cmd3.Parameters.AddWithValue("@CustomerID", textBox1.Text);

            // Ejecuta la consulta de eliminación
            cmd3.ExecuteNonQuery();

            // Muestra un mensaje indicando que los datos se eliminaron correctamente
            MessageBox.Show("Los datos se han eliminado :O");

            // Rellena el DataGridView con los datos actualizados
            dataGridView1.DataSource = Llenar_grid();
        }

        // Evento que se ejecuta cuando se hace clic en el botón 4
        private void button4_Click(object sender, EventArgs e)
        {
            // Limpia todos los controles de texto
            textBox1.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox9.Clear();

            // Enfoca el primer control de texto
            textBox1.Focus();
        }

        // Evento que se ejecuta cuando cambia el texto en el textBox10 (no implementado)
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            // No se ha implementado ninguna acción para este evento
        }
    }
}
