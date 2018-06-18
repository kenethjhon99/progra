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
        String costo;
        //float total;
        int edit;
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
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // total= 
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            nombre = textBox1.Text;
            codigo=textBox2.Text;
            precio = textBox3.Text;
            cantidad=textBox4.Text;
            costo = textBox9.Text;
            String mercaderia = "producto.txt";
            FileStream escribir = new FileStream(mercaderia, FileMode.Append, FileAccess.Write);
            StreamWriter agregar = new StreamWriter(escribir);
            agregar.WriteLine(nombre);
            agregar.WriteLine(codigo);
            agregar.WriteLine(precio);
            agregar.WriteLine(cantidad);
            agregar.WriteLine(costo);
            agregar.Close();
            mostrar();
            actualizar();
            limpiar();
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
        }
        public void actualizar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = producto;
            dataGridView1.Refresh();
        }
        public void mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            producto = new List<producto>();
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
                producto.Add(tem);
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = producto;
            dataGridView1.Refresh();
            reader.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            int edit = dataGridView1.CurrentRow.Index;
            textBox5.Text = producto[edit].Nombreproducto;
            textBox6.Text = producto[edit].Codigo;
            textBox7.Text = producto[edit].Prcio;
            textBox8.Text =Convert.ToString(producto[edit].Esistencias);
            textBox10.Text = producto[edit].Costo;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            producto[edit].Nombreproducto = textBox5.Text;
            producto[edit].Codigo = textBox6.Text;
            producto[edit].Prcio = textBox7.Text;
            producto[edit].Esistencias = Convert.ToInt32(textBox8.Text);
            producto[edit].Costo = textBox10.Text;

            String archivo = "producto.txt";
            FileStream lec = new FileStream(archivo, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(lec);
            for(int h=0;h<producto.Count;h++)
            {
                writer.WriteLine(producto[h].Nombreproducto);
                writer.WriteLine(producto[h].Codigo);
                writer.WriteLine(producto[h].Prcio);
                writer.WriteLine(producto[h].Esistencias);
                writer.WriteLine(producto[h].Costo);
            }
            writer.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReportesVista n = new ReportesVista();
            n.Show();
        }
    }
}
