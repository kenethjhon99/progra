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
    public partial class trabajadores : Form
    {
        List<clientes> clientes = new List<clientes>();
        List<producto> producto = new List<producto>();
        List<venta> ventas = new List<venta>();
        String nit;
        String nombre;
        public trabajadores()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String client = "clientes.txt";
            FileStream stream = new FileStream(client, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(stream);
            while (leer.Peek() > -1)
            {
                clientes tem = new clientes();
                tem.Nit = leer.ReadLine();
                tem.Nombre = leer.ReadLine();

                clientes.Add(tem);
            }
            leer.Close();
            for (int q = 0; q < clientes.Count; q++)
            {
                if (textBox1.Text == clientes[q].Nit)
                {
                    textBox2.Text = (clientes[q].Nombre);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String cliente = "clientes.txt";
            FileStream escribir = new FileStream(cliente, FileMode.Append, FileAccess.Write);
            StreamWriter agregar = new StreamWriter(escribir);
            agregar.WriteLine(textBox1.Text);
            agregar.WriteLine(textBox2.Text);
            agregar.Close();
            limpiar();
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ind = dataGridView1.CurrentRow.Index;
            int monto = Convert.ToInt32(textBox3.Text);
            if (monto > (Convert.ToInt32(producto[ind].Esistencias)))
            {
                MessageBox.Show("no es posible realizar lo deseado, hay que verificar los datos");
            }
            else

            {
                float tot = monto * Convert.ToInt32(producto[ind].Prcio);
                venta temp = new venta();
                temp.Producto = producto[ind].Nombreproducto;
                temp.Precio = Convert.ToInt32(producto[ind].Prcio);
                temp.Existencias = monto;
                producto[ind].Esistencias = producto[ind].Esistencias - monto;
                temp.Total = tot;
                ventas.Add(temp);
                productoActualizado();
                verProductos();



            }

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
                tem.Esistencias = Convert.ToInt32(reader.ReadLine());
                tem.Costo = reader.ReadLine();
                //   tem.Total = reader.ReadLine();
                producto.Add(tem);
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = producto;
            dataGridView1.Refresh();
            reader.Close();
            for (int f = 0; f < producto.Count; f++)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = producto;
                dataGridView1.Refresh();
                dataGridView1.Columns["costo"].Visible = false;
            }
        }
        public void verProductos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = producto;
            dataGridView1.Refresh();
            dataGridView1.Columns["costo"].Visible = false;
        }
        public void productoActualizado()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = ventas;
            dataGridView2.Refresh();
        }
        private void trabajadores_Load(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
