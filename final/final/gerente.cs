using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final
{
    public partial class gerente : Form
    {
        List<producto> producto = new List<producto>();
        String nombre;
        String cantidad;
        String precio;
        String codigo;
        Usuarios nuevo = new Usuarios();
        public gerente()
        {
            mostrar();
            InitializeComponent();
        }
        public gerente(Usuarios entrada)
        {
            nuevo = entrada;
            InitializeComponent();
        }

        private void gerente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            nombre = textBox1.Text;
            codigo=textBox2.Text;
            precio = textBox3.Text;
            cantidad=textBox4.Text;
            String mercaderia = "producto.txt";
            FileStream escribir = new FileStream(mercaderia, FileMode.Append, FileAccess.Write);
            StreamWriter agregar = new StreamWriter(escribir);
            agregar.WriteLine(nombre);
            agregar.WriteLine(codigo);
            agregar.WriteLine(precio);
            agregar.WriteLine(cantidad);
            agregar.Close();
            mostrar();
            limpiar();
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public void mostrar()
        {
            string mercaderia = "producto.txt";
            FileStream leer = new FileStream(mercaderia, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(leer);
            while (reader.Peek() > -1)
            {
                producto tem = new producto();
                tem.Nombreproducto = reader.ReadLine();
                tem.Codigo = reader.ReadLine();
                tem.Prcio = reader.ReadLine();
                tem.Esistencias = reader.ReadLine();
                tem.Total = reader.ReadLine();
                producto.Add(tem);
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = producto;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
