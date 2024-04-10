using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private string connectionString = "Data Source=your_server;Initial Catalog=EmpresaDB;Integrated Security=True";

    public Form1()
    {
        InitializeComponent();
    }

    private void btnIngresar_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("INSERT INTO Trabajadores (Nombre, Apellidos, SueldoBruto, Categoria) VALUES (@Nombre, @Apellidos, @SueldoBruto, @Categoria)", connection))
            {
                command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                command.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                command.Parameters.AddWithValue("@SueldoBruto", decimal.Parse(txtSueldoBruto.Text));
                command.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                command.ExecuteNonQuery();
            }
        }

        MessageBox.Show("Trabajador ingresado exitosamente!");
    }

    private void btnMostrar_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Trabajadores", connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }
    }

    private void btnTotalSueldos_Click(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SELECT SUM(SueldoNeto) FROM Trabajadores", connection))
            {
                object result = command.ExecuteScalar();
                MessageBox.Show($"Monto total de sueldos netos: {result}");
            }
        }
    }
}