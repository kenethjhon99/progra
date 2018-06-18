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
                CalcularSubTotal();

            }

        }
        public void sumatotal()
        {

        }
        public void CalcularSubTotal()
        {
            float subTotal = 0;
            for (int x = 0; x < ventas.Count; x++)
            {
                subTotal = subTotal + ventas[x].Total;
            }
            label4.Text = Convert.ToString(subTotal);
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

        private void button4_Click(object sender, EventArgs e)
        {
            float cambio = 0;
            float dinero = float.Parse(textBox4.Text);
            float subTotal = float.Parse(label4.Text);
            if (dinero < subTotal)
            {
                MessageBox.Show("No se puede realizar operacion, verifique cantidad");
            }
            else
            {
                cambio = dinero - subTotal;
                label5.Text = Convert.ToString(cambio);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actualizarArchivoProductos();
            registarDetalleVenta();
        }
        public void actualizarArchivoProductos()
        {
            string archivo = "productos.txt";
            FileStream stream = new FileStream(archivo, FileMode.Create, FileAccess.Write); //este tipo porque voy a reescribir el archivo con los nuevos productos
            StreamWriter writer = new StreamWriter(stream);
            for (int i = 0; i < producto.Count; i++) // en listado esta la lista actualizada de todos los productos
            {
                writer.WriteLine(producto[i].Nombreproducto);
                writer.WriteLine(producto[i].Codigo);
                writer.WriteLine(producto[i].Costo);
                writer.WriteLine(producto[i].Prcio);
                writer.WriteLine(producto[i].Esistencias);
            }
            writer.Close();
        }
        public void registarDetalleVenta()
        {
            string archivo = "detalleVenta.txt";
            FileStream stream = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            //Generare un codigo aleatorio
            Random rnd = new Random();
            string codigoDeVenta = Convert.ToString(rnd.Next(999999999)); // me da un numero de 0 a 99999999 para que la probabildad sea poca de que me de un numero igual
            writer.WriteLine(codigoDeVenta);
            // si estos campos estan llenos procedo a guardar los datos
            for (int y = 0; y < ventas.Count; y++)
            {
                writer.WriteLine(ventas[y].Producto);
                writer.WriteLine(ventas[y].Precio);
                writer.WriteLine(ventas[y].Existencias);
                writer.WriteLine(ventas[y].Total);
            }
            writer.WriteLine("-1"); //Me servira para saber cuando termina un detalle de venta
            writer.Close();
        }
    }
}
